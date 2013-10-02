#include <iostream>
#include <vector>
#include <algorithm>
#include <string>

#include "Register.h"
#include "Book.h"
#include "Multimedia.h"

using namespace std;

void printmedia(vector<Multimedia*> Reg);

int main(){
	string type,phrase,dummy;
	Register Registry;
	vector<Multimedia*> RegistryVector;
	vector<int> Hits;
	vector<int> emptyHits;
	int j=0;
	int choice=0;
	bool run=true;
	Registry.readFileToRegistry(&RegistryVector);
	while(run){
		system("CLS");
		cout<<"////MULTIMEDIA REGISTRY\\\\";
		cout<<endl;
		cout<<"1. Save changes to file\n";
		cout<<"2. Sort MultiMedia\n";
		cout<<"3. Search MultiMedia\n";
		cout<<"4. Add MultiMedia\n";
		cout<<"5. Exit\n";
		cout<<"Choice => ";
		cin>>choice;
		if(choice == 1){
				Registry.writeFileToRegistry(&RegistryVector);
		}
		else if(choice == 2){
				Registry.sortRegistry(RegistryVector);
				printmedia(RegistryVector);
		}
		else if(choice == 3){
				Hits=emptyHits;
				cout<<"\nSearch for a string in any type (case sensetive) : ";
				getline(cin,phrase,'\n');
				getline(cin,phrase,'\n');
				cout<<"\nSearch result:\n";
				if(Registry.searchRegistry(RegistryVector,Hits,phrase)){
					for(int i=0;i<Hits.size();i++){
						RegistryVector[Hits[i]]->print(cout);
						cout<<endl;
					}
				}
				else
					cout<<"\nCould not find what you where searching for!";
				cin.get();
		}
		else if (choice == 4){
				cout<<"\nSet what type of media to input, case sensetive! (Book,Music,Movie,Game): ";
				getline(cin,type,'\n');
				getline(cin,type,'\n');
				Registry.setRegistry(type,&RegistryVector);
				printmedia(RegistryVector);
		}
		else if (choice == 5){
				run=false;
		}
		else
			choice =1;
	}
	return 0;
}

void printmedia(vector<Multimedia*> Reg){
	cout<<"\nFile contents:\n";
	for(int i=0;i<Reg.size();i++){
		Reg[i]->print(cout);
		cout<<endl;
	}
	cout<<"Press enter to return to Menu";
	cin.get();
	cin.get();
}
