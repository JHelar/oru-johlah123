#pragma once

#include <iostream>
#include <string>
#include <sstream>

#include "InterestTable.h"

using namespace std;

class Person: public InterestTable
{
private:
	string gender;
	string name;
public:

	Person(void)
	{
	}

	Person(string gender, string name, bool bio, bool dans, bool idrott, bool resor, bool datorspel)
	{
		this->gender = gender;
		this->name = name;
		this->bio = bio;
		this->dans = dans;
		this->idrott = idrott;
		this->resor = resor;
		this->datorspel = datorspel;
	}

	void addInterest(bool bio, bool dans, bool idrott, bool resor, bool datorspel)
	{
		this->bio = bio;
		this->dans = dans;
		this->idrott = idrott;
		this->resor = resor;
		this->datorspel = datorspel;
	}

	void addGender(string gender)
	{
		this->gender = gender;
	}

	void addName(string name)
	{
		this->name = name;
	}

	string getGender(){return this->gender;}
	string getName(){return this->name;}
	
	string getInterests()
	{
		ostringstream oss;
		oss << this->bio << this->dans << this->idrott << this->resor << this->datorspel;
		return oss.str();
	}

	~Person(void)
	{
	}

	friend ostream& operator << (ostream &out, Person person)
	{
		string interest = person.getInterests();
		out<<"Name: "<<person.getName()<<"\nGender: "<<person.getGender()<<"\nInterested in: ";
		if(interest[0] == '1')
			out<<"\nBio";
		if(interest[1] == '1')
			out<<"\nDans";
		if(interest[2] == '1')
			out<<"\nIdrott";
		if(interest[3] == '1')
			out<<"\nResor";
		if(interest[4] == '1')
			out<<"\nDatorspel";
		out<<endl;
		out<<endl;
		return out;
	}

	friend bool operator == (Person one, Person another)
	{
		if(one.getGender() == another.getGender())
			if(one.getName() == another.getName())
				if(one.bio == another.bio)
					if(one.dans == another.dans)
						if(one.idrott == another.idrott)
							if(one.resor == another.resor)
								if(one.datorspel == another.datorspel)
									return true;
		return false;
	}

	friend istream& operator >> (istream &in, Person &person)
	{
		string dummy;
		char c;

		in>>c;

		getline(in,dummy,',');
		person.addName(dummy);

		getline(in,dummy,',');
		person.addGender(dummy);

		getline(in,dummy,',');

		if(dummy.compare("1") == 0)
			person.bio = true;
		else
			person.bio = false;

		getline(in,dummy,',');

		if(dummy.compare("1") == 0)
			person.dans = true;
		else
			person.dans = false;

		getline(in,dummy,',');

		if(dummy.compare("1") == 0)
			person.idrott = true;
		else
			person.idrott = false;

		getline(in,dummy,',');

		if(dummy.compare("1") == 0)
			person.resor = true;
		else
			person.resor = false;

		getline(in,dummy,')');

		if(dummy.compare("1") == 0)
			person.datorspel = true;
		else
			person.datorspel = false;

		return in;
	}
};

