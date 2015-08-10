# the compiler
CC = g++	

# compiler flags:
#  -g    adds debugging information to the executable file
#  -Wall turns on most, but not all, compiler warnings
CFLAGS  = -g -Wall -std=c++11

# the build target executable:
TARGET = fb_wrap

# folders to include
INCLUDES = -I/opt/flatbuffers/include

all: main $(TARGET)

idl_parser: lib/flatbuffers/idl_parser.cpp
	$(CC) $(CFLAGS) $(INCLUDES) -c -o idl_parser.o lib/flatbuffers/idl_parser.cpp

idl_gen_text: lib/flatbuffers/idl_gen_text.cpp
	$(CC) $(CFLAGS) $(INCLUDES) -c -o idl_gen_text.o lib/flatbuffers/idl_gen_text.cpp	

main: fb_wrap.cpp
	$(CC) $(CFLAGS) $(INCLUDES) -c -o fb_wrap.o fb_wrap.cpp

$(TARGET): idl_gen_text.o idl_parser.o fb_wrap.o
	$(CC) $(CFLAGS) $(INCLUDES) -o $(TARGET) idl_gen_text.o idl_parser.o fb_wrap.o 



clean:
	$(RM) $(TARGET)	
