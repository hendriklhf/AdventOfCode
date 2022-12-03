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


|              Method |   Mean [ns] | Error [ns] | Allocated [B] |
|-------------------- |------------:|-----------:|--------------:|
| Year2021_Day1_Part1 | 37,992.9 ns |  338.76 ns |             - |
| Year2021_Day1_Part2 | 46,394.9 ns |  261.15 ns |             - |
| Year2021_Day2_Part1 | 11,329.8 ns |  118.40 ns |             - |
| Year2021_Day2_Part2 | 10,626.4 ns |   91.09 ns |             - |
```

## 2022

```
BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


|              Method |   Mean [ns] | Error [ns] | Allocated [B] |
|-------------------- |------------:|-----------:|--------------:|
|       Year2022_Day1 | 43,426.4 ns |   515.9 ns |             - |
|       Year2022_Day2 | 53,950.9 ns |   258.8 ns |             - |
| Year2022_Day3_Part1 | 22,783.8 ns |   120.7 ns |             - |
| Year2022_Day3_Part2 | 45,038.5 ns |   155.6 ns |             - |
```
