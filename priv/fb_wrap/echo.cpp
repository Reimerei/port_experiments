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
  unsigned char li[4];
  // the first 4 bytes are the message length
  li[0] = (len & 0xff000000) >> 24;
  // write_exact(&li, 1);
  
  li[1] = (len & 0x00ff0000) >> 16;
  // write_exact(&li, 1);
  
  li[2] = (len & 0x0000ff00) >> 8;
  // write_exact(&li, 1);
  
  li[3] = (len & 0x000000ff);
  write_exact(li, 4);

  return write_exact(buf, len);
}

int main ()
{
  const int max_message_size = 1 * 1024 * 1024; // 1 MB
  unsigned char buf[max_message_size];
  
  int message_size;

  while((message_size = read_msg(buf)) > 0) {
    // write message
    write_msg(buf, message_size);
    std::cout.flush();
  }
}
