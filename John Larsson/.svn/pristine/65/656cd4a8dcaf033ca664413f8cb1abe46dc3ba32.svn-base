#pragma once

#include <iostream>
#include <memory>

using namespace std;

class vector_float2
{
private:
	int size;
	unique_ptr <float> vtpr;

	void create_vector(int s);
	void delete_vector();
public:
	vector_float2(void) { create_vector(0); 
						 this->vtpr=nullptr;}
	vector_float2(int s){ create_vector(s);}
	~vector_float2(){ delete_vector(); }
	void set(float value,int index);
	void read_from_keyboard();
	void print();
};

