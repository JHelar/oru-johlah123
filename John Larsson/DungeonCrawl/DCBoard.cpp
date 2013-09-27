#include "DCBoard.h"

DCBoard::DCBoard(){
	for(int i=0;i<10;i++){
		for(int j=0;j<10;j++){
			board[i][j]=' ';
		}
	}
}

int DCBoard::checkBoard(int x, int y){
	if(board[y][x]=='T')
		return 2;
	else if(board[y][x]=='X')
		return 1;
	else 
		return 0;
}

void DCBoard::setToBoard(int x, int y, char c){
	board[y][x]=c;
}

void DCBoard::newBoard(ObjectT trap[5],ObjectX treassure,ObjectP player){
	for(int i=0;i<10;i++){
		for(int j=0;j<10;j++){
			board[i][j]=' ';
		}
	}
	for(int i=0;i<5;i++){
		board[trap[i].getTy()][trap[i].getTx()]='T';
	}
	board[player.getPy()][player.getPx()]='P';
	board[treassure.getXy()][treassure.getXy()]='X';
}

void DCBoard::drawBoard(){
	system("CLS");
	cout<<"---------------------";
	for(int i=0;i<10;i++){
		cout<<"\n!"<<board[i][0]<<"!"<<board[i][1]<<"!"<<board[i][2]<<"!"<<board[i][3]<<"!"<<board[i][4]<<"!"<<board[i][5]<<"!"<<board[i][6]<<"!"<<board[i][7]<<"!"<<board[i][8]<<"!"<<board[i][9]<<"!";
	}
	cout<<"\n---------------------";
}