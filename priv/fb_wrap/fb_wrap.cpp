#include <iostream>

#include "flatbuffers/flatbuffers.h"
#include "flatbuffers/idl.h"
#include "flatbuffers/util.h"
#include "flatbuffers/reflection.h"
#include "flatbuffers/reflection_generated.h"

using namespace std;

int main ()
{
  // load schema
  string schemafile;
  bool ok = flatbuffers::LoadFile("priv/flatbuffers/quests.fbs", false, &schemafile);

  if (ok) {
    printf("Loaded schema filez\n");
  }

  // cin.sync_with_stdio(false);
  
  // cout.flush();

  for (string line; getline(cin, line);) {
    printf("========================\n");

    flatbuffers::Parser parser;

    ok = parser.Parse(schemafile.c_str());
    if (ok) {
      printf("Parsed schema file\n");
    }

    ok = parser.Parse(line.c_str());
    if (ok) {
      printf("Parsed json string\n");
    } else {
      printf("Error parsing json\n");
    }
    uint32_t bin_size = parser.builder_.GetSize();
    fwrite(&bin_size, 4, 1, stdout);
    fwrite(parser.builder_.GetBufferPointer(), 1, bin_size, stdout);
    
    printf("waiting...\n");
  }

  return 0;
}
