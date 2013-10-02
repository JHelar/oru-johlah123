#include "Register.h"





Register::~Register(void)
{
}

void Register::writeFileToRegistry(vector<Multimedia*> *RegistryPointer){
	ofstream MyFile;
	MyFile.open("MultiMedia.txt");
	for(int i=0;i<RegistryPointer->size();i++){
		(*RegistryPointer)[i]->print(MyFile);
		MyFile<<endl;
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

void Register::sortRegistry(vector<Multimedia*> &RegistryPointer){	
	sortRegistryFunctionType(RegistryPointer,0,RegistryPointer.size()-1); //Sort all by type	
	sortRegistryFunctionAuthor(RegistryPointer,0,this->BookCount-1); //Sort author of Book	
	sortRegistryFunctionAuthor(RegistryPointer,this->BookCount,(this->GameCount+this->BookCount)-1); //Sort author of Game	
	sortRegistryFunctionAuthor(RegistryPointer,(this->BookCount+this->GameCount),(this->MovieCount+this->GameCount+this->BookCount)-1); //Sort author of Movie	
	sortRegistryFunctionAuthor(RegistryPointer,(this->BookCount+this->GameCount+this->MovieCount),RegistryPointer.size()-2); //Sort author of Music
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
}void Register::sortRegistryFunctionAuthor(vector<Multimedia*> &RegistryPointer,int start,int end){	
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

void Register::setRegistry(string type,vector<Multimedia*> *RegistryPointer){
	time_t rawtime;
    tm* timeinfo;
	string auth,titl,typ;
    char dateBuffer[80];
	char timeBuffer[80];
	time(&rawtime);
    timeinfo = localtime(&rawtime);
	strftime(dateBuffer,80,"%Y-%m-%d",timeinfo);
	strftime(timeBuffer,80,"%H:%M:%S",timeinfo);
	string dat(dateBuffer);
	string tim(timeBuffer);
	if(type.compare("Book")==0){
		int pages;
		Book tempBook;
		cout<<"Author =>";
		getline(cin,auth,'\n');
		cout<<"Titel =>";
		getline(cin,titl,'\n');
		cout<<"Pages =>";
		cin>>pages;
		tempBook.setMultimedia("Book",auth,titl,dat,tim,pages);
		(*RegistryPointer).push_back(new Book(tempBook));
	}
	else if(type.compare("Music")==0){
		Music tempMusic;
		string songtitl,songtim;
		cout<<"Artist =>";
		getline(cin,auth,'\n');
		cout<<"Album Titel =>";
		getline(cin,titl,'\n');
		cout<<"Song Titel =>";
		getline(cin,songtitl,'\n');
		cout<<"Song Duration (min:sec) =>";
		getline(cin,songtim,'\n');
		tempMusic.setMultimedia(auth,titl,"Music",tim,dat,songtitl,songtim);
		(*RegistryPointer).push_back(new Music(tempMusic));
	}
	else if(type.compare("Movie")==0){
		Movie tempMovie;
		vector<string> actors;
		string actor;
		cout<<"Director =>";
		getline(cin,auth,'\n');
		cout<<"Movie Titel =>";
		getline(cin,titl,'\n');
		cout<<"Actors (# sign when done) =>";
		while(1){
			cout<<"\t=>";
			getline(cin,actor,'\n');
			if(actor.compare("#")==0)
				break;
			else
				actors.push_back(actor);
		}
		tempMovie.setMultimedia(auth,titl,"Movie",tim,dat,actors);
		(*RegistryPointer).push_back(new Movie(tempMovie));
	}
	else if(type.compare("Game")==0){
		Game tempGame;
		string genre;
		cout<<"Game Publisher =>";
		getline(cin,auth,'\n');
		cout<<"Game Titel =>";
		getline(cin,titl,'\n');
		cout<<"Game Genre =>";
		getline(cin,genre,'\n');
		tempGame.setMultimedia(auth,titl,"Game",tim,dat,genre);
		(*RegistryPointer).push_back(new Game(tempGame));
	}
	else
		cout<<"Type not defined, check spelling and uppercase first letter!";
	return;
}

bool Register::searchRegistry(vector<Multimedia*> RegistryPointer,vector<int> &Hits,string phrase){
	for(int i=0;i<RegistryPointer.size();i++){
		if((*RegistryPointer[i]).getAuthor().compare(phrase)==0){
			Hits.push_back(i);
		}
		else if((*RegistryPointer[i]).getTitel().compare(phrase)==0){
			Hits.push_back(i);
		}
		else if((*RegistryPointer[i]).getDate().compare(phrase)==0){
			Hits.push_back(i);
		}
		else if((*RegistryPointer[i]).getTime().compare(phrase)==0){
			Hits.push_back(i);
		}
		else if((*RegistryPointer[i]).getType().compare(phrase)==0){
			Hits.push_back(i);
		}
	}
	return true;
}