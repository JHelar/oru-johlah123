#include <iostream>

#include "HighScore.h"

using namespace std;

int main(){
	HighScore highscore;

	highscore.readFile();
	highscore.printHighScore();
	cin.get();
	return 0;
}