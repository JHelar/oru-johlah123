#pragma once

#include "Multimedia.h"
#include <string>
#include <vector>
#include <algorithm>

using namespace std;
class Game:public Multimedia
{
private:
	string genre;
public:
	Game(void){}
	Game(string,string,string,string,string,string);
	~Game(void);
	void print(ostream &out){ out<<*this; }

	void setMultimedia(string,string,string,string,string,string);

	friend ostream& operator << (ostream &out,Game &gam);
	friend istream& operator >> (istream &in, Game &gam);
};

