using System;
using System.Collections.Generic;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A shell sort implementation.
    /// </summary>
    public class ShellSort<T> : ISortable<T> where T : IComparable<T>
    {
        public void Sort(ref List<T> array)
        {
            var comparer = new CustomComparer<T>(SortDirection.Ascending, Comparer<T>.Default);

            var k = array.Count / 2;
            var j = 0;

            while (k >= 1)
            {
                for (int i = k; i < array.Count; i = i + k, j = j + k)
                {
                    if (comparer.Compare(array[i], array[j]) >= 0)
                    {
                        continue;
                    }

                    swap(array, i, j);

                    if (i <= k)
                    {
                        continue;
                    }

                    i -= k * 2;
                    j -= k * 2;
                }

                j = 0;
                k /= 2;
            }

            //return array;
        }

        private static void swap(List<T> array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
