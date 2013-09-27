#include <iostream>

#include "vector_float.h"
#include "vector_float2.h"
#include "matrix_float.h"

using namespace std;

int main(){
	vector_float myVector(2);
	vector_float2 mySmartVector(2);
	matrix_float myMatrix(2,2);


	myVector.read_from_keyboard();
	myVector.print();*/
	mySmartVector.read_from_keyboard();
	mySmartVector.print();
	myMatrix.read_from_keyboard();
	myMatrix.print();

	cin.get();
	cin.get();
	return 0;
}