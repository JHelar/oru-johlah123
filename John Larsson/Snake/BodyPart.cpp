#include "BodyPart.h"

BodyPart::BodyPart(){
	x=y=yPrev=xPrev=0;
}

BodyPart::BodyPart(int x,int y){
	xPrev=this->x;
	yPrev=this->y;
	this->x=x;
	this->y=y;
}

void BodyPart::setCords(int x,int y){
	xPrev=this->x;
	yPrev=this->y;
	this->x=x;
	this->y=y;
}

BodyPart::~BodyPart(){
	
}

