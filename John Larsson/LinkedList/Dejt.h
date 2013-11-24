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
		Person emptyPerson;

		Couple coup;

		string boyString;
		string girlString;

		int prevHits = 0;
		int size = girls.size() +1;

		for(int i = 0; i < size; i++)
		{
			girl = girls.pop();
			girlString = girl.getInterests();
			prevHits = 0;

			for (auto boy = boys.begin(); boy != boys.end(); boy++)
			{
				int hits = 0;
				

				boyString = (*boy).info.getInterests();
				for(int i = 0; i < 5; i++)
				{
					if(boyString[i] == '1' && girlString[i] == '1')
						hits++;
				}
				boyString.clear();

				if(hits > prevHits && hits <= amount)
				{
					matchBoy = emptyPerson;
					prevHits = hits;
					matchBoy = boy->info;
				}
			}
			boys.Remove(boys.Search(matchBoy));
			coup.addPartners(girl,matchBoy);
			couples.add(coup);
			girl = emptyPerson;
			matchBoy = emptyPerson;
		}
	}

	string PrintCouples()
	{
		return couples.str();
	}

};

