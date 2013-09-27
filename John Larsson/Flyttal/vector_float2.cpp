#include "vector_float2.h"


void vector_float2::create_vector(int s){
	this->vtpr = unique_ptr <float>(new float[s]);
	this->size=s;
}

void vector_float2::delete_vector(){
	this->size=0;
}

void vector_float2::set(float value, int index){
	if(index>=0 && index<=size){
		this->vtpr.get()[index]=value;
	}
	else
		cout<<"\nIndex is out of bounds!";
	return;
}

void vector_float2::read_from_keyboard(){
	float tempValue;
	if(this->size>0){
		for(int i=0;i<this->size;i++){
			cout<<"\nWrite (smart)float nr"<<i<<": ";
			cin>>tempValue;
			set(tempValue,i);
		}
	}
	return;
}

void vector_float2::print(){
	if(size>0){
		cout<<"\n["<<vtpr.get()[0];
		for(int i=1;i<this->size;i++){
			cout<<","<<vtpr.get()[i];
		}
		cout<<"]";
	}
	else 
		cout<<"\nVector size = 0";
	return;
}
