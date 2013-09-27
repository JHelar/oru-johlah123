#include "Multimedia.h"


Multimedia::Multimedia(void)
{
	this->author='NULL';
	this->titel='NULL';
	this->type='NULL';
	this->time='NULL';
	this->date='NULL';
}

Multimedia::Multimedia(string author,string titel,string type,string time,string date){
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
}
Multimedia::~Multimedia(void)
{
}

void Multimedia::setMultimedia(string author,string titel,string type,string time,string date){
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
}
