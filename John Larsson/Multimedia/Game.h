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
	Game(void);
	~Game(void);
	void print(ostream &out){ out<<*this; }

	friend ostream& operator << (ostream &out,Game &gam);
	friend istream& operator >> (istream &in, Game &gam);
};

