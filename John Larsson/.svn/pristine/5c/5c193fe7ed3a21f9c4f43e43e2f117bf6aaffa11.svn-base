#pragma once

#include <fstream>
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

#include "HighScoreData.h"

using namespace std;

class HighScore
{
private:
	vector <HighScoreData> HSD;	
	void sortScoreBoard();
public:
	HighScore(void);
	~HighScore(void);
	void readFile();
	void writeFile();
	void setHighScore(HighScoreData &HD);
	void printHighScore();
};

