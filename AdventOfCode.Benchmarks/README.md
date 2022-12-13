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
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


|               Method |         Mean |      Error |     StdDev | Allocated |
|--------------------- |-------------:|-----------:|-----------:|----------:|
|        Year2022_Day1 |    39.880 us |  0.3252 us |  0.2883 us |         - |
|        Year2022_Day2 |    47.354 us |  0.1826 us |  0.1708 us |         - |
|  Year2022_Day3_Part1 |    22.104 us |  0.1429 us |  0.1337 us |         - |
|  Year2022_Day3_Part2 |    42.574 us |  0.0839 us |  0.0701 us |         - |
|        Year2022_Day4 |    59.618 us |  0.1821 us |  0.1614 us |         - |
|  Year2022_Day5_Part1 |    37.860 us |  0.2379 us |  0.2225 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day5_Part2 |    40.075 us |  0.2416 us |  0.2142 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day6_Part1 |     2.626 us |  0.0297 us |  0.0278 us |         - |
|  Year2022_Day6_Part2 |    15.018 us |  0.0535 us |  0.0501 us |         - |
|        Year2022_Day7 |    24.039 us |  0.2185 us |  0.2044 us |         - |
|        Year2022_Day8 |   631.180 us |  1.6231 us |  1.5182 us |         - |
|  Year2022_Day9_Part1 | 2,006.148 us |  3.7658 us |  3.3383 us |       2 B |
|  Year2022_Day9_Part2 | 1,237.539 us |  4.7316 us |  3.9511 us |       1 B |
|       Year2022_Day10 |     2.677 us |  0.0165 us |  0.0146 us |     504 B | // result had to be allocated, nothing else was allocated
| Year2022_Day11_Part1 |     4.950 us |  0.0386 us |  0.0361 us |         - |
| Year2022_Day11_Part2 | 4,374.619 us | 10.8779 us | 10.1752 us |       3 B |
```
