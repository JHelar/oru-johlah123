#include "matrix_float.h"


matrix_float::matrix_float(void)
{
	this->mptr=nullptr;
	this->r_size=0;
	this->c_size=0;
}

matrix_float::matrix_float(int r,int c){
	this->r_size=r;
	this->c_size=c;
	create_matrix(r,c);

}

void matrix_float::create_matrix(int r,int c){
	this->r_size=r;
	this->c_size=c;
	this-> mptr = new float*[r];
	for(int i=0;i<r;i++){
		mptr[i] = new float[c];
	}
}

void matrix_float::delete_matrix(){
	this->r_size=0;
	this->c_size=0;
	for(int i=0;i<r_size;i++){
		delete [] mptr [i];
	}
	delete [] mptr;
}

void matrix_float::set(float value, int rIndex,int cIndex){
	if(rIndex>=0 && rIndex<=r_size){
		if(cIndex>=0 && cIndex<=c_size){
			this->mptr[rIndex][cIndex]=value;
		}
	}
	else
		cout<<"\nIndex is out of bounds!";
	return;
}

void matrix_float::read_from_keyboard(){
	float tempValue;
	if(this->r_size>0 && this->c_size>0){
		for(int i=0;i<this->r_size;i++){
			for(int j=0;j<this->c_size;j++){
				cout<<"\nSet float at position row="<<i<<" column="<<j<<": ";
				cin>>tempValue;
				set(tempValue,i,j);
			}
		}
	}
	return;
}

void matrix_float::print(){
	if(r_size>0){
		if(c_size>0){
			cout<<"\n";
			for(int i=0;i<this->r_size;i++){
				cout<<char(179);
				for(int j=0;j<this->c_size;j++){
					cout<<mptr[i][j]<<" ";
				}
				cout<<char(179)<<endl;
			}
		}
		else
			cout<<"\nColumn size = 0";
	}
	else 
		cout<<"\nRow size size = 0";
	return;
}
