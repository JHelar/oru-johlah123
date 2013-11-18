#include <iostream>

#include "Intervall.h"

using namespace std;

int main()
{
	Intervall<double> i1(0.002, 1);
	Intervall<double> i2(0.002, 2);
	Intervall<double> i3(0.002, 4);

	Intervall<double> u1(5,1);
	Intervall<double> u2(5,2);
	Intervall<double> u3(5,2);

	cout<<"Test 1:"<<endl<<"I = "<< i1 << " U = "<<u1;
	cout<<"\nR = U / I => " << i1 / u1;
	cout<<"\nP = U * I => " << i1 * u1;
	cout<<endl;
	
	cout<<"\nTest 2:"<<endl<<"I = "<< i2 << " U = "<<u2;
	cout<<"\nR = U / I => " << i2 / u2;
	cout<<"\nP = U * I => " << i2 * u2;
	cout<<endl;
	
	cout<<"\nTest 3:"<<endl<<"I = "<< i3 << " U = "<<u3;
	cout<<"\nR = U / I => " << i3 / u3;
	cout<<"\nP = U * I => " << i3 * u3;
	cout<<endl;

	cin.get();
	return 0;
}