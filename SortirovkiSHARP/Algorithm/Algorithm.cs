﻿using System.Collections.Generic;
using System.Linq;
using SortirovkiSHARP.Extentions;
using System;

namespace SortirovkiSHARP.Algorithm
{
    static class Algorithm
    {
        public static List<KeyValuePair<int, string>> SortAlgorithm1(this IList<KeyValuePair<int, string>> mass)
        {
            int N = mass.Count;
            var count = new int[N];
            //C1
            for (int i = 0; i < N; i++)
            {
                count[i] = 0;
            }
            //C2
            for (int i = N - 1; i > 0; i--)
            {
                //C3
                for (int j = i - 1; j >= 0; j--)
                {
                    //C4
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
            int u = 1000000, v = -1000;
            
            //Считаем диапазон
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
            
            var count = new int[N];
            //D1
            for (int i = 0; i < N; i++)
            {
                count[i] = 0;
            }
            //D2
            for (int j = 0; j < N; j++)
            {
                //D3
                count[mass[j].Key]++;
            }
            //D4
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
            //D5
            for (int j = N-1; j >= 0; --j)
            {
                //D6
                int i = count[mass[j].Key];
                result[i] = mass[j];
                count[mass[j].Key] = i - 1;
            }

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
            //S1
            for (int j = 1; j < N; j++)
            {
                //S2
                i = j - 1;
                Mm = result[j];

                //S3
                while(Mm.Key < result[i].Key)
                {
                    //S4
                    result[i + 1] = result[i];
                    i--;
                    if(i == -1)
                    {
                        break;
                    }
                }
                //S5
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

                    //D4
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
            List<KeyValuePair<int, string>> result_mass = new List<KeyValuePair<int, string>>();
            for (int z = 0; z < mass.Count; z++)
            {
                result_mass.Add(mass[z]);
            }
            var N = result_mass.Count;
            //R1
            var l = 0;
            var r = N-1;
            var b = 1;
            int j = 0;
            int i = 0;
            var m = 11;
            int flag = 0;
            int ssanina = 0;
            var MyStack = new List<int[]>();

            do
            {            
                do
                {
                    //R2
                    if (l != r)
                    {
                        i = l;
                        j = r;
                        do
                        {
                            //R3
                            if (ListExtentions.GetBit(result_mass[i].Key, b, m) == 1)
                            {
                                int tempo=1;
                                do
                                {
                                    //R6
                                    j--;
                                    if (i <= j)
                                    {
                                        //R5
                                        tempo = ListExtentions.GetBit(result_mass[j + 1].Key, b, m);
                                        if (tempo == 0)
                                        {
                                            //R7
                                            result_mass.Swap(i, j + 1);
                                            i++;
                                            flag = 1;
                                        }
                                    } else break;
                                } while (tempo!=0);
                                if (flag == 0) break;
                            }//R4
                            else i++;
                        } while (i <= j);
                        //R8
                        flag = 0;
                        b++;
                        if (b > m) break; else if (j == l) l++; else if ((j <= l) || (j == r)) continue;
                            else
                            {
                            //R9
                                int[] temp = new int[2];
                                temp[0] = r;
                                temp[1] = b;
                                MyStack.Add(temp);
                                r = j;
                            }
                    }
                    else if (l == r) break;
                } while ((j <= l) || (j == r));
                //R10
                ssanina = 1;
                if (MyStack.Count > 0)
                {
                    l = r + 1;
                    int[] temp = new int[2];
                    temp = MyStack[MyStack.Count - 1];
                    r = temp[0];
                    b = temp[1];
                    MyStack.RemoveAt(MyStack.Count - 1);
                    ssanina = 0;
                }
            } while (ssanina == 0);

            return result_mass;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm6(this IList<KeyValuePair<int, string>> mass)
        {
            var N = mass.Count;
            int l = 1;
            int r = N; 
            int M = 1;
            int govno = 0;
            int ssanina = 0;
            var MyStack = new List<int[]>();
            List<KeyValuePair<int, string>> result_mass = new List<KeyValuePair<int, string>>();
            result_mass.Clear();
            result_mass.Add(new KeyValuePair<int, string>(-123, "Начало"));
            for (int i = 0; i < mass.Count; i++)
             {
                 result_mass.Add(mass[i]);
             }
            result_mass.Add(new KeyValuePair<int, string>(1230, "Конец"));
            do
            {

                do
                {
                    //Q2
                    int i = l;
                    int j = r + 1;
                    int K = result_mass[l].Key;
                    do
                    {
                        //Q3
                        do
                        {
                            ++i;
                        } while (result_mass[i].Key < K);
                        //Q4
                        do
                        {
                            --j;
                        } while (K < result_mass[j].Key);
                        //Q5 else Q6
                        if (j <= i) result_mass.Swap(l, j); else result_mass.Swap(i, j);
                    } while (i < j);

                    //Q7
                    if ((r - j >= j - l) && (j - l > M))
                    {
                        int[] temp = new int[2];
                        temp[0] = j + 1;
                        temp[1] = r;
                        MyStack.Add(temp);
                        r = j - 1;
                    }
                    else if ((j - l > r - j) && (r - j > M))
                    {
                        int[] temp = new int[2];
                        temp[0] = l;
                        temp[1] = j - 1;
                        MyStack.Add(temp);
                        l = j + 1;
                    }
                    else if ((r - j > M) && (M >= j - l))
                    {
                        l = j + 1;
                    }
                    else if ((j - l > M) && (M >= r - j))
                    {
                        r = j - 1;
                    }
                    else
                        govno = 1;
                } while (govno == 0);
                govno = 0;
                //Q8
                ssanina = 1;
                if (MyStack.Count != 0)
                {
                    int[] temp = new int[2];
                    temp = MyStack[MyStack.Count - 1];
                    l = temp[0];
                    r = temp[1];
                    MyStack.RemoveAt(MyStack.Count - 1);
                    ssanina = 0;
                }
            } while (ssanina == 0);
            return result_mass;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm7(this IList<KeyValuePair<int, string>> mass)
        {

            var result = new List<KeyValuePair<int, string>>();

            foreach (var m in mass)
            {
                result.Add(m);
            }

            var N = mass.Count;

            var BOUND_RIGHT = N-1;
            var BOUND_LEFT = 0;
            var isToRight = true;
            int t;
            do
            {
                t = -1;
                if (isToRight)
                {
                    for (int j = BOUND_LEFT; j < BOUND_RIGHT; ++j)
                    {
                        if (result[j].Key > result[j + 1].Key)
                        {
                            result.Swap(j, j + 1);
                            t = j;
                        }
                    }
                    BOUND_RIGHT = t;
                   
                }
                else
                {

                    for (int j = BOUND_RIGHT; j >= BOUND_LEFT; --j)
                    {
                        if (result[j].Key > result[j+1].Key)
                        {
                            result.Swap(j, j + 1);
                            t = j;
                        }
                    }
                    BOUND_LEFT = t;
                }
                isToRight = !isToRight;

            } while (t != -1);
            
            return result;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm8(this IList<KeyValuePair<int, string>> first, List<KeyValuePair<int, string>> second)
        {
            var n = second.Count;
            var m = first.Count;
            

            var result = new List<KeyValuePair<int, string>>();

            for (int t = 0; t < n + m; ++t)
            {
                result.Add(new KeyValuePair<int, string>());
            }

            for (int t = 1; t < m; ++t)
            {
                if (first[t-1].Key > first[t].Key)
                {
                    throw new ArgumentOutOfRangeException(nameof(first));
                }
            }

            for (int t = 1; t < n; ++t)
            {
                if (second[t - 1].Key > second[t].Key)
                {
                    throw new ArgumentOutOfRangeException(nameof(second));
                }
            }

            int i, j, k;

            //M1
            i = 0;
            j = 0;
            k = 0;
            
            do
            {
                //M2
                if (first[i].Key <= second[j].Key)
                {
                    //M3
                    result[k] = first[i];
                    k++;
                    i++;
                    if (i < m)
                    {
                        //M2
                        continue;
                    }
                    //M4
                    for (int t = k, l = j; (t < m + n) && (l < n); ++t, ++l)
                    {
                        result[t] = second[l];
                    }
                    break;
                }
                else
                {
                    result[k] = second[j];
                    k++;
                    j++;
                    if (j < n)
                    {
                        //M2
                        continue;
                    }
                    //M6
                    for (int t = k, l = i; (t < m + n) && (l < m); ++t, ++l)
                    {
                        result[t] = first[l];
                    }
                    break;
                }
            } while (true);


            return result;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm9(this IList<KeyValuePair<int, string>> mass)
        {
            var result = new List<KeyValuePair<int, string>>();

            foreach (var m in mass)
            {
                result.Add(m);
            }
            var N = result.Count;

            
            int l; 
            int r;
            int j, i;
            KeyValuePair<int, string> tmp;
            //H1
            l = N / 2 + 1;
            r = N;
            do
            {
                //H2
                if (l > 1)
                {
                    l--;
                    tmp = result[l - 1];
                }
                else
                {
                    tmp = result[r - 1];
                    result[r - 1] = result[0];
                    r--;
                    if (r == 1)
                    {
                        result[0] = tmp;
                        //end
                        break;
                    }
                }

                //protaskivanie

                //H3
                j = l;

                do
                {
                    //H4
                    i = j;//??
                    j *= 2;

                    if (j <= r)
                    {
                        //HX
                        if (j != r)
                        {
                            //H5
                            if (result[j - 1].Key < result[j].Key)
                            {
                                j++;
                            }
                        }
                        //H6
                        if (tmp.Key < result[j - 1].Key)
                        {
                            //H7
                            result[i - 1] = result[j - 1];
                            //H4
                            continue;
                        }

                    }
                    //H8
                    result[i - 1] = tmp;
                    //H2
                    break;                   
                } while (true);
            
            } while (true);


            return result;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm10(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<int[]> SortAlgorithm11(this IList<int[]> mass)
        {
            //value - connection
            var result = new List<int[]>
            {
                new int[2] { -1, mass.Count }
            };
            foreach (var m in mass)
            {
                result.Add(m);
            }
            var N = result.Count - 1;
            //L1
            result[N][1] = 0;
            int p, q, K;


            for (int j = N - 1; j < 0; ++j)
            {
                //L2
                p = result[0][1];
                q = 0;
                K = result[j][0];

                do
                {
                    //L3
                    if (K <= result[p][0])
                    {
                        //L5
                        break;
                    }
                    //L4
                    q = p;
                    p = result[q][1];
                    
                } while (p > 0);

                //L5
                result[q][1] = j;
                result[j][1] = p;

            }

            return result;
        }
    }  
 }
