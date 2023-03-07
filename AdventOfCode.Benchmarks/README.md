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
BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1265/22H2/2022Update/SunValley2)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=8.0.100-preview.1.23115.2
  [Host]     : .NET 8.0.0 (8.0.23.11008), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.11008), X64 RyuJIT AVX2


|               Method |         Mean |      Error |     StdDev |       Median | Allocated |
|--------------------- |-------------:|-----------:|-----------:|-------------:|----------:|
|        Year2022_Day1 |    26.937 us |  0.1765 us |  0.1564 us |    26.998 us |         - |
|        Year2022_Day2 |    33.890 us |  0.3018 us |  0.2675 us |    33.914 us |         - |
|  Year2022_Day3_Part1 |    19.700 us |  0.3850 us |  0.7418 us |    19.732 us |         - |
|  Year2022_Day3_Part2 |    33.458 us |  0.4999 us |  0.4676 us |    33.584 us |         - |
|        Year2022_Day4 |    45.894 us |  0.9138 us |  2.4862 us |    46.840 us |         - |
|  Year2022_Day5_Part1 |    28.481 us |  0.2869 us |  0.2683 us |    28.519 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day5_Part2 |    29.917 us |  0.3231 us |  0.3022 us |    30.056 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day6_Part1 |     1.853 us |  0.0233 us |  0.0218 us |     1.850 us |         - |
|  Year2022_Day6_Part2 |    10.924 us |  0.2982 us |  0.8792 us |    11.223 us |         - |
|        Year2022_Day7 |    17.302 us |  0.1716 us |  0.1606 us |    17.336 us |         - |
|        Year2022_Day8 |   442.889 us |  2.8350 us |  2.2134 us |   442.169 us |         - |
|  Year2022_Day9_Part1 |   994.222 us | 15.9231 us | 14.8945 us |   997.000 us |         - |
|  Year2022_Day9_Part2 |   835.492 us | 15.4591 us | 14.4604 us |   825.766 us |         - |
|       Year2022_Day10 |     1.927 us |  0.0108 us |  0.0101 us |     1.859 us |     504 B | // result had to be allocated, nothing else was allocated
| Year2022_Day11_Part1 |     3.124 us |  0.0487 us |  0.0455 us |     3.124 us |         - |
| Year2022_Day11_Part2 | 2,694.718 us | 35.1274 us | 32.8582 us | 2,676.343 us |         - |
| Year2022_Day12_Part1 |    74.245 us |  1.4490 us |  1.8841 us |    74.646 us |         - |
| Year2022_Day12_Part2 |    55.356 us |  1.0897 us |  1.9925 us |    55.826 us |         - |

```
