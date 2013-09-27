#include <iostream>
#include <ctime>


#include "SnakeCore.h"
#include "SnakeBoard.h"
#include "BodyPart.h"

using namespace std;

int main(){
	clock_t before;
	int FRAMES_PER_SECOND = 10;
	BodyPart Head,part;
	SnakeBoard SB;
	SnakeCore SC(Head);
	SC.setBoard(SB);
	cout<<SB;
	cout<<"Press enter to start!";
	cin.get();
	while(SC.collission()!=2){
		before=clock();
		SC.move();
		if(SC.collission()==1){
			SC.addPart(part);
		}
		SC.setNewPartCords();
		SB.clearBoard();
		SC.setBoard(SB);
		cout<<SB;
		while ( clock()-before < CLOCKS_PER_SEC / FRAMES_PER_SECOND );
	}
	cout<<"OH NO!!!!! Score: "<<SC.getScore();
	cin.get();
}