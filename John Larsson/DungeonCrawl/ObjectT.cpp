#include "ObjectT.h"

ObjectT::ObjectT(){
	srand(time(NULL));
	tx=ty=0;
}

void ObjectT::setT(){
	tx=1+(rand()%10);
	ty=1+(rand()%10);
}