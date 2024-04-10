using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Helpers;

namespace Lab3.SortingAlgorithms
{
    /// <summary>
    /// A tree sort implementation.
    /// NOTE: This algorithm requires all elements be unique!
    /// </summary>
    public class TreeSort<T>: ISortable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Time complexity: O(nlog(n)).
        /// </summary>
        public void Sort(ref List<T> array)
        {
            //create BST
            var tree = new RedBlackTree<T>();
            foreach (var item in array)
            {
                tree.Insert(item);
            }

            array = tree.AsEnumerable().ToList();
        }
    }
}
