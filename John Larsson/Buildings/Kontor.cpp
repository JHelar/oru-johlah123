#include "Kontor.h"

using namespace std;
Kontor::Kontor(void)
{
        this->firealarm=0;
        this->phones=0;
        this->levels=0;
        this->rooms=0;
        this->area=0.0;
}

Kontor::Kontor(int firealarm, int phones,int levels, int rooms, float area){
        this->firealarm=firealarm;
        this->phones=phones;
        this->levels=levels;
        this->rooms=rooms;
        this->area=area;
}


Kontor::~Kontor(void)
{
}

void Kontor::print(){
        cout<<"\nLevels,Rooms,Area,Firealarms,Phones: "<<       this->levels<<","<<this->rooms<<","<<this->area<<","<<this->firealarm<<","<<this->phones;
}