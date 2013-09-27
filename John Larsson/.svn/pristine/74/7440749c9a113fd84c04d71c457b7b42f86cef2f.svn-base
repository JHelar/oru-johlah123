#include <iostream>

#include "Dice.h"

using namespace std;

int main(){
	Dice d1,d2;
	char choice;
	while(1){
		cout<<"Kasta dice 1 (enter)";
		cin.get();
		d1.throw_dice();
		cout<<"\nKasta dice 2 (enter)";
		d2.throw_dice();
		cout<<"\n -----\n"<<"! "<<d1.newdice[0][0]<<d1.newdice[0][1]<<d1.newdice[0][2]<<" !\n! "<<d1.newdice[1][0]<<d1.newdice[1][1]<<d1.newdice[1][2]<<" !\n! "<<d1.newdice[2][0]<<d1.newdice[2][1]<<d1.newdice[2][2]<<" !\n -----";
		cout<<"\n\n -----\n"<<"! "<<d2.newdice[0][0]<<d2.newdice[0][1]<<d2.newdice[0][2]<<" !\n! "<<d2.newdice[1][0]<<d2.newdice[1][1]<<d2.newdice[1][2]<<" !\n! "<<d2.newdice[2][0]<<d2.newdice[2][1]<<d2.newdice[2][2]<<" !\n -----";
		cout<<"\nKasta igen? <j/n> ";
		cin>>choice;
		if(choice=tolower('n'))
			break;
	}
	cin.get();
}