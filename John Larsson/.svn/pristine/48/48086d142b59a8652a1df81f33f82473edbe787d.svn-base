#pragma once

#include <iostream>

using namespace std; 

class vector_float{
private:
	float *vtpr;
	int size;

	void create_vector(int s);
	void delete_vector();
public:
	vector_float(void) { create_vector(0); 
						 this->vtpr=nullptr;}
	vector_float(int s){ create_vector(s);}
	~vector_float(){ delete_vector(); }
	void set(float value,int index);
	void read_from_keyboard();
	void print();
};

