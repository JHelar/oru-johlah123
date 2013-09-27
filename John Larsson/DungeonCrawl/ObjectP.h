#pragma once

#include <iostream>
#include <cstdlib>
#include <time.h>

using namespace std;

class ObjectP{
private:
	int Px,Py;
public:
	ObjectP();
	void setP(int x, int y);
	int getPx() const { return Px; }
	int getPy() const { return Py; } 
};