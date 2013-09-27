//Header Car

#pragma once

#include <iostream>
#include <string>

using namespace std;

class Car{
private:
	string brand;
	int year;
	double price;
public:
	Car();
	Car(string b,int y,double p);
	void ReadFromConsole();
	void WriteToConsole();
	string getBrand() const { return brand;}
	void setBrand(string b) { brand=b; }

};