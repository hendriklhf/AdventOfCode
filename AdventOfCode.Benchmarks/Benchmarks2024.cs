using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2024.Day1;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[MemoryDiagnoser]
[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]
[SuppressMessage("Maintainability", "CA1515:Consider making public types internal")]
public class Benchmarks2024
{
    private static readonly Puzzle1 s_puzzle1 = new();

    [Benchmark]
    public int Day1_Part1() => s_puzzle1.SolvePartOne();

    [Benchmark]
    public int Day1_Part2() => s_puzzle1.SolvePartOne();
}
