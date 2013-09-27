//Dice header

#include <iostream>
#include <cstdlib>
#include <string>
#include <time.h>
#include <conio.h>

using namespace std;

#ifndef DICE_H
#define DICE_H

class Dice{
public:
	Dice();
	void throw_dice();
	int getValue() const;
	void constructDice();
	char newdice[3][3];
private:
	int x;

};
#endif