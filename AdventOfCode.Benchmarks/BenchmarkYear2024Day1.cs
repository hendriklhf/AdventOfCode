using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2023.Day1;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
public class BenchmarkYear2024Day1 : Bench
{
    private static readonly Puzzle1 s_puzzle1 = new();

    [Benchmark]
    public int Day1_Part1() => s_puzzle1.SolvePartOne();

    [Benchmark]
    public int Day1_Part2() => s_puzzle1.SolvePartOne();
}
