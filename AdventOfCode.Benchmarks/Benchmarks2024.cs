using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Year2024.Day1;
using AdventOfCode.Year2024.Day2;
using AdventOfCode.Year2024.Day3;
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
    private static readonly Puzzle2 s_puzzle2 = new();
    private static readonly Puzzle3 s_puzzle3 = new();

    [Benchmark]
    public int Day1_Part1() => s_puzzle1.SolvePartOne();

    [Benchmark]
    public int Day1_Part2() => s_puzzle1.SolvePartOne();

    [Benchmark]
    public uint Day2_Part1() => s_puzzle2.SolvePartOne();

    /*
    [Benchmark]
    public int Day2_Part2() => s_puzzle1.SolvePartOne();
    */

    [Benchmark]
    public uint Day3_Part1() => s_puzzle3.SolvePartOne();

    [Benchmark]
    public uint Day3_Part2() => s_puzzle3.SolvePartOne();
}
