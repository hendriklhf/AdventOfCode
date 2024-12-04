using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2024.Day3;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
public class BenchmarkYear2024Day3 : Bench
{
    private static readonly Puzzle3 s_puzzle3 = new();

    [Benchmark]
    public uint Day3_Part1() => s_puzzle3.SolvePartOne();

    [Benchmark]
    public uint Day3_Part2() => s_puzzle3.SolvePartOne();
}
