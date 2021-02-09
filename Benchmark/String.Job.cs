using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    /// <summary>
    /// Benchmarks techniques for string concantenation in C#.
    /// </summary>
    /// <remarks>The C# developer concatenates five small strings.</remarks>
    [SimpleJob(runtimeMoniker: RuntimeMoniker.NetCoreApp50, baseline: true)]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.NetCoreApp22)] 
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    [RPlotExporter]
    public class StringJob
    {
        public string Data1 { get; set; }

        public string Data2 { get; set; }

        public string Data3 { get; set; }

        public string Data4 { get; set; }

        public string Data5 { get; set; }

        public StringJob()
        {
            String[] data = Data.GetData(DataTypes.Bit256);

            Data1 = data[0];
            Data2 = data[1];
            Data3 = data[2];
            Data4 = data[3];
            Data5 = data[4];
        }

        public StringJob(DataTypes dt)
        {
            String[] data = Data.GetData(dt);

            Data1 = data[0];
            Data2 = data[1];
            Data3 = data[2];
            Data4 = data[3];
            Data5 = data[4];
        }

        //[Benchmark]
        public string StringConcatenate()
        {
            return string.Concat(Data1, " ", Data2, " ", Data3, " ", Data4, " ", Data5);
        }

        //[Benchmark]
        public string StringJoin()
        {
            return string.Join(" ", Data1, Data2, Data3, Data4, Data5);
        }

        [Benchmark]
        public string StringBuilder()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Data1);
            builder.Append(' ');
            builder.Append(Data2);
            builder.Append(' ');
            builder.Append(Data3);
            builder.Append(' ');
            builder.Append(Data4);
            builder.Append(' ');
            builder.Append(Data5);
            return builder.ToString();
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            // Disposing logic
            Data1 = string.Empty;
            Data2 = string.Empty;
            Data3 = string.Empty;
            Data4 = string.Empty;
            Data5 = string.Empty;
        }
    }
}
