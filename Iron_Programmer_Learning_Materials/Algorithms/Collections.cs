using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class Collections
    {
        /// <summary>
        /// Mixes the list of unique elements, so that no element of the list will not be in the same place
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Specified list</param>
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

        /// <summary>
        /// Swap two list item at the specified index 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Specified list</param>
        /// <param name="index1">First Index</param>
        /// <param name="index2">Second Index</param>
        public static void Swap<T>(this IList<T> list, int index1, int index2)
        {
            T c = list[index1];
            list[index1] = list[index2];
            list[index2] = c;
        }
    }
}
