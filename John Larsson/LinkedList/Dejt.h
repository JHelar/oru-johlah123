#pragma once

#include <iostream>

#include "FileManager.h"
#include "List.h"
#include "Couple.h"
#include "Person.h"

class Dejt
{
public:
	List<Couple> couples;

	Dejt(void)
	{
	}

	~Dejt(void)
	{
	}

	void setCouples(List<Person> boys, List<Person> girls,int amount)
	{
		Person girl;
		Person matchBoy;
		Person emptyGirl;

		Couple coup;

		string boyString;
		string girlString;

		int prevHits = 0;
		int size = girls.size() +1;

		for(int i = 0; i < size; i++)
		{
			girl = girls.pop();
			girlString = girl.getInterests();

			for (auto boy = boys.begin(); boy != boys.end(); boy++)
			{
				int hits = 0;
				prevHits = 0;

				boyString = (*boy).info.getInterests();
				for(int i = 0; i < amount; i++)
				{
					if(boyString[i] == girlString[i])
						hits++;
				}
				boyString.clear();

				if(hits > prevHits)
				{
					prevHits = hits;
				}

				if(prevHits == amount)
				{
					matchBoy = boy->info;
					coup.addPartners(girl,boy->info);
					break;
				}
			}
			if(prevHits != amount){
				for (auto boy = boys.begin(); boy != boys.end(); boy++)
				{
					int tempHits = 0;

					boyString = (*boy).info.getInterests();
					for(int i = 0; i < amount; i++)
					{
						if(boyString[i] == girlString [i])
							tempHits++;
					}
					boyString.clear();

					if(tempHits > prevHits)
					{
						tempHits = prevHits;
					}

					if(tempHits == prevHits)
					{
						matchBoy = (*boy).info;
						coup.addPartners(girl,(*boy).info);
						break;
					}
				}
			}
			boys.Remove(boys.Search(matchBoy));
			couples.add(coup);
		}
	}

	string PrintCouples()
	{
		return couples.str();
	}

};

