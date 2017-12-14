#include "Header.h"
using namespace std;

class My_word
{
public:
	string str;
	int key;
	My_word(string s, int k) {
		str = s;
		key = k;
	}
};

vector<My_word> phraise;
vector<string> mass = { "Omae", "wa" ,"mou", "shindeiru" , ". " , "NANI" , "?" , "!" , "BOOOM", "!" };

void main()
{
	for (int i = 0; i < N; i++)
		phraise.push_back(My_word(mass[i],i));
	setlocale(0, "Russian");
	int alg = 0;	
	/*do {
		cout << "Подсчёт сравнений - 1(c 78)" << endl; //+
		cout << "Подсчёт распределения - 2(c 80)" << endl; //-
		cout << "Метод простых вставок - 3(c 82)" << endl; //-
		cout << "Сортировка Шелла - 4(c 86)" << endl; //-
		cout << "Обменная поразрядная сортировка - 5(c 128)" << endl; //-
		cout << "Быстрая сортировка - 6(c 119)" << endl; //-
		cout << "Модификация метода пузырька - 7(c 109)" << endl; //-
		cout << "Двухпутевое слияние - 8(c 164)" << endl; //-
		cout << "Пирамидальная сортировка - 9(c 150)" << endl; //-
		cout << "Бинарное слияние - 10(c 211)" << endl; //-	
		cout << "Метод вставки в список - 11(с 99)" << endl; //-
		cin >> alg;
	} while (alg < 1);
	
	switch (alg)
	{
	case 1: func_1(); break;
	case 2: func_2(); break;
	case 1: func_1(); break;
	case 1: func_1(); break;
	case 1: func_1(); break;
	case 1: func_1(); break;
	case 1: func_1(); break;
	case 1: func_1(); break;
	case 1: func_1(); break;
	case 1: func_1(); break;
	default:
		break;
	}*/

	for (int i = 0; i < N; i++)
		cout << phraise[i].str << endl;
}