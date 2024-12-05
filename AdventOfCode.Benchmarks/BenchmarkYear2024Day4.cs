using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2024.Day4;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
public class BenchmarkYear2024Day4 : Bench
{
    private static readonly Puzzle4 s_puzzle4 = new();

    [Benchmark]
    public uint Day4_Part1() => s_puzzle4.SolvePartOne();

    [Benchmark]
    public uint Day4_Part2() => s_puzzle4.SolvePartTwo();
}
