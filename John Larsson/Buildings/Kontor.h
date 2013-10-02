#pragma once

#include <iostream>

#include "Byggnad.h"
class Kontor:public Byggnad
{
private:
        int firealarm,phones;
public:
        Kontor(void);
        Kontor(int firealarm, int phones,int floors, int rooms, float area);
        ~Kontor(void);
        void print();
};