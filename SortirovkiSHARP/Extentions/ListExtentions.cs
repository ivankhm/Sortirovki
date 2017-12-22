using System;
using System.Collections.Generic;

namespace SortirovkiSHARP.Extentions
{
    static class ListExtentions
    {
        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static int GetBit(int bits, int index, int m)
        {
            return (bits >> (m-index)) & 1;
        }
    }
}
