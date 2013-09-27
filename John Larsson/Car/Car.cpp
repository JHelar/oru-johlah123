#include "Car.h"

Car::Car(){
	year=0;
	price=0.0;
}

Car::Car(string b, int y, double p){
	brand=b;
	year=y;
	price=p;
}

void Car::WriteToConsole(){
	cout<<"M�rke= "<<brand<<endl;
	cout<<"�r= "<<year<<endl;
	cout<<"Pris= "<<price<<endl;
}

void Car::ReadFromConsole(){
	cout<<"\nM�rke: ";
	getline(cin,brand,'\n');
	cout<<"\n�r: ";
	cin>>year;
	cout<<"\nPris: ";
	cin>>price;
}