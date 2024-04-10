using System;
using System.Collections.Generic;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A bubble sort implementation.
    /// </summary>
    public class BubbleSort<T> : ISortable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Time complexity: O(n^2).
        /// </summary>
        public void Sort(ref List<T> items)
        {
            var swapped = true;

            while (swapped)
            {
                swapped = false;

                for (int i = 0; i < items.Count - 1; i++)
                {
                    //compare adjacent elements 
                    if (items[i].CompareTo(items[i + 1]) > 0)
                    {
                        var temp = items[i];
                        items[i] = items[i + 1];
                        items[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
        }
    }
}
