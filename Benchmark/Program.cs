using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark
{
    /// <summary>
    /// Benchmarks techniques for string concantenation in C#.
    /// </summary>
    /// <remarks>The C# developer concatenates five small strings.</remarks>
    // [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 0, targetCount: 5)]
    [MemoryDiagnoser] 
    public class StringConcatenation
    {
        public string Data1 { get; set; }

        public string Data2 { get; set; }

        public string Data3 { get; set; }

        public string Data4 { get; set; }

        public string Data5 { get; set; }

        public StringConcatenation()
        {
            Data1 = "a";
            Data2 = "b";
            Data3 = "c";
            Data4 = "d";
            Data5 = "e";
            //Data1 = "5266556A586E3272357538782F413F442A472D4B6150645367566B5970337336";
            //Data2 = "404D635166546A576E5A7234753778214125432A462D4A614E645267556B5870";
            //Data3 = "4528482B4D6251655468576D5A7134743777217A25432646294A404E63526655";
            //Data4 = "2F413F4428472B4B6250655368566D597133743677397A244326452948404D63";
            //Data5 = "7538782F4125442A472D4B6150645367566B5970337336763979244226452848";
        }

        [Benchmark]
        public string Interpolation()
        {
            return $"test formatting {Data1} {Data2} {Data3} {Data4} {Data5}";
        }

        [Benchmark]
        public string InterpolationLambda() => $"test formatting {Data1} {Data2} {Data3} {Data4} {Data5}";
        
        [Benchmark]
        public string InterpolationSingle()
        {
            var result = $"test formatting {Data1} {Data2} {Data3} {Data4} {Data5}";
            return result; 
        }

        [Benchmark]
        public string Operator()
        {
            return Data1 + " " + Data2 + " " + Data3 + " " + Data4 + " " + Data5;
        }

        [Benchmark]
        public string OperatorSingle()
        {
            var result = Data1 + " " + Data2 + " " + Data3 + " " + Data4 + " " + Data5 + " ";
            return result;
        }

        [Benchmark]
        public string OperatorMultiple()
        {
            var result = Data1 + " ";
            result += Data2 + " ";
            result += Data3 + " ";
            result += Data4 + " ";
            result += Data5 + " ";
            return result;
        }

        [Benchmark]
        public string OperatorToString() => 
                            Data1.ToString() + " "
                          + Data2.ToString() + " "
                          + Data3.ToString() + " "
                          + Data4.ToString() + " "
                          + Data5.ToString();

        [Benchmark]
        public string StringConcatenate()
        {
            return string.Concat(Data1, " ", Data2, " ", Data3, " ", Data4, " ", Data5);
        }

        [Benchmark]
        public string StringConcatenateLambda() => Data1 + " " + Data2 + " " + Data3 + " " + Data4 + " " + Data5;

        [Benchmark]
        public string StringJoin()
        {
            return string.Join(" ", Data1, Data2, Data3, Data4, Data5);
        }

        [Benchmark]
        public string StringFormat()
        {
            return string.Format("{0} {1} {2} {3} {4}", Data1, Data2, Data3, Data4, Data5);
        }

        [Benchmark]
        public string StringBuilderAppend()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Data1);
            builder.Append(" ");
            builder.Append(Data2);
            builder.Append(" ");
            builder.Append(Data3);
            builder.Append(" ");
            builder.Append(Data4);
            builder.Append(" ");
            builder.Append(Data5);
            return builder.ToString();
        }

        [Benchmark]
        public string StringBuilderAppendChar()
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

        [Benchmark]
        public string StringBuilderAppendJoin()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendJoin(" ", Data1);
            builder.AppendJoin(" ", Data2);
            builder.AppendJoin(" ", Data3);
            builder.AppendJoin(" ", Data4);
            builder.AppendJoin(" ", Data5);
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

    public class Program
    {
        public static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
