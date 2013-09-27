#include "Dice.h"

Dice::Dice(){
	x=0;
	srand(time(NULL));
	for(int i=0;i<3;i++){
		for(int j=0;j<3;j++){
			newdice[i][j]=' ';
		}
	}
}

void Dice::throw_dice(){
	if(_getch()==13)
		x=rand()%5+1;
	return;
}

int Dice::getValue() const{
	return x;
}

void Dice::constructDice(){
	switch(x){
	case 1:
		newdice[1][1]='X';
		break;
	case 2:
		newdice[1][0]='X';
		newdice[1][2]='X';
		break;
	case 3:
		newdice[0][1]='X';
		newdice[1][1]='X';
		newdice[2][1]='X';
		break;
	case 4:
		newdice[0][0]='X';
		newdice[0][2]='X';
		newdice[2][0]='X';
		newdice[2][2]='X';
		break;
	case 5:
		newdice[0][0]='X';
		newdice[0][2]='X';
		newdice[1][1]='X';
		newdice[2][0]='X';
		newdice[2][2]='X';
		break;
	case 6:
		newdice[0][0]='X';
		newdice[0][2]='X';
		newdice[1][0]='X';
		newdice[1][2]='X';
		newdice[2][0]='X';
		newdice[2][2]='X';
		break;
	}
	return;
}

