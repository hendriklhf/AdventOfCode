using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2024.Day6;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
public class BenchmarkYear2024Day6 : Bench
{
    private static readonly Puzzle6 s_puzzle6 = new();

    [Benchmark]
    public uint Day6_Part1() => s_puzzle6.SolvePartOne();
}
