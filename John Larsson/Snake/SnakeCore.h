//Snake core header
#pragma once

#include <iostream>
#include <conio.h>
#include <vector>

#include "BodyPart.h"
#include "SnakeBoard.h"
#include "Food.h"

#define LEFT 75
#define UP 72
#define RIGHT 77
#define DOWN 80

using namespace std;

class SnakeCore{
private:
	vector<BodyPart> BP;
	Food F;
	bool food;
	int score;
	int parts;
	int newX,newY;
	char moveKey;
public:
	SnakeCore();
	SnakeCore(BodyPart Head);
	~SnakeCore();
	void addPart(BodyPart newPart);
	void setNewPartCords();
	void input();
	void move();
	int collission();
	void checkFood();
	int getScore()const{return score;}
	void setBoard(SnakeBoard &Board);
};