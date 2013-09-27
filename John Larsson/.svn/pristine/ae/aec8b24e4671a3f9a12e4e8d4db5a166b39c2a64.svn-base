#pragma once

#include <iostream>

using namespace std;

class matrix_float
{
private:
	float **mptr;
	int r_size;
	int c_size;

	void create_matrix(int r, int c);
	void delete_matrix();
public:
	matrix_float(void);
	matrix_float(int r, int c);
	~matrix_float(void){ delete_matrix(); }

	void set(float value,int rIndex,int cIndex);
	void read_from_keyboard();
	void print();
};

