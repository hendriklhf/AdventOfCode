# Advent of Code - Benchmarks

- [2021](#2021)
- [2022](#2022)

## 2021

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


|              Method |      Mean |     Error |    StdDev | Allocated |
|-------------------- |----------:|----------:|----------:|----------:|
| Year2021_Day1_Part1 | 36.598 us | 0.3244 us | 0.3035 us |         - |
| Year2021_Day1_Part2 | 42.372 us | 0.3427 us | 0.3038 us |         - |
| Year2021_Day2_Part1 |  9.868 us | 0.0661 us | 0.0586 us |         - |
| Year2021_Day2_Part2 |  9.863 us | 0.1118 us | 0.1046 us |         - |
```

## 2022

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2


|               Method |         Mean |      Error |     StdDev |       Median | Allocated |
|--------------------- |-------------:|-----------:|-----------:|-------------:|----------:|
|        Year2022_Day1 |    27.456 us |  0.5058 us |  0.4731 us |    27.233 us |         - |
|        Year2022_Day2 |    32.090 us |  0.6394 us |  0.9765 us |    31.518 us |         - |
|  Year2022_Day3_Part1 |    19.495 us |  0.3802 us |  0.6658 us |    19.748 us |         - |
|  Year2022_Day3_Part2 |    31.725 us |  0.6107 us |  0.7033 us |    31.709 us |         - |
|        Year2022_Day4 |    39.980 us |  0.9935 us |  2.9292 us |    39.865 us |         - |
|  Year2022_Day5_Part1 |    29.480 us |  0.2109 us |  0.1973 us |    29.398 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day5_Part2 |    30.852 us |  0.3962 us |  0.3512 us |    30.725 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day6_Part1 |     1.842 us |  0.0320 us |  0.0284 us |     1.845 us |         - |
|  Year2022_Day6_Part2 |    11.860 us |  0.2371 us |  0.6650 us |    12.054 us |         - |
|        Year2022_Day7 |    16.904 us |  0.2265 us |  0.2118 us |    16.938 us |         - |
|        Year2022_Day8 |   452.205 us |  8.8949 us | 10.9237 us |   448.396 us |         - |
|  Year2022_Day9_Part1 | 1,267.382 us | 23.2760 us | 21.7724 us | 1,257.721 us |       1 B |
|  Year2022_Day9_Part2 |   824.058 us | 13.7397 us | 12.8521 us |   819.457 us |         - |
|       Year2022_Day10 |     1.893 us |  0.0244 us |  0.0228 us |     1.878 us |     504 B | // result had to be allocated, nothing else was allocated
| Year2022_Day11_Part1 |     3.167 us |  0.0629 us |  0.0588 us |     3.167 us |         - |
| Year2022_Day11_Part2 | 2,654.607 us | 32.4114 us | 30.3177 us | 2,642.265 us |       2 B |
| Year2022_Day12_Part1 |    77.040 us |  1.4896 us |  1.6556 us |    77.476 us |         - |
| Year2022_Day12_Part2 |    58.515 us |  0.9916 us |  1.0183 us |    58.179 us |         - |
```
