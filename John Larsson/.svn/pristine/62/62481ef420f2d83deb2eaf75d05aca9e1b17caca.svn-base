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
	cout<<"Märke= "<<brand<<endl;
	cout<<"År= "<<year<<endl;
	cout<<"Pris= "<<price<<endl;
}

void Car::ReadFromConsole(){
	cout<<"\nMärke: ";
	getline(cin,brand,'\n');
	cout<<"\nÅr: ";
	cin>>year;
	cout<<"\nPris: ";
	cin>>price;
}