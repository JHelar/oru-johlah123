//SnakeBoard header
#pragma once

#include <iostream>
#include <vector>

using namespace std;

class SnakeBoard{
private:
	vector<vector<char> > Sboard;
public:
	SnakeBoard();
	~SnakeBoard();
	void clearBoard();
	void putToBoard(int x,int y,char sign);
	friend ostream& operator << (ostream &out,SnakeBoard &SB);
};