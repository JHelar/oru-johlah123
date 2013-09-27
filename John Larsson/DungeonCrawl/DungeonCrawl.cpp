#include "DungeonCrawl.h"

DungeonCrawl::DungeonCrawl(){
	for(int i=0;i<5;i++){
		traps[i].setT();
	}
	treassure.setX();
	player.setP(1,1);
	Gboard.newBoard(traps,treassure,player);
	s=0;
}

void DungeonCrawl::newGame(){
	for(int i=0;i<5;i++){
		traps[i].setT();
	}
	treassure.setX();
	player.setP(1,1);
	Gboard.newBoard(traps,treassure,player);
}

void DungeonCrawl::movement(){
	int y,x;
	y=player.getPy();
	x=player.getPx();
	Gboard.setToBoard(player.getPx(),player.getPy(),' ');
	switch(input()){
	case 'H':
		y-=1;
		if(y<0)
			y+=1;
		break;
	case 'P':
		y+=1;
		if(y>9)
			y-=1;
		break;
	case 'M':
		x+=1;
		if(x>9)
			x-=1;
		break;
	case 'K':
		x-=1;
		if(x<0)
			x+=1;
		break;
	}
	s=Gboard.checkBoard(x,y);
	player.setP(x,y);
	Gboard.setToBoard(player.getPx(),player.getPy(),'P');
	return;
}

char DungeonCrawl::input(){
	_getch();
	return _getch();
}

int DungeonCrawl::state(){
	if(s==1){
		cout<<"\nDu fann skatten!";
		return 1;
	}
	else if(s==2){
		cout<<"\nIt's a trap!!!";
		return 1;
	}
	else
		return 0;
}