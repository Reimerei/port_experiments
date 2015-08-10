#include <iostream>

using namespace std;

int main ()
{
  cin.sync_with_stdio(false);
  for (string line; getline(cin, line);) {
    cout << line << endl;
  }
  return 0;
}