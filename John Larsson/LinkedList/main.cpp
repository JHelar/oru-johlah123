#include <iostream>

#include "FileManager.h"
#include "Dejt.h"

using namespace std;

int main(void)
{
	Dejt dejt;
	FileManager FM;

	int amount = 0;
	
	FM.ReadFile("People.txt");
	cout<<"The female list: \n\n";
	cout<<FM.girlList.str();
	cout<<"\nThe male list: \n\n";
	cout<<FM.boyList.str();
	cout<<"Enter the amount of mathing interests: ";
	cin>>amount;

	dejt.setCouples(FM.boyList,FM.girlList,amount);
	cout<<dejt.PrintCouples();

	cin.get();
	cin.get();
	return 0;
}