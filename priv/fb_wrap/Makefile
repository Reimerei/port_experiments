all: fb_wrap.cpp
  g++ -o fb_wrap fb_wrap.c

clean:
	$(RM) fb_wrap

# the compiler
CC = g++	

# compiler flags:
#  -g    adds debugging information to the executable file
#  -Wall turns on most, but not all, compiler warnings
CFLAGS  = -g -Wall

# the build target executable:
TARGET = fb_wrap

all: $(TARGET)

$(TARGET): $(TARGET).c
	$(CC) $(CFLAGS) -o $(TARGET) $(TARGET).c

clean:
	$(RM) $(TARGET)	
