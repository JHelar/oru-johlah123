#include "Byggnad.h"


Byggnad::Byggnad(void)
{
        this->area=0;
        this->levels=0;
        this->rooms=0;
}

Byggnad::Byggnad(int levels, int rooms, float area){
        this->levels=levels;
        this->rooms=rooms;
        this->area=area;
}

Byggnad::~Byggnad(void)
{
}

void Byggnad::print(){

}