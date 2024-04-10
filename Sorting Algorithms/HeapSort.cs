using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A heap sort implementation.
    /// </summary>
    public class HeapSort<T> : ISortable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Time complexity: O(nlog(n)).
        /// </summary>
        public void Sort(ref List<T> collection)
        {
            //heapify
            var heap = new BHeap<T>(collection);

            //now extract min until empty and return them as sorted array
            var sortedArray = new T[collection.Count];
            var j = 0;
            while (heap.Count > 0)
            {
                sortedArray[j] = heap.Extract();
                j++;
            }

            collection = sortedArray.ToList();

            //return sortedArray;
        }
    }
}
