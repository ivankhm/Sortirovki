using System.Collections.Generic;
using System.Linq;
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
            var N = mass.Count;
            var l = 1;
            var r = N;
            var b = 1;
            //var result = Convert.ToString(number, 2);     
            var MyStack = new Stack<int[]>();
            int[] temp = new int[2];
            List<KeyValuePair<int, string>> result_mass = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0075, "Smile"),
                new KeyValuePair<int, string>(0127, "Sweet"),
                new KeyValuePair<int, string>(0232, "Sister"),
                new KeyValuePair<int, string>(0252, "Sadistic"),
                new KeyValuePair<int, string>(0423, "Surprise"),
                new KeyValuePair<int, string>(0652, "Service"),
                new KeyValuePair<int, string>(0767, "We"),
                new KeyValuePair<int, string>(0775, "are"),
                new KeyValuePair<int, string>(1000, "STYLE"),
                new KeyValuePair<int, string>(1444, "!"),
                new KeyValuePair<int, string>(1215, "Error1"),
                new KeyValuePair<int, string>(1245, "Error2"),
                new KeyValuePair<int, string>(1277, "Error3"),
                new KeyValuePair<int, string>(1375, "Error4"),
                new KeyValuePair<int, string>(1601, "Error5"),
                new KeyValuePair<int, string>(1614, "Error6")
            };

            do
            {
                if (l == r)
                {
                    var i = l;
                    var j = r;
                    do
                    {
                        if (ListExtentions.GetBit(result_mass[i].Key, b) == 1)
                        {
                            j--;
                            if (i <= j)
                            {
                                if (ListExtentions.GetBit(result_mass[j + 1].Key, b) == 0) R7

                            }
                        }
                        i++;
                    } while (i <= j);
                    if (i <= j)
                }
                else if (MyStack.Count > 0 )
                {
                    l = r + 1;
                    temp = MyStack.Pop();
                    r = temp[0];
                    b = temp[1];
                }
            } while (MyStack.Count > 0);

            return null;
        }

        public static List<KeyValuePair<int, string>> SortAlgorithm6(this IList<KeyValuePair<int, string>> mass)
        {
            var N = mass.Count;
            //var N = 16;
            int l = 1;
            int r = N; 
            int M = 1;
            int[] temp = new int[2];
            var MyStack = new Stack<int[]>();
            List<KeyValuePair<int, string>> result_mass = new List<KeyValuePair<int, string>>();
            result_mass.Clear();
            result_mass.Add(new KeyValuePair<int, string>(-123, "Начало"));

            /* result_mass.Add(new KeyValuePair<int, string>(503, "We"));
             result_mass.Add(new KeyValuePair<int, string>(087, "Sweet"));
             result_mass.Add(new KeyValuePair<int, string>(512, "STYLE"));
             result_mass.Add(new KeyValuePair<int, string>(061, "Smile"));
             result_mass.Add(new KeyValuePair<int, string>(908, "Error5"));
             result_mass.Add(new KeyValuePair<int, string>(170, "Sadistic"));
             result_mass.Add(new KeyValuePair<int, string>(897, "Error4"));
             result_mass.Add(new KeyValuePair<int, string>(275, "Surprise"));
             result_mass.Add(new KeyValuePair<int, string>(653, "Error"));
             result_mass.Add(new KeyValuePair<int, string>(426, "Service"));
             result_mass.Add(new KeyValuePair<int, string>(154, "Sister"));
             result_mass.Add(new KeyValuePair<int, string>(509, "Are"));
             result_mass.Add(new KeyValuePair<int, string>(612, "!"));
             result_mass.Add(new KeyValuePair<int, string>(677, "Error1"));
             result_mass.Add(new KeyValuePair<int, string>(765, "Error3"));
             result_mass.Add(new KeyValuePair<int, string>(703, "Error2"));*/
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
                        //Q6
                        if (i < j) result_mass.Swap(i, j);
                    } while (i < j);
                    //Q5
                    result_mass.Swap(l, j);
                    //Q7
                    if ((r - j >= j - l) && (j - l > M))
                    {
                        temp[0] = j + 1;
                        temp[1] = r;
                        MyStack.Push(temp);
                        r = j - 1;
                    }
                    else if ((j - l > r - j) && (r - j > M))
                    {
                        temp[0] = l;
                        temp[1] = j - 1;
                        MyStack.Push(temp);
                        r = j + 1;
                    }
                    else if (r - j >= j - l)
                    {
                        l = j + 1;
                    }
                    if (j - l >= r - j)
                    {
                        r = j - 1;
                    }
                } while (r - l > M);
                //Q8
                if (MyStack.Count != 0)
                {
                    temp = MyStack.Pop();
                    l = temp[0];
                    r = temp[1];
                }
            } while (r-l>0);
            return result_mass;
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
