#include "Register.h"





Register::~Register(void)
{
}

void Register::writeFileToRegistry(vector<Multimedia*> *RegistryPointer){
	ofstream MyFile;
	MyFile.open("MultiMedia.txt");
	for(int i=0;i<RegistryPointer->size();i++){
		(*RegistryPointer)[i]->print(MyFile);
	}
	MyFile.close();
}

void Register::readFileToRegistry(vector<Multimedia*> *RegistryPointer){
	ifstream MyFile;
	MyFile.open("MultiMedia.txt");
	while(!MyFile.eof()){
		string type;
		char c;
		MyFile>>c;
		getline(MyFile,type,',');
		if(type.compare("Book")==0){
			Book tempBook;
			tempBook.setType(type);
			MyFile>>tempBook;
			(*RegistryPointer).push_back(new Book(tempBook));
			BookCount++;
		}
		else if(type.compare("Music")==0){
			Music tempMusic;
			tempMusic.setType(type);
			MyFile>>tempMusic;
			(*RegistryPointer).push_back(new Music(tempMusic));
			MusicCount++;
			
		}
		else if(type.compare("Movie")==0){
			Movie tempMovie;
			tempMovie.setType(type);
			MyFile>>tempMovie;
			(*RegistryPointer).push_back(new Movie(tempMovie));
			MovieCount++;
		}
		else if(type.compare("Game")==0){
			Game tempGame;
			tempGame.setType(type);
			MyFile>>tempGame;
			(*RegistryPointer).push_back(new Game(tempGame));
			GameCount++;
		}
	}
	MyFile.close();
}

/*void Register::sortRegistry(vector<Multimedia*> &RegistryPointer){
	Multimedia multimediaTemp;
	Multimedia* multimedia_ptr= new Multimedia(multimediaTemp);
	for(int i=0;i<RegistryPointer.size();i++){
		for(int j=0;j<RegistryPointer.size()-1;j++){
			if(RegistryPointer[j]->getType()>RegistryPointer[j+1]->getType()){
				multimedia_ptr=RegistryPointer[j];
				RegistryPointer[j]=RegistryPointer[j+1];
				RegistryPointer[j+1]=multimedia_ptr;	
			}
		}
	}

	GameCount+=BookCount;
	MovieCount+=GameCount;
	MusicCount+=MovieCount;
	

}*/

void Register::sortRegistry(vector<Multimedia*> &RegistryPointer){
	sortRegistryFunctionType(RegistryPointer,0,RegistryPointer.size()-1); //Sort all by type
	sortRegistryFunctionAuthor(RegistryPointer,0,this->BookCount-1); //Sort author of Book
	sortRegistryFunctionAuthor(RegistryPointer,this->BookCount,(this->GameCount+this->BookCount)-1); //Sort author of Game
	sortRegistryFunctionAuthor(RegistryPointer,(this->BookCount+this->GameCount),(this->MovieCount+this->GameCount+this->BookCount)-1); //Sort author of Movie
	sortRegistryFunctionAuthor(RegistryPointer,(this->BookCount+this->GameCount+this->MovieCount),RegistryPointer.size()-1); //Sort author of Music
}

void Register::sortRegistryFunctionType(vector<Multimedia*> &RegistryPointer,int start,int end){
	Multimedia *multimediaTemp,*multimediaKey;
	int i,j,flag=0;
	if(start<end){
		i=start;
		j=end+1;
		multimediaKey=RegistryPointer[i];
		while(flag!=1){
			i++;
			while(RegistryPointer[i]->getType()<multimediaKey->getType()){
				i++;
			}
			j--;
			while(RegistryPointer[j]->getType()>multimediaKey->getType()){
				j--;
			}
			if(i<j){
				multimediaTemp=RegistryPointer[i];
				RegistryPointer[i]=RegistryPointer[j];
				RegistryPointer[j]=multimediaTemp;
			}
			else{
				flag=1;
				multimediaTemp=RegistryPointer[start];
				RegistryPointer[start]=RegistryPointer[j];
				RegistryPointer[j]=multimediaTemp;
			}
		}
	sortRegistryFunctionType(RegistryPointer,start,j-1);
	sortRegistryFunctionType(RegistryPointer,j+1,end);
	}
}

void Register::sortRegistryFunctionAuthor(vector<Multimedia*> &RegistryPointer,int start,int end){
	Multimedia *multimediaTemp,*multimediaKey;
	int i,j,flag=0;
	if(start<end){
		i=start;
		j=end+1;
		multimediaKey=RegistryPointer[i];
		while(flag!=1){
			i++;
			while(RegistryPointer[i]->getAuthor()<multimediaKey->getAuthor()){
				i++;
			}
			j--;
			while(RegistryPointer[j]->getAuthor()>multimediaKey->getAuthor()){
				j--;
			}
			if(i<j){
				multimediaTemp=RegistryPointer[i];
				RegistryPointer[i]=RegistryPointer[j];
				RegistryPointer[j]=multimediaTemp;
			}
			else{
				flag=1;
				multimediaTemp=RegistryPointer[start];
				RegistryPointer[start]=RegistryPointer[j];
				RegistryPointer[j]=multimediaTemp;
			}
		}
	sortRegistryFunctionAuthor(RegistryPointer,start,j-1);
	sortRegistryFunctionAuthor(RegistryPointer,j+1,end);
	}
}

