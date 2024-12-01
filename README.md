# [Advent of Code](https://adventofcode.com)

My take on Advent of Code in C#.

## Code

- [2023](https://github.com/Sterbehilfe/AdventOfCode/tree/master/AdventOfCode/Year2023)
- [2024](https://github.com/Sterbehilfe/AdventOfCode/tree/master/AdventOfCode/Year2024)

## Benchmarks

- [2023](#2023)
- [2024](#2024)

### 2023

```
BenchmarkDotNet v0.13.10, Windows 11 (10.0.22631.2715/23H2/2023Update/SunValley3)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


| Method     | Mean      | Error     | StdDev    | Median    | Allocated |
|----------- |----------:|----------:|----------:|----------:|----------:|
| Day1_Part1 |  7.864 us | 0.1554 us | 0.1851 us |  7.916 us |         - |
| Day1_Part2 | 25.979 us | 0.5145 us | 1.0626 us | 25.564 us |         - |
| Day2_Part1 |  8.719 us | 0.1728 us | 0.3371 us |  8.483 us |         - |
| Day2_Part2 |  8.741 us | 0.0613 us | 0.0479 us |  8.732 us |         - |
```

### 2024

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


| Method     | Mean     | Error    | StdDev   | Allocated |
|----------- |---------:|---------:|---------:|----------:|
| Day1_Part1 | 15.82 us | 0.200 us | 0.187 us |         - |
| Day1_Part2 | 15.94 us | 0.235 us | 0.208 us |         - |
```
