#include <iostream>

#include "DungeonCrawl.h"
#include "ObjectT.h"

using namespace std;

int main(){
	char choice;
	int state;
	DungeonCrawl DC;
	while(1){
		state=0;
		DC.newGame();
		DC.Gboard.drawBoard();
		while(state==0){
			DC.movement();
			DC.Gboard.drawBoard();
			state=DC.state();
		}
		cout<<"\nSpela igen? <j/n> ";
		cin>>choice;
		if(choice==tolower('n'))
			break;
	}
	cin.get();
}