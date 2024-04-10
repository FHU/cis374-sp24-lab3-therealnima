using System;
using System.Collections.Generic;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// An insertion sort implementation.
    /// </summary>
    public class InsertionSort<T> : ISortable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Time complexity: O(n^2).
        /// </summary>
        public void Sort(ref List<T> array)
        {
            var comparer = new CustomComparer<T>(SortDirection.Ascending, Comparer<T>.Default);

            for (int i = 0; i < array.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (comparer.Compare(array[j], array[j - 1]) < 0)
                    {
                        var temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //return array;
        }
    }
}
