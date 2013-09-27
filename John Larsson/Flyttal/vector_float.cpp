#include "vector_float.h"

void vector_float::create_vector(int s){
	this->vtpr=new float[s];
	this->size=s;
}

void vector_float::delete_vector(){
	delete [] vtpr;
	this->size=0;
}

void vector_float::set(float value, int index){
	if(index>=0 && index<=size){
		this->vtpr[index]=value;
	}
	else
		cout<<"\nIndex is out of bounds!";
	return;
}

void vector_float::read_from_keyboard(){
	float tempValue;
	if(this->size>0){
		for(int i=0;i<this->size;i++){
			cout<<"\nWrite float nr"<<i<<": ";
			cin>>tempValue;
			set(tempValue,i);
		}
	}
	return;
}

void vector_float::print(){
	if(size>0){
		cout<<"\n["<<vtpr[0];
		for(int i=1;i<this->size;i++){
			cout<<","<<vtpr[i];
		}
		cout<<"]";
	}
	else 
		cout<<"\nVector size = 0";
	return;
}