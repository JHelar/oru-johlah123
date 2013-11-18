#include <iostream>
#include <string>
#include <sstream>

#include "Watch.h"

using namespace std;

int recursive_fib(int n)
{
	if(n <= 2)
		return n;
	else
		return recursive_fib(n - 1) + recursive_fib(n-2);
}

int iterative_fib(int n)
{
	int fib_n_2 = 0;
	int fib_n_1 = 1;
	int fib_n = 0;

	for(int i = 0; i < n; i++)
	{
		 fib_n = fib_n_1 + fib_n_2;
		 fib_n_2 = fib_n_1;
		 fib_n_1 = fib_n;
	}

	return fib_n;
}

int main()
{
	Course::Watch w;
	int fibValues[7] = {5,10,15,20,21,22,23};

	for(int i = 0; i < 7; i++)
	{
		w.restart();
		for(double j = 0; j < 1000; j++)
		{
			recursive_fib(fibValues[i]);
		}
		cout << "Recursive " << fibValues[i] << " => " << w.elapsedNs().count() / 1000.0 << endl;

		w.restart();
		for(double j = 0; j < 1000; j++)
		{
			iterative_fib(fibValues[i]);
		}
		cout << "Iterative" << fibValues[i] << " => " << w.elapsedNs().count() / 1000.0 << endl;
	}
	cin.get();
	return 0;
}