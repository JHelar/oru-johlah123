#include <iostream>

#include "TicTacToe.h"

using namespace std;

int main(){
	TicTacToe ttt;
	char choice;
	while(1){
		ttt.playgame();
		cout<<"Spela igen? <j/n>";
		cin>>choice;
		if(choice=tolower('n'))
			break;
	}
	cin.get();
}