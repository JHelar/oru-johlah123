#pragma once 

#include <iostream>

#include "DCBoard.h"
#include "ObjectP.h"
#include "ObjectT.h"
#include "ObjectX.h"

using namespace std;

class DungeonCrawl{
private:
	ObjectX treassure;
	ObjectT traps[5];
	ObjectP player;
	int s;
public:
	DCBoard Gboard;
	DungeonCrawl();
	void newGame();
	void movement();
	char input();
	int state();

};