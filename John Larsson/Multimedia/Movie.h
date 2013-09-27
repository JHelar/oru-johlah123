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
	Movie(void);
	~Movie(void);
	
	void print(ostream &out) {out<<*this;};
	static bool sortMedia(Multimedia *one,Multimedia *another);
	
	friend ostream& operator << (ostream &out,Movie &mov);
	friend istream& operator >> (istream &in, Movie &mov);

	//friend bool operator < (Movie &one, Movie &another);
};

