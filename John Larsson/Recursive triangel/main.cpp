#include <iostream>

using namespace std;

void triangle(ostream &out, unsigned int m, unsigned int n)
{
	if(m <= n)
	{
		for(int i = 0; i < m; i++)
			out<<"*";
		out<<endl;
		
		triangle(out, m + 1, n);

		for( int i = 0; i < m; i++ )
        {
                out << "*";
        }
        out << endl;
	}
}

int main()
{
	triangle(cout,3,5);

	cin.get();
	return 0;
}