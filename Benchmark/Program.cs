using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark
{
    [RPlotExporter]
    public class Program
    {
        public static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run(typeof(StringConcatenation));
            //_ = BenchmarkRunner.Run(typeof(StringConcatenation64));
            //_ = BenchmarkRunner.Run(typeof(StringConcatenation256));
        }
    }
}
