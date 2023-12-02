using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2023.Day1;
using AdventOfCode.Year2023.Day2;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[MemoryDiagnoser]
[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]
public class Benchmarks2023
{
    private static readonly Puzzle1 s_puzzle1 = new();
    private static readonly Puzzle2 s_puzzle2 = new();

    [Benchmark]
    public int Day1_Part1() => s_puzzle1.SolvePartOne();

    [Benchmark]
    public int Day1_Part2() => s_puzzle1.SolvePartTwo();

    [Benchmark]
    public int Day2_Part1() => s_puzzle2.SolvePartOne();

    [Benchmark]
    public int Day2_Part2() => s_puzzle2.SolvePartTwo();
}
