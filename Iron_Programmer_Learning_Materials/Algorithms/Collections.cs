using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class Collections
    {
        public static void Shiffle<T>(this IList<T> list)
        {
            var random = new Random();
            int maxIndex = list.Count - 1;

            for (int i = 0; i < maxIndex; i++)
            {
                int rightIndex = maxIndex - i;
                int leftIndex = random.Next(0, rightIndex);

                list.Swap(leftIndex, rightIndex);
            }
        }

        public static void Swap<T>(this IList<T> list, int index1, int index2)
        {
            T c = list[index1];
            list[index1] = list[index2];
            list[index2] = c;
        }
    }
}
