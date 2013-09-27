#include "SnakeCore.h"

SnakeCore::SnakeCore(){
	moveKey=' ';
	parts=0;
	newX=newY=0;
	score=0;
	food=false;
}

SnakeCore::SnakeCore(BodyPart Head){
	Head.setCords(10,5);
	newX=10;
	newY=5;
	BP.push_back(Head);
	parts=1;
	score=0;
	moveKey=RIGHT;
}

SnakeCore::~SnakeCore(){
	vector<BodyPart>().swap(BP);	
}

void SnakeCore::addPart(BodyPart newPart){
	newPart.setCords(BP[parts-1].getPrevX(),BP[parts-1].getPrevY());
	BP.push_back(newPart);
	parts+=1;
}

void SnakeCore::setNewPartCords(){
	BP[0].setCords(newX,newY);
	if(parts>1){
		for(int i=1;i<BP.size();i++){
			BP[i].setCords(BP[i-1].getPrevX(),BP[i-1].getPrevY());
		}
	}
}

void SnakeCore::move(){
	if(_kbhit())
		input();
	switch(moveKey){
	case LEFT:
		newX-=1;
		if(newX<0)
			newX=19;
		break;
	case UP:
		newY-=1;
		if(newY<0)
			newY=9;
		break;
	case RIGHT:
		newX+=1;
		if(newX>19)
			newX=0;
		break;
	case DOWN:
		newY+=1;
		if(newY>9)
			newY=0;
	break;
	}
}

void SnakeCore::input(){
	_getch();
	moveKey=_getch();
}

int SnakeCore::collission(){
	for(int i=1;i<BP.size();i++){
		if(BP[0].getX()==BP[i].getX()&&BP[0].getY()==BP[i].getY()){
			return 2;
		}
	}
	if(newX==F.getFoodX()&&newY==F.getFoodY()){
		food=false;
		score++;
		return 1;
	}
	food=true;
	return 0;
}

void SnakeCore::setBoard(SnakeBoard &Board){
	if(!food){
		checkFood();
	}
	Board.putToBoard(F.getFoodX(),F.getFoodY(),char(253));
	for(int i=0;i<BP.size();i++){
		Board.putToBoard(BP[i].getX(),BP[i].getY(),char(254));
	}
}

void SnakeCore::checkFood(){
	F.setFood();
	for(int i=0;i<BP.size();i++){
		if(F.getFoodX()==BP[i].getX()&&F.getFoodY()==BP[i].getY()){
			checkFood();	
		}
	}
}