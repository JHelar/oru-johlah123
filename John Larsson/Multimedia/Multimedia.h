#pragma once

#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

class Multimedia
{
protected:
	string author,titel,type,time,date;
public:
	Multimedia(void);
	Multimedia(string,string,string,string,string);
	~Multimedia(void);
	void setType(string type){this->type=type;}
	
	string getTitel(){return titel;}
	string getType(){return type;}
	string getAuthor(){return author;}
	string getTime(){return time;}
	string getDate(){return date;}

	//virtual bool sortMedia(Multimedia &one,Multimedia &another){return true;}
	virtual void print(ostream &out) {};	
	virtual void setMultimedia(string,string,string,string,string);
};

