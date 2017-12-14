
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortirovkiSHARP.Extentions;


namespace SortirovkiSHARP.Algorithm
{
    static class Algorithm
    {
        public static List<KeyValuePair<int, string>> SortAlgorithm1(this IList<KeyValuePair<int, string>> mass)
        {
            int N = mass.Count;
            var count = new int[N];

            for (int i = 0; i < N; i++)
            {
                count[i] = 0;
            }

            for (int i = N - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (mass[i].Key < mass[j].Key)
                    {
                        count[j]++;
                    } 
                    else
                    {
                        count[i]++;
                    }
                }
            }

            var result = new List<KeyValuePair<int, string>>();

            for (int i = 0; i < N; ++i)
            {
                result.Add(new KeyValuePair<int, string>());
            }

            for (int i = 0; i < N; ++i)
            {
                result[count[i]] = mass[i];
            }

            return result;
        }
        
        public static List<KeyValuePair<int, string>> SortAlgorithm2(this IList<KeyValuePair<int, string>> mass)
        {
            int N = mass.Count;
            int u = 1000000, v = -1;

            for (int i = 0; i < N; i++)
            {
                if (mass[i].Key < u)
                {
                    u = mass[i].Key;
                }
                if (mass[i].Key > v)
                {
                    v = mass[i].Key;
                }
            }

            var count = new int[v+1];

            for (int i = 0; i < N; i++)
            {
                count[i] = 0;
            }
            
            for (int j = 0; j < N; j++)
            {
                count[mass[j].Key]++;
            }
            
            for (int i = u + 1; i < v + 1; ++i)
            {
                count[i] += count[i - 1];
            }

            var result = new List<KeyValuePair<int, string>>();

            for (int i = 0; i < N; ++i)
            {
                result.Add(new KeyValuePair<int, string>());
                count[i]--;
            }
            
            for (int j = N-1; j >= 0; --j)
            {
                int i = count[mass[j].Key];
                result[i] = mass[j];
                count[mass[j].Key] = i - 1;
            }

            /*
            for (int i = u + 1; i < v+1; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (mass[i].Key < mass[j].Key)
                    {
                        count[j]++;
                    }
                    else
                    {
                        count[i]++;
                    }
                }
            }

            for (int i = 0; i < N; ++i)
            {
                count[i]--;
            }
            */

            return result;
        }

        public static List<KeyValuePair<int, string>> SortAlgorithm3(this IList<KeyValuePair<int, string>> mass)
        {
            //Копия изначального листа
            var result = new List<KeyValuePair<int, string>>();
            
            foreach (var m in mass)
            {
                result.Add(m);
            }

            var N = result.Count;

            int i;
            KeyValuePair<int, string> Mm;
            
            for (int j = 1; j <= 9; j++)
            {
                i = j - 1;
                Mm = result[j];

                while(Mm.Key < result[i].Key)
                {
                    result[i + 1] = result[i];
                    i--;
                    if(i == -1)
                    {
                        break;
                    }
                }
                result[i + 1] = Mm;
            }

            return result;
        }

        public static List<KeyValuePair<int, string>> SortAlgorithm4(this IList<KeyValuePair<int, string>> mass, int[] h)
        {
            var result = new List<KeyValuePair<int, string>>();

            foreach (var m in mass)
            {
                result.Add(m);
            }
            
            var t = h.Count();
            
            var N = result.Count;
            //D1
            for (int s = t - 1; s >= 0; --s)
            {
                //D2
                var h_s = h[s];
                
                for (int j = h_s; j < N; ++j )
                {
                    //D3
                    int i = j - h_s;
                    var tmp = result[j];

                    //4
                    while (tmp.Key < result[i].Key)
                    {
                        //D5
                        result[i + h_s] = result[i];
                        i = i - h_s;
                        if (i <= -1)
                        {
                            break;
                        }
                    }
                    //D6
                    result[i + h_s] = tmp;
                    
                }
            }


            return result;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm5(this IList<KeyValuePair<int, string>> mass)
        {
            int l = 1;
            int r = mass.Count;
            int M = 3;
            int[] temp = new int[2];
            var MyStack = new Stack<int[]>();
            do
            {
                int i = l;
                int j = r + 1;
                int K = mass[j].Key;         
                do
                {
                    do
                    {
                        i++;
                    } while (mass[i].Key < K);
                    do
                    {
                        j--;
                    } while (K < mass[j].Key);
                    if (i < j) mass.Swap(i, j);
                } while (i < j);
                mass.Swap(l, j);
                if ((r - j >= j - l) && (j - l > M))
                    {
                        temp[0] = j + 1;
                        temp[1] = r;
                        MyStack.Push(temp);
                        r = j--;
                    } else if ((j - l > r - j) && (r - j > M))
                    {
                        temp[0] = l;
                        temp[1] = j - 1;
                        MyStack.Push(temp);
                        r = j++;
                    } else if ((r - j > M) && (M >= j - l))
                    {
                        l = j++;
                    }
                    else if ((j - l > M) && (M >= r - j))
                    {
                        r = j--;
                    }
            } while ((r<=M)&&(l<=M));
            temp = MyStack.Pop();
            l = temp[0];
            r = temp[1];
            mass = mass.SortAlgorithm3();

            var result = new List<KeyValuePair<int, string>>();

            for (int i = 0; i < 9; ++i)
            {
                result.Add(new KeyValuePair<int, string>());
            }

            for (int i = 0; i < 9; ++i)
            {
                result[i] = mass[i];
            }
            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm6(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm7(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm8(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm9(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm10(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm11(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
    }  
 }
