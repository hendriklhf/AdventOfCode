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
.NET SDK=8.0.100-preview.2.23157.25
  [Host]     : .NET 8.0.0 (8.0.23.12803), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.12803), X64 RyuJIT AVX2


|               Method |         Mean |      Error |     StdDev | Allocated |
|--------------------- |-------------:|-----------:|-----------:|----------:|
|        Year2022_Day1 |    18.620 us |  0.3664 us |  0.3428 us |         - |
|        Year2022_Day2 |    34.966 us |  0.6941 us |  0.7427 us |         - |
|  Year2022_Day3_Part1 |    19.492 us |  0.3418 us |  0.3197 us |         - |
|  Year2022_Day3_Part2 |    32.416 us |  0.6421 us |  0.7885 us |         - |
|        Year2022_Day4 |    22.618 us |  0.4472 us |  0.9531 us |         - |
|  Year2022_Day5_Part1 |    22.990 us |  0.4394 us |  0.4512 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day5_Part2 |    25.255 us |  0.3997 us |  0.3337 us |      40 B | // result had to be allocated, nothing else was allocated
|  Year2022_Day6_Part1 |     1.845 us |  0.0366 us |  0.0695 us |         - |
|  Year2022_Day6_Part2 |    11.512 us |  0.2284 us |  0.2719 us |         - |
|        Year2022_Day7 |    15.749 us |  0.2189 us |  0.2048 us |         - |
|        Year2022_Day8 |   436.668 us |  8.1507 us |  7.6241 us |         - |
|  Year2022_Day9_Part1 | 1,271.150 us |  5.8689 us |  4.9008 us |         - |
|  Year2022_Day9_Part2 |   848.311 us | 15.9847 us | 14.9521 us |         - |
|       Year2022_Day10 |     1.948 us |  0.0277 us |  0.0259 us |     504 B | // result had to be allocated, nothing else was allocated
| Year2022_Day11_Part1 |     3.153 us |  0.0599 us |  0.0588 us |         - |
| Year2022_Day11_Part2 | 2,687.614 us | 42.1421 us | 37.3578 us |         - |
| Year2022_Day12_Part1 |    76.488 us |  1.4029 us |  1.3123 us |         - |
| Year2022_Day12_Part2 |    56.579 us |  0.9823 us |  0.8708 us |         - |


```
