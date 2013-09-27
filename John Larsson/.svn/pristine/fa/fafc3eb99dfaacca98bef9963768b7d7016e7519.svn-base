#include "TicTacToe.h"

TicTacToe::TicTacToe(){
	for(int i=0;i<3;i++){
		for(int j=0;j<3;j++){
			plan[i][j]=' ';
		}
	}
	x=y=0;
	player=' ';
}
void TicTacToe::newgame(){
	for(int i=0;i<3;i++){
		for(int j=0;j<3;j++){
			plan[i][j]=' ';
		}
	}
	player='X';
	x=y=1;
	return;
}
void TicTacToe::print_plan(char plan[3][3]){
	cout<<"\n._._._.\n|"<<plan[0][0]<<"|"<<plan[0][1]<<"|"<<plan[0][2]<<"|\n.-.-.-.\n|"<<plan[1][0]<<"|"<<plan[1][1]<<"|"<<plan[1][2]<<"|\n.-.-.-.\n|"<<plan[2][0]<<"|"<<plan[2][1]<<"|"<<plan[2][2]<<"|\n.-.-.-.";
	return;
}
char TicTacToe::input(){
	if(_getch()==13)
		return 13;
	else 
		return _getch();
}
void TicTacToe::movement(char move){
	switch (move){
	case 'H':
		y-=1;
		if(y<0)
			y+=1;
		break;
	case 'P':
		y+=1;
		if(y>2)
			y-=1;
		break;
	case 'M':
		x+=1;
		if(x>2)
			x-=1;
		break;
	case 'K':
		x-=1;
		if(x<0)
			x+=1;
		break;
	default:
		move=char(13);
		break;
	}
	return;
}
void TicTacToe::move(){
	bool valid=false;
	char buffer_plan[3][3],marker='#',choice;
	while(!valid){
		choice='T';
		while(choice!=13){
			for(int i=0;i<3;i++){
				for(int j=0;j<3;j++){
					buffer_plan[i][j]=plan[i][j];
				}
			}
			buffer_plan[y][x]=marker;
			system("CLS");
			print_plan(buffer_plan);
			cout<<"\nSpelare "<<player<<" tur";
			choice=input();
			movement(choice); 
		}
		if(plan[y][x]=='X'||plan[y][x]=='O'){
			valid=false;
		}
		else{
			plan[y][x]=player;
			valid=true;
		}
	}
	return;
}
int TicTacToe::state(){
	for(int i=0;i<3;i++){
		if (plan[i][0]==plan[i][2]&&plan[i][0]==plan[i][1]&&plan[i][0]==player&&plan[i][1]==player&&plan[i][2]==player)
			return 1;
		else if(plan[0][i]==plan[1][i]&&plan[0][i]==plan[2][i]&&plan[0][i]==player&&plan[1][i]==player&&plan[2][i]==player)
			return 1;
	}
	if(plan[0][0]==plan[1][1]&&plan[0][0]==plan[2][2]&&plan[0][0]==player&&plan[1][1]==player&&plan[2][2]==player||plan[0][2]==plan[1][1]&&plan[0][2]==plan[2][0]&&plan[0][2]==player&&plan[1][1]==player&&plan[2][0]==player)
		return 1;
	else{
		for(int i=0;i<3;i++){
			for(int j=0;j<3;j++){
				if(plan[i][j]==' ')
					return 0;
			}
		}
		return 2;
	}
}
int TicTacToe::playgame(){
	newgame();
	while(1){
		move();
		switch(state()){
		case 2:
			system("CLS");
			print_plan(plan);
			cout<<"\nDet blev oavgjort!";
			return 1;
			break;
		case 1:
			system("CLS");
			print_plan(plan);
			cout<<"\nSpelare "<<player<<" vinner!";
			return 1;
			break;
		case 0:
			if(player=='X'){
				player='O';
			}
			else{
				player='X';
			}
			break;
		}
	}
}