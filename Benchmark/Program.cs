using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark
{
    //public class Md5VsSha256
    //{
    //    private const int N = 10000;
    //    private readonly byte[] data;

    //    private readonly SHA256 sha256 = SHA256.Create();
    //    private readonly MD5 md5 = MD5.Create();

    //    public Md5VsSha256()
    //    {
    //        data = new byte[N];
    //        new Random(42).NextBytes(data);
    //    }

    //    [Benchmark]
    //    public byte[] Sha256() => sha256.ComputeHash(data);

    //    [Benchmark]
    //    public byte[] Md5() => md5.ComputeHash(data);
    //}

    // [MemoryDiagnoser]    
    /// <summary>
    /// Benchmarks string concantenation in C#
    /// </summary>
    /// <remarks>.NET 5 StringBuilder using Append</remarks>
    // [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 0, targetCount: 5)]
    public class StringConcatenation
    {

        //[Params("a", "5266556A586E3272357538782F413F442A472D4B6150645367566B5970337336")]
        public string Data1 { get; set; }

        //[Params("b", "404D635166546A576E5A7234753778214125432A462D4A614E645267556B5870")]
        public string Data2 { get; set; }

        //[Params("c", "4528482B4D6251655468576D5A7134743777217A25432646294A404E63526655")]
        public string Data3 { get; set; }

        //[Params("d", "2F413F4428472B4B6250655368566D597133743677397A244326452948404D63")]
        public string Data4 { get; set; }

        //[Params("e", "7538782F4125442A472D4B6150645367566B5970337336763979244226452848")]
        public string Data5 { get; set; }

        public StringConcatenation()
        {
            Data1 = "a";
            Data2 = "b";
            Data3 = "c";
            Data4 = "d";
            Data5 = "e";
        }

        [Benchmark]
        public string Interpolation()
        {
            return $"{Data1} {Data2} {Data3} {Data4} {Data5}";
        }

        [Benchmark]
        public string InterpolationSingle()
        {
            var result = $"{Data1} {Data2} {Data3} {Data4} {Data5}";
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

    public class StringMaker 
    {
        public IEnumerable<string> ValuesForData1 => new[] { "a", "b", "c", "d", "e" };
        public IEnumerable<char> ValuesForData2 => new[] { 'a', 'b', 'c', 'd', 'e' };

        public IEnumerable<string> ValuesForData3 => new[] {
            new string(string.Join("", Enumerable.Repeat(0, 100).Select(n => (char)new Random().Next(127)))),
            new string(string.Join("", Enumerable.Repeat(0, 100).Select(n => (char)new Random().Next(127)))),
            new string(string.Join("", Enumerable.Repeat(0, 100).Select(n => (char)new Random().Next(127)))),
            new string(string.Join("", Enumerable.Repeat(0, 100).Select(n => (char)new Random().Next(127)))),
            new string(string.Join("", Enumerable.Repeat(0, 100).Select(n => (char)new Random().Next(127))))
        };

        public IEnumerable<string> ValuesForData4 => new[]
        {
            "442A472D4B6150645367566B59703373367638792F423F4528482B4D62516554",
            "217A25432A462D4A614E645267556B58703273357638782F413F4428472B4B62",
            "743677397A24432646294A404E635266556A586E327235753878214125442A47",
            "5971337436763979244226452948404D635166546A576E5A7234753778217A25",
            "67566B59703373357638792F423F4528482B4D6251655468576D5A7134743777"
        };

        public StringMaker()
        {

        }

        public string Get128Key()
        {
            string key = new string(string.Join("", Enumerable.Repeat(0, 100).Select(n => (char)new Random().Next(127))));
            return key;
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
