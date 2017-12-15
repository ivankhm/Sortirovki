
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

            return null;
        }

        public static List<KeyValuePair<int, string>> SortAlgorithm6(this IList<KeyValuePair<int, string>> mass)
        {
            var N = mass.Count;
            int l = 1;
            int r = mass.Count - 1; //mass.Count
            int M = 3;
            int[] temp = new int[2];
            var MyStack = new Stack<int[]>();
            do
            {
                int i = l;
                int j = r; // r + 1
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
            //стэк пустой и эт действие ни на что не влияет чет хз
            /*
            temp = MyStack.Pop();
            l = temp[0];
            r = temp[1];
            */
            mass = mass.SortAlgorithm3();

            var result = new List<KeyValuePair<int, string>>();

            for (int i = 0; i < N; ++i)
            {
                result.Add(new KeyValuePair<int, string>());
            }

            for (int i = 0; i < N; ++i)
            {
                result[i] = mass[i];
            }
            return result;
        }
        
        public static List<KeyValuePair<int, string>> SortAlgorithm7(this IList<KeyValuePair<int, string>> mass)
        {

            var result = new List<KeyValuePair<int, string>>();

            foreach (var m in mass)
            {
                result.Add(m);
            }

            var N = mass.Count;
            //M1
            int t = (int)Math.Log(N, 2) + 1;
            int p = (int)Math.Pow(2, t - 1);
            //M2
            do
            {
                int q = (int)Math.Pow(2, t - 1);
                int r = 0;
                int d = p;

                //M3
                do
                {
                    for (int i = 0; (i < N - d); ++i)
                    {
                        if ((i & p) == r)
                        {
                            //M4
                            if (result[i].Key > result[i + d].Key)
                            {
                                result.Swap(i, i + d);
                            }
                        }
                    }
                    //M5
                    if (q != p)
                    {
                        d = q - p;
                        q /= 2;
                        r = p;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                p /= 2;
            } while (p > 0);


            /*
             * Обычный пузырек
            var N = result.Count;

            var BOUND = N-1;

            int t;
            while (true)
            {
                t = -1;
                if (BOUND != 0)
                {
                    for (int j = 0; j < BOUND; ++j)
                    {
                        if (result[j].Key > result[j + 1].Key)
                        {
                            result.Swap(j, j + 1);
                            t = j;
                        }
                    }
                }
                if (t == -1)
                {
                    break;
                }
                BOUND = t;
            }
            */
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
        public static List<KeyValuePair<int, string>> SortAlgorithm11(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
    }  
 }
