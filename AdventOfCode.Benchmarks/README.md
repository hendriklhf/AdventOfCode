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
|       Year2022_Day1 | 44.89 us | 0.844 us | 0.789 us |         - |
|       Year2022_Day2 | 55.28 us | 0.175 us | 0.163 us |         - |
| Year2022_Day3_Part1 | 27.54 us | 0.135 us | 0.127 us |         - |
| Year2022_Day3_Part2 | 43.53 us | 0.112 us | 0.105 us |         - |
|       Year2022_Day4 | 68.28 us | 0.525 us | 0.491 us |         - |
```
