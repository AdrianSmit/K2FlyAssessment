using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using K2FlyAssessment.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2FlyAssessment.Benchmark
{
    [RankColumn]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ParserBenchmark
    {
        private static readonly Functions functions = new Functions();

        [Benchmark]
        public void RotateSun()
        {
            functions.RotateSun();
        }
    }
}
