# Benchmark
The Benchmark demonstration project was created using Visual Studio 2019 16.8.4, .NET 5, & Benchmark.Net v0.12.1. The objective is to demonstrate Benchmark.Net in a .NET 5 application using String and StringBuilder concatenation.

## Prerequisites
Additional steps for running RPlotExporter in a Benchmark.Net Visual Studio solution on a Windows machine.

Set Environment Variable (System variable)
- Variable name:  R_HOME
- Variable value: C:\Program Files\R\R-4.0.3

Install Perl on Windows (32-bit & 64-bit) 
https://learn.perl.org/installing/windows.html

Download R (Choose Mirror)
https://www.r-project.org/

## Setup
Setup instructions to run this project are as follows:

1. Download Benchmark project and open it in Visual Studio 2019.

2. Set Solution Configuration to Release.

3. Start Debugging

## Summary
The Benchmark scenarios 1-3 below evaluate the best use of either String or String Builder for small to large concatenation scenarios.  Benchmarks 4-5 evaluate .NET Core performance for only StringBuilder and String.

Performance is relative to ***your*** environment.  Each run produces a result.

Single Framework Target

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1316 (1909/November2018Update/19H2)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
```

Multiple Framework Targets

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1316 (1909/November2018Update/19H2)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.102
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT  [AttachedDebugger]
  .NET Core 2.2 : .NET Core 2.2.8 (CoreCLR 4.6.28207.03, CoreFX 4.6.28208.02), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
```

### Benchmark 1 (String Concatenation)
The C# developer concatenates five small strings:  "a", "b", "c", "d", "e".

```
|                      Method |      Mean |    Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----------:|---------:|----------:|----------:|-------:|------:|------:|----------:|
|               Interpolation | 135.82 ns | 6.594 ns | 19.234 ns | 129.21 ns | 0.0560 |     - |     - |     176 B |
|         InterpolationLambda | 138.12 ns | 2.860 ns |  5.579 ns | 137.21 ns | 0.0560 |     - |     - |     176 B |
|         InterpolationSingle | 131.23 ns | 2.648 ns |  3.881 ns | 131.64 ns | 0.0560 |     - |     - |     176 B |
|                    Operator | 116.78 ns | 2.432 ns |  2.987 ns | 116.45 ns | 0.0432 |     - |     - |     136 B |
|              OperatorSingle | 127.94 ns | 2.025 ns |  1.795 ns | 128.34 ns | 0.0484 |     - |     - |     152 B |
|            OperatorMultiple | 136.56 ns | 2.771 ns |  4.706 ns | 135.85 ns | 0.0610 |     - |     - |     192 B |
|            OperatorToString | 123.85 ns | 2.562 ns |  6.926 ns | 123.35 ns | 0.0432 |     - |     - |     136 B |
|           StringConcatenate | 119.75 ns | 2.408 ns |  5.581 ns | 119.59 ns | 0.0432 |     - |     - |     136 B |
|     StringConcatenateLambda | 111.07 ns | 2.271 ns |  2.954 ns | 110.41 ns | 0.0433 |     - |     - |     136 B |
|                  StringJoin |  82.90 ns | 1.744 ns |  3.717 ns |  83.03 ns | 0.0331 |     - |     - |     104 B |
|                StringFormat | 233.64 ns | 6.934 ns | 20.117 ns | 228.08 ns | 0.0329 |     - |     - |     104 B |
|           StringBuilderInit | 170.16 ns | 3.481 ns |  7.714 ns | 170.05 ns | 0.0892 |     - |     - |     280 B |
|         StringBuilderAppend |  73.62 ns | 1.570 ns |  4.554 ns |  72.81 ns | 0.0459 |     - |     - |     144 B |
|     StringBuilderAppendChar |  64.14 ns | 1.367 ns |  1.824 ns |  63.34 ns | 0.0459 |     - |     - |     144 B |
| StringBuilderAppendCapacity |  83.71 ns | 1.770 ns |  3.282 ns |  83.90 ns | 0.0433 |     - |     - |     136 B |
|     StringBuilderAppendJoin | 142.85 ns | 2.947 ns |  2.757 ns | 143.79 ns | 0.0942 |     - |     - |     296 B |
```
<p>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringConcatenation-barplot.png" alt="BarPlot" width="150" height="150"/>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringConcatenation-boxplot.png" alt="BoxPlot" width="150" height="150"/>
</p>

Conclusion:  The results show StringBuilder is best for concatenating strings in this scenario.

### Benchmark 2 (String Concatenation 64)
The C# developer concatenates five 64-bit hexadecimal strings:  "217A25432A462D4A", "743677397A244326", "5971337436763979", "67566B5970337336", "4E645267556B5870".

```
|        Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
|  StringConcat | 110.08 ns |  2.243 ns |  2.493 ns | 109.78 ns | 0.0918 |     - |     - |     288 B |
|    StringJoin |  87.30 ns |  1.765 ns |  1.888 ns |  87.27 ns | 0.0815 |     - |     - |     256 B |
| StringBuilder | 191.40 ns |  3.886 ns |  8.448 ns | 187.74 ns | 0.2294 |     - |     - |     720 B |
|       SB_Char | 304.08 ns | 15.164 ns | 44.711 ns | 304.60 ns | 0.2346 |     - |     - |     736 B |
|   SB_Capacity | 157.65 ns |  4.886 ns | 13.941 ns | 151.95 ns | 0.2906 |     - |     - |     912 B |
```
<p>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringConcatenation64-barplot.png" alt="BarPlot" width="150" height="150"/>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringConcatenation64-boxplot.png" alt="BoxPlot" width="150" height="150"/>
</p>

Conclusion:  The results show StringJoin is best for concatenating strings in this scenario.

### Benchmark 3 (String Concatenation 256)
The C# developer concatenates five 256-bit hexadecimal strings:  "5266556A586E3272357538782F413F442A472D4B6150645367566B5970337336", "404D635166546A576E5A7234753778214125432A462D4A614E645267556B5870", "4528482B4D6251655468576D5A7134743777217A25432646294A404E63526655", "2F413F4428472B4B6250655368566D597133743677397A244326452948404D63", "7538782F4125442A472D4B6150645367566B5970337336763979244226452848".

```
|        Method |     Mean |   Error |   StdDev |   Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |---------:|--------:|---------:|---------:|-------:|------:|------:|----------:|
|    StringJoin | 139.2 ns | 2.80 ns |  4.43 ns | 138.8 ns | 0.2346 |     - |     - |     736 B |
| StringBuilder | 362.6 ns | 8.33 ns | 23.91 ns | 355.2 ns | 0.6881 |     - |     - |    2160 B |
```
<p>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringConcatenation256-barplot.png" alt="BarPlot" width="150" height="150"/>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringConcatenation256-boxplot.png" alt="BoxPlot" width="150" height="150"/>
</p>

Conclusion:  The results show StringJoin is best for concatenating strings in this scenario.

### Benchmark 4 (.NET Core 2.2/3.1/5.0)
The C# developer concatenates five small strings:  "a", "b", "c", "d", "e".

```
|        Method |           Job |       Runtime |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |-------------- |-------------- |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
| StringBuilder | .NET Core 2.2 | .NET Core 2.2 | 73.82 ns | 2.753 ns | 7.855 ns |  1.05 |    0.13 | 0.0483 |     - |     - |     152 B |
| StringBuilder | .NET Core 3.1 | .NET Core 3.1 | 73.12 ns | 3.010 ns | 8.734 ns |  1.04 |    0.15 | 0.0459 |     - |     - |     144 B |
| StringBuilder | .NET Core 5.0 | .NET Core 5.0 | 70.68 ns | 2.235 ns | 6.555 ns |  1.00 |    0.00 | 0.0458 |     - |     - |     144 B |
```
<p>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringBuilderJob-barplot.png" alt="BarPlot" width="150" height="150"/>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringBuilderJob-boxplot.png" alt="BoxPlot" width="150" height="150"/>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringBuilderJob-StringBuilder-cummean.png" alt="Cummean" width="150" height="150"/>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringBuilderJob-StringBuilder-density.png" alt="Density" width="150" height="150"/>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringBuilderJob-StringBuilder-facetTimelineSmooth.png" alt="Timeline" width="150" height="150"/> 
</p>

Conclusion: The results show .NET Core 5.0 is the best runtime in this scenario.

### Benchmark 5 (.NET Core 2.2/3.1/5.0)
The C# developer concatenates five 256-bit hexadecimal strings:  "5266556A586E3272357538782F413F442A472D4B6150645367566B5970337336", "404D635166546A576E5A7234753778214125432A462D4A614E645267556B5870", "4528482B4D6251655468576D5A7134743777217A25432646294A404E63526655", "2F413F4428472B4B6250655368566D597133743677397A244326452948404D63", "7538782F4125442A472D4B6150645367566B5970337336763979244226452848".

```
|     Method |           Job |       Runtime |     Mean |   Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |-------------- |-------------- |---------:|--------:|---------:|------:|--------:|-------:|------:|------:|----------:|
| StringJoin | .NET Core 2.2 | .NET Core 2.2 | 211.0 ns | 5.10 ns | 14.86 ns |  1.32 |    0.12 | 0.2363 |     - |     - |     744 B |
| StringJoin | .NET Core 3.1 | .NET Core 3.1 | 183.8 ns | 5.36 ns | 15.55 ns |  1.17 |    0.11 | 0.2346 |     - |     - |     736 B |
| StringJoin | .NET Core 5.0 | .NET Core 5.0 | 159.1 ns | 3.27 ns |  8.67 ns |  1.00 |    0.00 | 0.2346 |     - |     - |     736 B |
```
<p>
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringJob-barplot.png" alt="BarPlot" width="150" height="150">
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringJob-boxplot.png" alt="BoxPlot" width="150" height="150">
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringJob-StringJoin-cummean.png" alt="Cummean" width="150" height="150">
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringJob-StringJoin-density.png" alt="Density" width="150" height="150">
<img src="https://github.com/rdw100/Benchmark/blob/master/Benchmark/img/Benchmark.StringJob-StringJoin-facetTimelineSmooth.png" alt="Timeline" width="150" height="150"> 
</p>

Conclusion: The results show .NET Core 5.0 is the best runtime in this scenario.
