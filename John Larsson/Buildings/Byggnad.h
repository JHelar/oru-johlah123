#pragma once
class Byggnad
{
protected:
        int levels,rooms;
        float area;

public:
        Byggnad(void);
        Byggnad(int levels, int rooms, float area);
        ~Byggnad(void);
        virtual void print();
};
