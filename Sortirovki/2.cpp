#include "Header.h"

void func_2() {
	int u = 1000000, v = 0;
	for (int i = 0; i < N; i++)
	{
		if (mass[i] < u) u = mass[i];
		if (mass[i] > v) v = mass[i];
	}
	int *count = new int[v+1];

	for (int i = 0; i < v+1; i++) count[i] = 0;

	for (int j = 0; j < N; j++) count[mass[j]]++;

	for (int i=u+1; i<v; i++)
		for (int j = i - 1; j >= 0; j--)
			if (mass[i] < mass[j]) count[j]++; 
			else count[i]++;

	std::cout << "   До:";
	for (int i = 0; i < N - 1; i++) std::cout << mass[i] << ", ";
	std::cout << mass[N - 1] << ";" << std::endl;
	std::cout << "После:";
	for (int i = 0; i < N - 1; i++) std::cout << count[i] + 1 << ", ";
	std::cout << count[N - 1] + 1 << "; " << std::endl;

	delete[] count;
}