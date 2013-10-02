#include "Music.h"


Music::Music(string author,string titel,string type,string time,string date,string songTitle,string songTime)
{
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
	this->songTitle=songTitle;
	this->songTime=songTime;

}


Music::~Music(void)
{
}

ostream& operator<<(ostream &out,Music &mus){
	out<<"("<<mus.type<<","<<mus.author<<","<<mus.titel<<","<<mus.songTitle<<","<<mus.songTime<<","<<mus.date<<","<<mus.time<<")";
	return out;
}

istream& operator>>(istream &in,Music &mus){
	in>>skipws;
	getline(in,mus.author,',');
	in>>skipws;
	getline(in,mus.titel,',');
	in>>skipws;
	getline(in,mus.songTitle,',');
	in>>skipws;
	getline(in,mus.songTime,',');
	in>>skipws;
	getline(in,mus.date,',');
	in>>skipws;
	getline(in,mus.time,')');
	in>>skipws;
	return in;
}

void Music::setMultimedia(string author,string titel,string type,string time,string date,string songTitle,string songTime){
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
	this->songTitle=songTitle;
	this->songTime=songTime;
}
