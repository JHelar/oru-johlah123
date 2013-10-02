
#include <iostream>

#include "Hus.h"
#include "Kontor.h"

using namespace std;
int main(){
        
        Hus Hus1,Hus2(7,2,4,340.5);
        Kontor Kontor1,Kontor2(5,7,4,6,302.6);
        
        Kontor1.print();
        Kontor2.print();

        Hus1.print();
        Hus2.print();
        cin.get();
        return 0;
}