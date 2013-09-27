#include "Music.h"


Music::Music(void)
{
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

/*bool operator < (Music &one,Music &another){
	if(one.author<another.author)
           return true;
    else if((one.titel<another.titel)&&(one.author==another.author))
          return true;
	else if((one.songTitle<another.songTitle)&&(one.author==another.author)&&(one.titel==another.titel))
          return true;
    else
          return false;
}*/

/*bool Music::sortMedia(Multimedia *one,Multimedia *another){
	if(one->author<another->author)
           return true;
    else if((one->titel<another->titel)&&(one->author==another->author))
          return true;
	else if((one->songTitle<another->songTitle)&&(one->author==another->author)&&(one->titel==another->titel))
          return true;
    else
          return false;
}*/
