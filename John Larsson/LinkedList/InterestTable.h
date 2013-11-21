#pragma once

#include <iostream>

using namespace std;

class InterestTable
{
protected:
	bool bio;
	bool dans;
	bool idrott;
	bool resor;
	bool datorspel;
public:

	InterestTable(void)
	{
		bio=dans=idrott=resor=resor=datorspel = false;
	}

	~InterestTable(void)
	{
	}
};

