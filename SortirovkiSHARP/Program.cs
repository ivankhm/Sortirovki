
﻿using System;
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
                Console.WriteLine("Сортировка Шейкер - 7(c 113)");
                Console.WriteLine("Двухпутевое слияние - 8(c 164)");
                Console.WriteLine("Пирамидальная сортировка - 9(c 150)");
                Console.WriteLine("Обменная сортировка слиянием - 10(c 114)");
                Console.WriteLine("Метод вставки в список - 11(с 99)");
                Console.WriteLine("Выйти - 12");

                var input = Console.ReadLine();
                if (int.TryParse(input, out alg) 
                    && (alg < 12 && alg > 0)
                    )
                {
                    //Очищение массива и заполнение словами
                    mass.Clear();
                    for (int i = 0; i < 7; ++i)
                    {
                        mass.Add(new KeyValuePair<int, string>(i, words[i]));
                    }

                    mass[0] = new KeyValuePair<int, string>(-1, mass[0].Value);
                    //mass[1] = new KeyValuePair<int, string>(1, mass[2].Value);
                    mass[2] = new KeyValuePair<int, string>(1, mass[2].Value);
                    //mass[3] = new KeyValuePair<int, string>(2, mass[3].Value);
                    //mass[4] = new KeyValuePair<int, string>(5, mass[4].Value);
                    //mass[5] = new KeyValuePair<int, string>(2, mass[5].Value);
                    //mass[6] = new KeyValuePair<int, string>(4, mass[6].Value);

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
                            var tmpList = new List<int>();
                            var ht = mass.Count / 2;

                            while (ht > 1)
                            {
                                tmpList.Add(ht);
                                ht = ht/ 2;
                            }
                            tmpList.Add(1);
                            mass = mass.SortAlgorithm4(tmpList.ToArray());
                            break;
                        case 5:
                            mass = mass.SortAlgorithm5();
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
                        case 10:
                            mass = mass.SortAlgorithm10();
                            break;
                        case 11:
                            var tmp = new List<int[]>();
                            foreach(var m in mass)
                            {
                                tmp.Add(new int[2] { m.Key, -1 });
                            }

                            tmp = tmp.SortAlgorithm11();

                            Console.WriteLine("Упорядоченные связи: ");
                            int j = 0;
                            foreach (var tm in tmp)
                            {
                                Console.WriteLine($"j = {j++} Key: {tm[0]} Value: {tm[1]}");
                            }

                            var result = new List<KeyValuePair<int, string>>();

                            for (int p = 0; tmp[p][1] != 0;)
                            {
                                result.Add(mass[tmp[p][1] - 1]);
                                p = tmp[p][1];
                            }

                            mass = result;
                            
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