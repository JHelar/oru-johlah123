#include "Movie.h"


Movie::Movie(void)
{
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

/*bool operator < (Movie one, Movie another){
		if(one.author<another.author)
                return true;
        else if((one.titel<another.titel)&&(one.author==another.author))
                return true;
		else if((one.date<another.date)&&(one.author==another.author)&&(one.titel==another.titel))
                return true;
        else
                return false;
}*/

bool Movie::sortMedia(Multimedia *one,Multimedia *another){
	Movie *m1,*m2;
	m1=dynamic_cast<Movie*>(one);
	m2=dynamic_cast<Movie*>(another);
	if(m1->getAuthor()<m2->getAuthor())
            return true;
    else if((m1->getTitel()<m2->getTitel())&&(m1->getAuthor()==m2->getAuthor()))
            return true;
	else if((m1->getDate()<m2->getDate())&&(m1->getAuthor()==m2->getAuthor())&&(m1->getTitel()==m2->getTitel()))
            return true;
    else
            return false;
}
