# [Advent of Code](https://adventofcode.com)

My take on Advent of Code in C#.

## Code

- [2024](https://github.com/Sterbehilfe/AdventOfCode/tree/master/AdventOfCode/Year2024)
- [2023](https://github.com/Sterbehilfe/AdventOfCode/tree/master/AdventOfCode/Year2023)

## Benchmarks

- [2024](#2024)
- [2023](#2023)

### 2024

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


| Method     | Mean     | Error    | StdDev   | Allocated |
|----------- |---------:|---------:|---------:|----------:|
| Day1_Part1 | 17.59 us | 0.158 us | 0.147 us |         - |
| Day1_Part2 | 17.65 us | 0.125 us | 0.117 us |         - |
| Day2_Part1 | 25.15 us | 0.499 us | 0.490 us |         - |
| Day3_Part1 | 26.60 us | 0.183 us | 0.171 us |         - |
| Day3_Part2 | 26.51 us | 0.191 us | 0.178 us |         - |
| Day4_Part1 | 38.69 us | 0.306 us | 0.287 us |         - |
| Day4_Part2 | 23.33 us | 0.278 us | 0.260 us |         - |
| Day6_Part1 | 6.842 us | 0.136 us | 0.212 us |         - |
| Day7_Part1 | 1.664 ms | 0.033 ms | 0.076 ms |         - |
```

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
