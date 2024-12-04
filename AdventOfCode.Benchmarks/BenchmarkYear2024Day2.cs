using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2024.Day2;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
public class BenchmarkYear2024Day2 : Bench
{
    private static readonly Puzzle2 s_puzzle2 = new();

    [Benchmark]
    public uint Day2_Part1() => s_puzzle2.SolvePartOne();

    /*
    [Benchmark]
    public int Day2_Part2() => s_puzzle2.SolvePartTwo();
    */
}
