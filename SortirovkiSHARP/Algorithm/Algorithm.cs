using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            for(int i = 0; i < N; ++i)
            {
                result[count[i]] = mass[i];
            }

            return result;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm2(this IList<KeyValuePair<int, string>> mass)
        {
           
            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm3(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm4(this IList<KeyValuePair<int, string>> mass)
        {

            return null;
        }
        public static List<KeyValuePair<int, string>> SortAlgorithm5(this IList<KeyValuePair<int, string>> mass)
        {

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
