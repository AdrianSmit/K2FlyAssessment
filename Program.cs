using BenchmarkDotNet.Running;
using K2FlyAssessment.Benchmark;
using System;

namespace K2FlyAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run Benchmarks prior to running the application.
            BenchmarkRunner.Run<ParserBenchmark>();
        }
    }
}
