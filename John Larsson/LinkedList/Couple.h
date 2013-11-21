#pragma once

#include <iostream>

#include "Person.h"
#include "List.h"

using namespace std;

class Couple
{
private:
	Person boy;
	Person girl;
	
public:

	Couple(void)
	{
	}

	~Couple(void)
	{
	}

	void addPartners(Person boy, Person girl)
	{
		this->boy = boy;
		this->girl = girl;
	}

	
	friend ostream& operator << (ostream &out, Couple coup)
	{
		out<<"Match for: \n\n";
		out<<coup.boy;
		out<<"Matches with: \n\n";
		out<<coup.girl;
		

		return out;
	}
};

