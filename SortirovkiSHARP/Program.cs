using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortirovkiSHARP.Algorithm;
using SortirovkiSHARP.Extentions;

namespace SortirovkiSHARP
{
    class Program
    {
        static void PrintMass(List<KeyValuePair<int, string>> mass)
        {
            foreach(var m in mass)
            {
                Console.WriteLine($"Key: {m.Key} Value: {m.Value}");
            }
        }
        
        static void RessAnyKeyToContinue()
        {
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            List<KeyValuePair<int, string>> mass = new List<KeyValuePair<int, string>>();
            List<string> words = new List<string>()
            {
                "Smile", "Sweet", "Sister", "Sadistic", "Surprise", "Service", "We", "Are", "STYLE", "!"
            };
            int alg = 0;
            do
            {
                Console.WriteLine("Подсчёт сравнений - 1(c 78)");
                Console.WriteLine("Подсчёт распределения - 2(c 80)");
                Console.WriteLine("Метод простых вставок - 3(c 82)");
                Console.WriteLine("Сортировка Шелла - 4(c 86)");
                Console.WriteLine("Обменная поразрядная сортировка - 5(c 128)");
                Console.WriteLine("Быстрая сортировка - 6(c 119)");
                Console.WriteLine("Обменная сортировка слиянием(Модификация метода пузырька) - 7(c 114)");
                Console.WriteLine("Двухпутевое слияние - 8(c 164)");
                Console.WriteLine("Пирамидальная сортировка - 9(c 150)");
                Console.WriteLine("Бинарное слияние - 10(c 211)");
                Console.WriteLine("Метод вставки в список - 11(с 99)");
                Console.WriteLine("Выйти - 12");

                var input = Console.ReadLine();
                if (int.TryParse(input, out alg) 
                    && (alg < 12 && alg > 0)
                    )
                {
                    //Очищение массива и заполнение словами
                    mass.Clear();
                    for (int i = 0; i < words.Count; ++i)
                    {
                        mass.Add(new KeyValuePair<int, string>(i, words[i]));
                    }
                    //Печать ДО
                    Console.WriteLine("Изначальный лист: ");
                    PrintMass(mass);

                    //Перемешивание массива
                    mass.Shuffle();
                    //Печать перемешанного
                    Console.WriteLine("Перемешанный лист: ");
                    PrintMass(mass);

                    //Сортировка

                    switch(alg)
                    {
                        case 1:
                            mass = mass.SortAlgorithm1();
                            break;
                        case 2:
                            mass = mass.SortAlgorithm2();
                            break;
                        case 3:
                            mass = mass.SortAlgorithm3();
                            break;
                        case 4:
                            mass = mass.SortAlgorithm4(new int[] { 5, 3, 1 });
                            break;
                        case 6:
                            mass = mass.SortAlgorithm6();
                            break;
                        case 7:
                            mass = mass.SortAlgorithm7();
                            break;
                        case 8:
                            List<KeyValuePair<int, string>> fisrt = mass.Take(mass.Count / 2).ToList();
                            List<KeyValuePair<int, string>> second = mass.Skip(mass.Count / 2).ToList();
                            Console.WriteLine("Первая половина: ");
                            PrintMass(fisrt);
                            Console.WriteLine("Вторая половина: ");
                            PrintMass(second);
                            fisrt = fisrt.SortAlgorithm1();
                            second = second.SortAlgorithm1();
                            mass = fisrt.SortAlgorithm8(second);
                            break;
                        case 9:
                            mass = mass.SortAlgorithm9();
                            break;
                        default:
                            Console.WriteLine("Алгоритм пока не реализован");
                            break;
                    }
                    
                    Console.WriteLine("Отсортированный лист: ");
                    PrintMass(mass);
                    RessAnyKeyToContinue();
                }
                else
                    if (alg == 12)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод!");
                        RessAnyKeyToContinue();
                    }
            } while (true);
        }
    }
}
