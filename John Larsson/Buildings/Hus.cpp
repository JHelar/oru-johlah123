#include "Hus.h"

using namespace std;
Hus::Hus(void)
{
        this->bathrooms=0;
        this->levels=0;
        this->rooms=0;
        this->area=0.0;
}

Hus::Hus(int bathrooms,int levels, int rooms, float area){
        this->bathrooms = bathrooms;
        this->levels=levels;
        this->rooms=rooms;
        this->area=area;
}
Hus::~Hus(void)
{
}

void Hus::print(){
        cout<<"\nLevels,Rooms,Area,Bathrooms: "<<this->levels<<","<<this->rooms<<","<<this->area<<","<< this->bathrooms;
}