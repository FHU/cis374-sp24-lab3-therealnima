using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A bucket sort implementation.
    /// </summary>
    public class BucketSort : ISortableInt
    {
        /// <summary>
        /// Sort given integers using bucket sort 
        /// </summary>
        public int[] Sort(int[] array)
        {
            if (array == null || array.Length <= 1)
            {
                return array;
            }
            int maxValue = array[0];
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }
            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (bucket[array[i] - minValue] == null)
                {
                    bucket[array[i] - minValue] = new LinkedList<int>();
                }
                bucket[array[i] - minValue].AddLast(array[i]);
            }
            var index = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First;
                    while (node != null)
                    {
                        array[index] = node.Value;
                        node = node.Next;
                        index++;
                    }
                }
            }

            return array;
        }

    }
}
