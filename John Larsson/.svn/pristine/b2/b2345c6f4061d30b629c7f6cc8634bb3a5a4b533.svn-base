#include <iostream>
#include <string>
#include <sstream>

using namespace std;

int main(int argc,char *argv[]){
	int arg_int=0;
	int sum=0;
	cout<<"argc:"<<argc<<endl;
	for(int i=0;i<argc;i++){
		istringstream iss (argv[i]);
		iss>>arg_int;
		sum+=arg_int;
		cout<<argv[i]<<endl;
		
	}
	cout<<"\nSumman av argv:"<<sum;
	cin.get();
}