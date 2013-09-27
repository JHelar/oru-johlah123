#pragma once

#include <string>
#include <iostream>

using namespace std;

class HighScoreData
{
private:
	string playerName;
	int playerScore;
public:
	HighScoreData(void);
	HighScoreData(string pName,int pScore);
	~HighScoreData(void);

	string getName() const { return playerName; }
	void setName(string pName) { this->playerName=pName;}
	int getScore() const { return playerScore; }
	void setScore(int pScore) { this->playerScore=pScore;}

	friend ostream& operator << (ostream &out, HighScoreData &HD);
	friend istream& operator >> (istream &in, HighScoreData &HD);
	friend bool operator == (HighScoreData &one,HighScoreData &another);
	friend bool operator < (HighScoreData &one, HighScoreData &another);
};

