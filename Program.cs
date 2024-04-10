using BenchmarkDotNet.Running;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SortingBenchmarks>();
        }
    }
}
