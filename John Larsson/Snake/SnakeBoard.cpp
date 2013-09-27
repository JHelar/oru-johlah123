#include "SnakeBoard.h"

SnakeBoard::SnakeBoard(){
	for(int i=0;i<10;i++){
		vector<char> row;
		for(int j=0;j<20;j++){
			row.push_back(' ');
		}
		Sboard.push_back(row);
	}
}

SnakeBoard::~SnakeBoard(){
	vector<vector<char>>().swap(Sboard);
}
void SnakeBoard::clearBoard(){
	for(int i=0;i<10;i++){
		for(int j=0;j<20;j++){
			Sboard[i][j]=' ';
		}
	}
}

void SnakeBoard::putToBoard(int x,int y,char sign){
	Sboard[y][x]=sign;
}

ostream& operator << (ostream &out, SnakeBoard &SB){	
	system("CLS");
	out<<"SNAKE!\n";
	out<<char(218)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(191)<<endl;
	for(int i=0;i<10;i++){
		out<<char(179);
		for(int j=0;j<20;j++){
			out<<SB.Sboard[i][j];
		}
		out<<char(179)<<endl;
	}
	out<<char(192)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(196)<<char(217)<<endl;
	return out;
}

