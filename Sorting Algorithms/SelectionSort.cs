using System;
using System.Collections.Generic;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A selection sort implementation.
    /// </summary>
    public class SelectionSort<T> : ISortable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Time complexity: O(n^2).
        /// </summary>
        public void Sort(ref List<T> array)
        {
            var comparer = new CustomComparer<T>(SortDirection.Ascending, Comparer<T>.Default);

            for (int i = 0; i < array.Count; i++)
            {
                //select the smallest item in sub array and move it to front
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (comparer.Compare(array[j], array[i]) >= 0)
                    {
                        continue;
                    }

                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            //return array;
        }
    }
}
