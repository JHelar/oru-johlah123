
#include <iostream>
#include "Car.h"

using namespace std;

int main(){
	Car bil1;
	Car bil2("Volvo",1999,9500.5);

	bil2.WriteToConsole();

	bil1.ReadFromConsole();
	bil1.WriteToConsole();

	cin.get();
	return 0;
}