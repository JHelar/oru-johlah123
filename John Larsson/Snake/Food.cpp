#include "Food.h"

Food::Food(){
	srand(time(NULL));
	x=1+(rand()%20);
	y=1+(rand()%10);
	y-=1;
	x-=1;
}

Food::~Food(){

}

void Food::setFood(){
	srand(time(NULL));
	x=1+(rand()%20);
	y=1+(rand()%10);
	y-=1;
	x-=1;
}
