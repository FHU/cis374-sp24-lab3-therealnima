using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Lab3.SortingAlgorithms;

namespace Lab3
{
    public enum OrderingType { Random, Reversed, NearlySorted}

    [MemoryDiagnoser]
    [ShortRunJob]
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter]
    public class SortingBenchmarks
	{
        [Params(100, 1000, 10_000)]
        public int N;

        [Params(OrderingType.Random, OrderingType.Reversed, OrderingType.NearlySorted)]
        public OrderingType orderingType;

        private List<int> list;

        private int[] array;

        [GlobalSetup]
        public void Setup()
        {

        }

        [IterationSetup]
        public void InterationSetup()
        {
            list = GenerateRandomIntList(N, N/2);

            switch (orderingType)
            {
                case OrderingType.Random:
                    array = list.ToArray();
                    return;
                case OrderingType.Reversed:
                    list.Sort();
                    list.Reverse();

                    array = list.ToArray();
                    return;
                case OrderingType.NearlySorted:
                    list.Sort();

                    Random random = new Random();
                    // swap 5% of elements 
                    for (int i=0; i < 0.025*list.Count; i++)
                    {
                        int index1 = random.Next() % list.Count;
                        int index2 = random.Next() % list.Count;

                        Swap(list, index1, index2);
                    }

                    array = list.ToArray();
                    return;

            }
        }

        private void Swap(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        [Benchmark]
        public void BubbleSort()
        {
            BubbleSort<int> bubbleSort = new BubbleSort<int>();

            bubbleSort.Sort(ref list);
        }

        [Benchmark]
        public void InsertionSort()
        {
            InsertionSort<int> insertionSort = new InsertionSort<int>();

            insertionSort.Sort(ref list);
        }


        [Benchmark]
        public void RadixSort()
        {
            RadixSort radixSort = new RadixSort();

            radixSort.Sort( array );
        }


        private List<int> GenerateRandomIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.Next(maxValue));
            }

            return list;
        }

    }
}

