#pragma once

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

#include "Multimedia.h"

using namespace std;
class Book:public Multimedia
{
private:
	int pages;
public:
	Book(void){this->pages=0;}
	Book(string,string,string,string,string,int);
	~Book(void);
	void setMultimedia(string,string,string,string,string,int);

	int getPage(){return pages;}

	void print(ostream &out){out<<*this;}

	//friend bool sortMedia(Book &one,Book &another);

	friend ostream& operator << (ostream &out,Book &book);
	friend istream& operator >> (istream &in, Book &book);

	friend bool operator < (Book &one, Book &another);
	friend bool operator > (Book &one, Book &another);
};

