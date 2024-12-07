using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2024.Day7;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
public class BenchmarkYear2024Day7 : Bench
{
    private static readonly Puzzle7 s_puzzle7 = new();

    [Benchmark]
    public ulong Day7_Part1() => s_puzzle7.SolvePartOne();
}
