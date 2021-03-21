#include <iostream>
#include <fstream>


void GenerateFile()            
{
    char a[100];                      

	int n = 50;
	for (int i = 1; i <= n; i++)
	{
		std::ofstream fout;
		fout.open(std::to_string(i) + "test.txt");

		srand(time(0)+i);
		for (int j = 0; j < 100; j++)
		{
			for (int i = 0; i < 100; i++)
			{
				a[i] = char(rand() % 25 + 65);
				fout << a[i];
			}
			fout << "\n";
		}

		fout.close();
	}
}

int main()
{

	GenerateFile();

	
	return 0;
}
