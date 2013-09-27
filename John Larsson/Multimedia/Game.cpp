#include "Game.h"


Game::Game(void)
{
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

/*bool operator<(Game &one,Game &another){
	if(one.author<another.author)
            return true;
    else if((one.titel<another.titel)&&(one.author==another.author))
            return true;
	else if((one.genre<another.genre)&&(one.author==another.author)&&(one.titel==another.titel))
            return true;
    else
            return false;
}

bool operator>(Game &one,Game &another){
	if(one.author>another.author)
            return true;
    else if((one.titel>another.titel)&&(one.author==another.author))
            return true;
	else if((one.genre>another.genre)&&(one.author==another.author)&&(one.titel==another.titel))
            return true;
    else
            return false;
}

bool sortMedia(Game &one,Game &another){
	if(one<another)
		return true;
	else if(one>another)
		return false;
}*/