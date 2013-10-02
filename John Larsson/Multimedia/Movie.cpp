#include "Movie.h"


Movie::Movie(string author,string titel,string type,string time,string date,vector<string> actors)
{
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
	this->actors=actors;
}


Movie::~Movie(void)
{
}

ostream& operator<<(ostream &out,Movie &mov){
	out<<"("<<mov.type<<","<<mov.author<<","<<mov.titel<<",(";
	for(int i=0;i<mov.actors.size();i++){
		out<<mov.actors[i]<<",";
	}
	out<<"),"<<mov.date<<","<<mov.time<<")";
	
	return out;
}

istream& operator>>(istream &in,Movie &mov){
	string str;
	char c;
	in>>skipws;
	getline(in,mov.author,',');
	in>>skipws;
	getline(in,mov.titel,',');
	in>>c;
	in>>skipws;
	while(getline(in,str,',')){
		if(str.compare(")")==0)
			break;
		mov.actors.push_back(str);
	}
	in>>skipws;
	getline(in,mov.date,',');
	in>>skipws;
	getline(in,mov.time,')');
	in>>skipws;
	return in;
}

void Movie::setMultimedia(string author,string titel,string type,string time,string date,vector<string> actors){
	this->author=author;
	this->titel=titel;
	this->type=type;
	this->time=time;
	this->date=date;
	this->actors=actors;
}
