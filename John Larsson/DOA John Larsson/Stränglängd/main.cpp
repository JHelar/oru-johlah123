#include <iostream>

using namespace std;

int RecStrLenght(char str[])
{
	if(str[0]=='\0')
		return 0;
	else
		return 1 + RecStrLenght(str + 1);
}

int main()
{
	cout<<"Given string is "<<RecStrLenght("12345678910")<<" letters long";
	cin.get();
	return 0;
}