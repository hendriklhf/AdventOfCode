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
|       Year2022_Day1 | 44.07 us | 0.551 us | 0.516 us |         - |
|       Year2022_Day2 | 56.10 us | 0.778 us | 0.649 us |         - |
| Year2022_Day3_Part1 | 28.21 us | 0.500 us | 0.717 us |         - |
| Year2022_Day3_Part2 | 43.86 us | 0.251 us | 0.223 us |         - |
```
