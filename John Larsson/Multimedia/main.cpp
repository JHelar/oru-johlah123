#include <iostream>
#include <vector>
#include <algorithm>

#include "Register.h"
#include "Book.h"
#include "Multimedia.h"

using namespace std;


int main(){
	Book MultiMediaTemp;
	Register Registry;
	vector<Multimedia*> RegistryVector;
	Multimedia multimediaTemp;
	Multimedia* multimedia_ptr= new Multimedia(multimediaTemp);
	/*MultiMediaTemp.setMultimedia("Johnny","Bananas","Book","14:56","2013-04-05",152);
	RegistryVector.push_back(new Book(MultiMediaTemp));
	Registry.writeFileToRegistry(RegistryVector);*/
	Registry.readFileToRegistry(&RegistryVector);
	Registry.sortRegistry(RegistryVector);
	/*for(int i=0;i<RegistryVector.size();i++){
		for(int j=0;j<RegistryVector.size()-1;j++){
			if(RegistryVector[j]->getType()>RegistryVector[j+1]->getType()){
				multimedia_ptr=RegistryVector[j+1];
				RegistryVector[j+1]=RegistryVector[j];
				RegistryVector[j]=multimedia_ptr;
			}
		}
	}*/
	for(int i=0;i<RegistryVector.size();i++){
		RegistryVector[i]->print(cout);
		cout<<endl;
	}
	cin.get();
	return 0;
}