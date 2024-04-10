using System;
using System.Collections.Generic;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A quick sort implementation.
    /// </summary>
    public class QuickSort<T> : ISortable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Time complexity: worst case - O(n^2), average case - O(n * log(n))
        /// </summary>
        public void Sort(ref List<T> array)
        {
            if (array.Count <= 1)
            {
                //return array;
                return;
            }

            var comparer = new CustomComparer<T>(SortDirection.Ascending, Comparer<T>.Default);

            sort(array, 0, array.Count - 1, comparer);

            //return array;
        }

        private void sort(List<T> array, int startIndex, int endIndex, CustomComparer<T> comparer)
        {
            while (true)
            {
                //if only one element the do nothing
                if (startIndex < 0 || endIndex < 0 || endIndex - startIndex < 1)
                {
                    return;
                }

                //set the wall to the left most index
                var wall = startIndex;

                // move middle element to end
                var pivotIndex = (startIndex + endIndex) / 2;
                var temp = array[pivotIndex];
                array[pivotIndex] = array[endIndex];
                array[endIndex] = temp;

                //pick last index element on array as comparison pivot
                var pivot = array[endIndex];

                //swap elements greater than pivot to the right side of wall
                //others will be on left
                for (var j = wall; j <= endIndex; j++)
                {
                    if (comparer.Compare(pivot, array[j]) <= 0 && j != endIndex)
                    {
                        continue;
                    }

                    temp = array[wall];
                    array[wall] = array[j];
                    array[j] = temp;
                    //increment to exclude the minimum element in subsequent comparisons
                    wall++;
                }

                //sort left
                sort(array, startIndex, wall - 2, comparer);
                //sort right
                startIndex = wall;
            }
        }
    }
}
