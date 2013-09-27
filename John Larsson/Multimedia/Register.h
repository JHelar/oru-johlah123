#pragma once

#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include <conio.h>

#include "Multimedia.h"
#include "Book.h"
#include "Music.h"
#include "Movie.h"
#include "Game.h"

using namespace std;
class Register
{
private:
	int BookCount,GameCount,MovieCount,MusicCount;
public:
	Register(void){this->BookCount=0; this->GameCount=0; this->MovieCount=0; this->MusicCount=0;}
	~Register(void);
	void writeFileToRegistry(vector<Multimedia*> *RegistryPointer);
	void readFileToRegistry(vector<Multimedia*> *RigistryPointer);
	void sortRegistry(vector<Multimedia*> &RegistryPointer);
	void sortRegistryFunctionType(vector<Multimedia*>&,int,int);
	void sortRegistryFunctionAuthor(vector<Multimedia*>&,int,int);
};

