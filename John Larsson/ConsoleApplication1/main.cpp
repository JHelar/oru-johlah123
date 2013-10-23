#include <iostream>

using namespace std;
class Base 
{
	int one;
public:
	int two;
};
class More: public Base
{
	int three;
public: 
	static int four;
	Base base;
};

int main()
{
	More more;
	More::four = 0;
	return 0;
}