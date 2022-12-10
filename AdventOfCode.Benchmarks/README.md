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


|              Method |     Mean |    Error |   StdDev | Allocated |
|-------------------- |---------:|---------:|---------:|----------:|
| Year2021_Day1_Part1 | 39.84 us | 0.795 us | 0.743 us |         - |
| Year2021_Day1_Part2 | 47.56 us | 0.582 us | 0.486 us |         - |
| Year2021_Day2_Part1 | 10.82 us | 0.070 us | 0.066 us |         - |
| Year2021_Day2_Part2 | 10.89 us | 0.127 us | 0.118 us |         - |
```

## 2022

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


|              Method |       Mean |     Error |    StdDev | Allocated |
|-------------------- |-----------:|----------:|----------:|----------:|
|       Year2022_Day1 |  41.914 us | 0.3472 us | 0.2711 us |         - |
|       Year2022_Day2 |   52.27 us | 0.4390 us | 0.3890 us |         - |
| Year2022_Day3_Part1 |   22.29 us | 0.3750 us | 0.4010 us |         - |
| Year2022_Day3_Part2 |   42.81 us | 0.2360 us | 0.2210 us |         - |
|       Year2022_Day4 |   68.43 us | 0.5140 us | 0.4810 us |         - |
| Year2022_Day5_Part1 |  37.860 us | 0.2379 us | 0.2225 us |      40 B |
| Year2022_Day5_Part2 |  40.075 us | 0.2416 us | 0.2142 us |      40 B |
| Year2022_Day6_Part1 |   3.693 us | 0.0329 us | 0.0307 us |         - |
| Year2022_Day6_Part2 |  15.900 us | 0.3180 us | 0.3900 us |         - |
|       Year2022_Day7 |  24.487 us | 0.1667 us | 0.1478 us |         - |
|       Year2022_Day8 | 715.106 us | 3.5306 us | 3.1298 us |         - |
```
