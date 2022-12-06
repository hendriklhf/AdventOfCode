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


|              Method |     Mean |    Error |   StdDev | Allocated |
|-------------------- |---------:|---------:|---------:|----------:|
|       Year2022_Day1 | 42.06 us | 0.373 us | 0.292 us |         - |
|       Year2022_Day2 | 52.27 us | 0.439 us | 0.389 us |         - |
| Year2022_Day3_Part1 | 22.29 us | 0.375 us | 0.401 us |         - |
| Year2022_Day3_Part2 | 42.81 us | 0.236 us | 0.221 us |         - |
|       Year2022_Day4 | 68.43 us | 0.514 us | 0.481 us |         - |
| Year2022_Day5_Part1 | 37.15 us | 0.259 us | 0.230 us |      40 B |
| Year2022_Day5_Part2 | 39.57 us | 0.347 us | 0.325 us |      40 B |
```
