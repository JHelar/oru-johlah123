#pragma once

#include "Multimedia.h"
#include <vector>
#include <algorithm>

class Music:public Multimedia
{
private:
	string songTime,songTitle;
public:
	Music(void);
	Music(string,string,string,string,string,string);
	~Music(void);

	void setMultimedia(string,string,string,string,string,string);
	static bool sortMedia(Music *one, Music *another);

	void print(ostream &out){ out<<*this;}

	friend ostream& operator << (ostream &out,Music &mus);
	friend istream& operator >> (istream &in,Music &mus);

	//friend bool operator < (Music one,Music &another);
};

