#include <iostream>
#include <string>

using namespace std;

void SWAP(float *ptr_x, float *ptr_y);
void SWAP(float &x,float &y);
void SWAP(string &x,string &y);

int main(){
	float x,y;
	float *ptr_x=NULL,*ptr_y=NULL;
	string s1,s2;

	cout<<"Skriv två flyttal: ";
	cin>>x;
	cin>>y;
	cout<<"\nSkriv två strängar: ";
	cin>>s1;
	cin>>s2;
	ptr_x=&x;
	ptr_y=&y;
	SWAP(x,y);
	cout<<"\nSWAP med referens: "<<x<<y;
	cin.get();
	SWAP(*ptr_x,*ptr_y);
	cout<<"\nSWAP med pekare: "<<x<<y;
	cin.get();
	SWAP(s1,s2);
	cout<<"\nSWAP med strängar: "<<s1<<s2;
	cin.get();
}

void SWAP(float *ptr_x, float *ptr_y){
	float temp;
	temp=*ptr_x;
	*ptr_x=*ptr_y;
	*ptr_y=temp;
}

void SWAP(float &x,float &y){
	float temp;
	temp=x;
	x=y;
	y=temp;
}

void SWAP(string &x,string &y){
	string temp;
	temp=x;
	x=y;
	y=temp;
}