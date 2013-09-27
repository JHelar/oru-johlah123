//TicTacToe header
#include <iostream>
#include <conio.h>
#include <cstdlib>

using namespace std;

#ifndef TICTACTOE_H
#define TICTACTOE_H

class TicTacToe{
public:
	TicTacToe();
	int playgame();
	void newgame();
	void print_plan(char plan[3][3]);
	void move();

private:
	char plan[3][3];
	char player;
	int x,y;
	char input();
	int state();
	void movement(char move);
};
#endif