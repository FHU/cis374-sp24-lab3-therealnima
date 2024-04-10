using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A radix sort implementation.
    /// </summary>
    public class RadixSort: ISortableInt
    {
        public int[] Sort(int[] array)
        {
            int i;
            for (i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    throw new System.Exception("Negative numbers not supported.");
                }
            }

            var @base = 1;
            var max = array.Max();


            while (max / @base > 0)
            {
                //create a bucket for digits 0 to 9
                var buckets = new List<int>[10];

                for (i = 0; i < array.Length; i++)
                {
                    var bucketIndex = array[i] / @base % 10;

                    if (buckets[bucketIndex] == null)
                    {
                        buckets[bucketIndex] = new List<int>();
                    }

                    buckets[bucketIndex].Add(array[i]);
                }

                //now update array with what is in buckets
                var orderedBuckets = buckets ;

                i = 0;
                foreach (var bucket in orderedBuckets.Where(x => x != null))
                {
                    foreach (var item in bucket)
                    {
                        array[i] = item;
                        i++;
                    }
                }

                @base *= 10;
            }

            return array;
        }

    }
}

