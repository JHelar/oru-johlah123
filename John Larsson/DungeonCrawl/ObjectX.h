#pragma once

#include <iostream>
#include <cstdlib>
#include <time.h>

using namespace std;

class ObjectX{
private:
	int Xx,Xy;
public:
	ObjectX();
	void setX();
	int getXx() const { return Xx; }
	int getXy() const { return Xy; } 
};