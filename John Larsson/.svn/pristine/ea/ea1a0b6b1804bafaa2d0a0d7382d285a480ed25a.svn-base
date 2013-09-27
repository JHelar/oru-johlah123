#include "matrix_float2.h"


matrix_float2::matrix_float2(void)
{
	this->mptr=nullptr;
	this->r_size=0;
	this->c_size=0;
}

matrix_float2::matrix_float2(int r,int c){
	this->r_size=r;
	this->c_size=c;
	create_matrix(r,c);

}

void matrix_float2::create_matrix(int r,int c){
	this->r_size=r;
	this->c_size=c;
	this-> mptr = unique_ptr<float *>(new float *[r]);
	for(int i=0;i<r;i++){
		mptr.get()[i] = unique_ptr<float>(new float [c]);
	}
}

void matrix_float2::delete_matrix(){
	this->r_size=0;
	this->c_size=0;
}

void matrix_float2::set(float value, int rIndex,int cIndex){
	if(rIndex>=0 && rIndex<=r_size){
		if(cIndex>=0 && cIndex<=c_size){
			//(this->mptr)get()[rIndex][cIndex]=value;
			(this->mptr)
		}
	}
	else
		cout<<"\nIndex is out of bounds!";
	return;
}

void matrix_float2::read_from_keyboard(){
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

void matrix_float2::print(){
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
