#pragma once

#include <string>
#include <vector>
#include <string>
#include <algorithm>

#include "Multimedia.h"

using namespace std;
class Movie:public Multimedia
{
private:
	vector<string> actors;
public:
	Movie(void){}
	Movie(string,string,string,string,string,vector<string>);
	~Movie(void);
	
	void print(ostream &out) {out<<*this;};
	void setMultimedia(string,string,string,string,string,vector<string>);
	
	friend ostream& operator << (ostream &out,Movie &mov);
	friend istream& operator >> (istream &in, Movie &mov);
};

