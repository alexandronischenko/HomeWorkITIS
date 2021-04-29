#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <limits>
#include <ctime>

void GenerateFile()
{
	char a[100];

	int n = 100;
	for (int i = 1; i <= n; i++)
	{
		std::ofstream fout;
		fout.open(std::to_string(i) + "test.txt");

		srand(time(0) + i);
		for (int j = 0; j < 100; j++)
		{
			for (int k = 0; k < 40; k = k + 2)
			{
				a[k] = rand() % 9 + 49;
				fout << a[k] << ' ';
			}

			fout << rand() % 100000 + 100;
			fout << "\n";
		}

		fout.close();
	}
}

//wts - массив весов, cost - массив стоимостей предметов, W - вместимость рюкзака
//функция возвращает максимальную стоимость, которую можно набрать(решение задачи о рюкзаке
//с повторениями)
//массив dp собственно реализует динамическое программирование
int GetMaxCost(const std::vector<int>& wts, const std::vector<int>& cost, int W)
{
	size_t n = wts.size();
	std::vector<int> dp(W + 1);
	dp[0] = 0;
	for (int w = 1; w <= W; w++)
	{
		dp[w] = dp[w - 1];
		for (size_t i = 0; i < n; i++)
		{
			if (wts[i] <= w)
			{
				dp[w] = std::max(dp[w], dp[w - wts[i]] + cost[i]);
			}
		}
	}
	return dp[W];
}

int main()
{
	GenerateFile();
	std::string info[101];
	int W = 0;
	int n = 0;
	int s = 0;

	std::ofstream fout;
	fout.open("result.txt");
	for (int filesCount = 1; filesCount <= 100; filesCount++)
	{

		std::string line;

		int tempArray[20];

		std::ifstream in(std::to_string(filesCount) + "test.txt"); // окрываем файл для чтения
		if (in.is_open())
		{
			//извлекаем набор предметов со стоимостью и весами
			while (in >> tempArray[0] >> tempArray[1] >> tempArray[2] >> tempArray[3] >> tempArray[4] >> tempArray[5] >> tempArray[6] >> tempArray[7] >> tempArray[8] >> tempArray[9] >>
				tempArray[10] >> tempArray[11] >> tempArray[12] >> tempArray[13] >> tempArray[14] >> tempArray[15] >> tempArray[16] >> tempArray[17] >> tempArray[18] >> tempArray[19] >> W)
			{

			}
		}

		std::vector<int> wts(10);
		std::vector<int> cost(10);
		for (int i = 0; i < 10; i++)
		{
			wts.push_back(tempArray[i]);
		}
		for (int i = 10; i < 20; i++)
		{
			cost.push_back(tempArray[i]);
		}

		unsigned int start_time = clock(); // начальное время

		int result = GetMaxCost(wts, cost, W);

		unsigned int end_time = clock(); // конечное время
		unsigned int search_time = end_time - start_time; // искомое время

		info[filesCount] = std::to_string(result) + " " + std::to_string(W) + " " + std::to_string(search_time);
		fout << info[filesCount] << std::endl;
	}

	fout.close();
}



