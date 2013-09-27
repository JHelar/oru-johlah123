#include "ObjectX.h"

ObjectX::ObjectX(){
	Xx=Xy=0;
}

void ObjectX::setX(){
	Xx=1+(rand()%10);
	Xy=1+(rand()%10);
}