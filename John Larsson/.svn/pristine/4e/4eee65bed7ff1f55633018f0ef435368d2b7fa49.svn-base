#include "HighScoreData.h"


HighScoreData::HighScoreData(void)
{
	this->playerScore=0;
}

HighScoreData::HighScoreData(string pName,int pScore){
	this->playerName=pName;
	this->playerScore=pScore;
}
HighScoreData::~HighScoreData(void)
{

}

ostream& operator << (ostream &out, HighScoreData &HD){
	out<<"("<<HD.playerName<<","<<HD.playerScore<<")"<<endl;
	return out;
}

istream& operator >> (istream &in, HighScoreData &HD){
	char c;
	in>>c;
	getline(in,HD.playerName,',');
	in>>HD.playerScore;
	in>>c;
	in>>skipws;
	return in;
}

bool operator == (HighScoreData &one, HighScoreData &another){
	if(one.playerName==another.playerName){
		if(one.playerScore==another.playerScore){
			return true;
		}
	}
	return false;
}

bool operator < (HighScoreData &one, HighScoreData &another){
	if(one.playerScore < another.playerScore){
		return false;
	}
	return true;
}
