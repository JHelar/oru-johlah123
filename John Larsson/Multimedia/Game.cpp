#include "Game.h"


Game::Game(string author,string titel,string type,string time,string date,string genre)
{
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
	this->genre=genre;
}


Game::~Game(void)
{
}

ostream& operator<<(ostream &out,Game &gam){
	out<<"("<<gam.type<<","<<gam.author<<","<<gam.titel<<","<<gam.genre<<","<<gam.date<<","<<gam.time<<")";
	return out;
}

istream& operator>>(istream &in,Game &gam){
	in>>skipws;
	getline(in,gam.author,',');
	in>>skipws;
	getline(in,gam.titel,',');
	in>>skipws;
	getline(in,gam.genre,',');
	in>>skipws;
	getline(in,gam.date,',');
	in>>skipws;
	getline(in,gam.time,')');
	in>>skipws;
	return in;
}

void Game::setMultimedia(string author,string titel,string type,string time,string date,string genre){
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
	this->genre=genre;
}

