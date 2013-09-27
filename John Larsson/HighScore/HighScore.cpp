#include "HighScore.h"


HighScore::HighScore(void)
{
	
}


HighScore::~HighScore(void)
{

}

void HighScore::setHighScore(HighScoreData &HD){
	HSD.push_back(HD);
}

void HighScore::printHighScore(){
	sortScoreBoard();
	for(int i=0;i<HSD.size();i++){
		cout<<"\nPlayer: "<<HSD[i].getName()<<" Score: "<<HSD[i].getScore();
	}
}

void HighScore::readFile(){
	ifstream myFile;
	HighScoreData empty;
	HighScoreData temp;
	myFile.open("highscore.txt");
	while(!myFile.eof()){
		temp=empty;
		myFile>>temp;
		if(temp==empty){
			break;
		}
		HSD.push_back(temp);
	}
	myFile.close();
}

void HighScore::writeFile(){
	ofstream myFile;
	myFile.open("highscore.txt");
	for(int i=0;i<HSD.size();i++){
		myFile<<HSD[i];
	}
	myFile.close();
	return;
}

void HighScore::sortScoreBoard(){
	sort(HSD.begin(),HSD.end());
	return;
}