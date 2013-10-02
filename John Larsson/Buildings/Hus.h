#pragma once
#include <iostream>
#include "Byggnad.h"
class Hus:public Byggnad
{
private:
        int bathrooms;
public:
        Hus(void);
        Hus(int bathrooms,int levels, int rooms,float area);
        ~Hus(void);
        void print();
};