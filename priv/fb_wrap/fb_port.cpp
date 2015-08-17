#include <iostream>

#include "flatbuffers/flatbuffers.h"
#include "flatbuffers/idl.h"
#include "flatbuffers/util.h"
#include "flatbuffers/reflection.h"
#include "flatbuffers/reflection_generated.h"

#include "nifpp.h"

#include <iostream>

int read_exact(unsigned char *buf, int len)
{
  return fread(buf, 1, len, stdin);
}

int read_msg(unsigned char *buf)
{
  // read the first 4 bytes as the message length
  read_exact(buf, 4); 
  int len = (buf[0] << 24) | (buf[1] << 16) | (buf[2] << 8) | buf[3];

  // read the message of given length
  return read_exact(buf, len);
}

int write_exact(unsigned char *buf, int len)
{
  return fwrite(buf, 1, len, stdout);
}

int write_msg(unsigned char *buf, int len)
{
  // the first 4 bytes are the message length
  unsigned char li[4];
  li[0] = (len & 0xff000000) >> 24;
  li[1] = (len & 0x00ff0000) >> 16;
  li[2] = (len & 0x0000ff00) >> 8;
  li[3] = (len & 0x000000ff);
  write_exact(li, 4);

  int res = write_exact(buf, len);
  std::cout.flush();      
  return res;
}

int main ()
{
  const int max_message_size = 5 * 1024 * 1024; // 5 MB
  unsigned char buf[max_message_size];
  
  int message_size;
  std::string schemafile;

  flatbuffers::LoadFile("/tmp/quests.fbs", false, &schemafile);
  
  flatbuffers::Parser parser;
  parser.Parse(schemafile.c_str());    
  
  while((message_size = read_msg(buf)) > 0) {

    parser.builder_.Clear();

    int mode = buf[0];
    // 0: json -> fb
    // 1: fb -> json

    if(mode == 0) {      
      // add null termination
      buf[message_size] = 0;

      parser.Parse((const char *) &buf[1]);

      // write message
      write_msg(parser.builder_.GetBufferPointer(), parser.builder_.GetSize());
    } else if(mode == 1) {
      std::string json;

      parser.builder_.PushBytes((const uint8_t *) &buf[1], message_size-1);      

      flatbuffers::GeneratorOptions opts = flatbuffers::GeneratorOptions();
      opts.strict_json = true;
      opts.indent_step = -1;

      flatbuffers::GenerateText(parser, parser.builder_.GetBufferPointer(), opts, &json);

      write_msg((unsigned char *) json.c_str(), json.size());
    }
  }
}

// int foo ()
// {
  // load schema
  // std::string schemafile;
  // flatbuffers::LoadFile("quests.fbs", false, &schemafile);
  // // cin.sync_with_stdio(false);
  
  // // cout.flush();

  // for (string line; getline(cin, line);) {
  //   flatbuffers::Parser parser;

  //   parser.Parse(schemafile.c_str());    
  //   parser.Parse(line.c_str());
    
  //   uint32_t bin_size = parser.builder_.GetSize();

  //   fwrite(&bin_size, 1, 4, stdout);
  //   fwrite(parser.builder_.GetBufferPointer(), 1, bin_size, stdout);
  // }

  // return 0;
// }
