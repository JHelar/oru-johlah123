#include <iostream>

#include "Watch.h"

using namespace std;

int recursive_faculty(int i)
{
    if(i == 0)
		return 1;
    else
		return i * recursive_faculty(i - 1);
}

int iterative_faculty(int i)
{
        int dummy = 0;
        dummy = i;
        while(i > 1)
        {
                dummy = dummy*(i-1);
                i--;
        }
        return dummy;
}

int main()
{
        Course::Watch w;
        for(int i = 1; i < 10; i++)
        {
                w.restart();
                for (double j = 0; j < 100000; j++)
                {
                        recursive_faculty(i);
                }
                
                cout << "Recursive" << i << "= " << w.elapsedNs().count() / 100000.0 << endl;

                w.restart();
                for (double j = 0; j < 100000; j++)
                {
                        iterative_faculty(i);
                }
                cout << "Iterative" << i << "= " << w.elapsedNs().count() / 100000.0 << endl;
        }

        cin.get();
        return 0;
}
