#include "Header.h"

void func_1(){
	int count[N];

	for (int i = 0; i < N; i++) count[i] = 0;

	for (int i = N - 1; i > 0; i--)
		for (int j = i - 1; j >= 0; j--)
			if (mass[i] < mass[j]) count[j]++; else count[i]++;
	std::cout << "   До:";
	for (int i = 0; i < N - 1; i++) 
		std::cout << mass[i] << ", ";
	std::cout << mass[N-1] << ";" << std::endl;
	std::cout << "После:";
	for (int i = 0; i < N - 1; i++) std::cout << count[i]+1 << ", ";
	std::cout << count[N-1] + 1 << "; " << std::endl;
}  