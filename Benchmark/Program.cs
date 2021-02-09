using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark
{

    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            _ = BenchmarkRunner.Run(typeof(StringConcatenation));
            _ = BenchmarkRunner.Run(typeof(StringConcatenation64));
            _ = BenchmarkRunner.Run(typeof(StringConcatenation256));
            _ = BenchmarkRunner.Run(typeof(StringJob));
#else
            _ = BenchmarkRunner.Run(typeof(StringJob));
           // _ = BenchmarkRunner.Run(typeof(StringBuilderJob));
#endif
        }
    }

    public class Config : ManualConfig
    {
        public Config()
        {
            _ = this.AddExporter(CsvMeasurementsExporter.Default);
            _ = this.AddExporter(RPlotExporter.Default);
        }
    }
}
