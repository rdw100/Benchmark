﻿using BenchmarkDotNet.Attributes;
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
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    [RPlotExporter]
    public class StringConcatenation
    {
        public string Data1 { get; set; }

        public string Data2 { get; set; }

        public string Data3 { get; set; }

        public string Data4 { get; set; }

        public string Data5 { get; set; }

        public StringConcatenation()
        {
            String[] data = Data.GetData(DataTypes.Char1);

            Data1 = data[0];
            Data2 = data[1];
            Data3 = data[2];
            Data4 = data[3];
            Data5 = data[4];
        }

        public StringConcatenation(DataTypes dt)
        {
            String[] data = Data.GetData(dt);

            Data1 = data[0];
            Data2 = data[1];
            Data3 = data[2];
            Data4 = data[3];
            Data5 = data[4];
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
        public string StringBuilderInit()
        {
            StringBuilder builder = new StringBuilder(Data1 + " " + Data2 + " " + Data3 + " " + Data4 + " " + Data5);
            return builder.ToString(); 
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
        public string StringBuilderAppendCapacity()
        {
            StringBuilder builder = new StringBuilder(9);
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
}
