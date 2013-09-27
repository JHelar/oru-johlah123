#pragma once

#include <iostream>
#include <memory>

using namespace std;

class matrix_float2
{
private:
	unique_ptr <float *> mptr;
	int r_size;
	int c_size;

	void create_matrix(int r, int c);
	void delete_matrix();
public:
	matrix_float2(void);
	matrix_float2(int r, int c);
	~matrix_float2(void){ delete_matrix(); }

	void set(float value,int rIndex,int cIndex);
	void read_from_keyboard();
	void print();
};

