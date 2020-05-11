using BenchmarkDotNet.Running;
using System;

namespace GraphyteBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BinarySearchTreeBenchmarks>();
        }
    }
}
