using AdventOfCode.Year2022.Day01;
using AdventOfCode.Year2022.Day02;
using AdventOfCode.Year2022.Day03;
using AdventOfCode.Year2022.Day04;
using AdventOfCode.Year2022.Day05;
using AdventOfCode.Year2022.Day06;
using AdventOfCode.Year2022.Day07;
using AdventOfCode.Year2022.Day08;
using AdventOfCode.Year2022.Day09;
using AdventOfCode.Year2022.Day10;
using AdventOfCode.Year2022.Day11;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[MemoryDiagnoser(false)]
// ReSharper disable once ClassCanBeSealed.Global
public class Benchmarks2022
{
    private readonly Puzzle1 _puzzle1 = new();
    private readonly Puzzle2 _puzzle2 = new();
    private readonly Puzzle3 _puzzle3 = new();
    private readonly Puzzle4 _puzzle4 = new();
    private readonly Puzzle5 _puzzle5 = new();
    private readonly Puzzle6 _puzzle6 = new();
    private readonly Puzzle7 _puzzle7 = new();
    private readonly Puzzle8 _puzzle8 = new();
    private readonly Puzzle9 _puzzle9 = new();
    private readonly Puzzle10 _puzzle10 = new();
    private readonly Puzzle11 _puzzle11 = new();

    [Benchmark]
    public (uint, uint) Year2022_Day1()
    {
        return _puzzle1.Solve();
    }

    [Benchmark]
    public (ushort, ushort) Year2022_Day2()
    {
        return _puzzle2.Solve();
    }

    [Benchmark]
    public uint Year2022_Day3_Part1()
    {
        return _puzzle3.SolvePart1();
    }

    [Benchmark]
    public uint Year2022_Day3_Part2()
    {
        return _puzzle3.SolvePart2();
    }

    [Benchmark]
    public (ushort, ushort) Year2022_Day4()
    {
        return _puzzle4.Solve();
    }

    [Benchmark]
    public string Year2022_Day5_Part1()
    {
        return _puzzle5.SolvePart1();
    }

    [Benchmark]
    public string Year2022_Day5_Part2()
    {
        return _puzzle5.SolvePart2();
    }

    [Benchmark]
    public int Year2022_Day6_Part1()
    {
        return _puzzle6.SolvePart1();
    }

    [Benchmark]
    public int Year2022_Day6_Part2()
    {
        return _puzzle6.SolvePart2();
    }

    [Benchmark]
    public (ulong, ulong) Year2022_Day7()
    {
        return _puzzle7.Solve();
    }

    [Benchmark]
    public (ushort, uint) Year2022_Day8()
    {
        return _puzzle8.Solve();
    }

    [Benchmark]
    public int Year2022_Day9_Part1()
    {
        return _puzzle9.SolvePart1();
    }

    [Benchmark]
    public int Year2022_Day9_Part2()
    {
        return _puzzle9.SolvePart2();
    }

    [Benchmark]
    public (int, char[]) Year2022_Day10()
    {
        return _puzzle10.Solve();
    }

    [Benchmark]
    public ulong Year2022_Day11_Part1()
    {
        return _puzzle11.SolvePart1();
    }

    [Benchmark]
    public ulong Year2022_Day11_Part2()
    {
        return _puzzle11.SolvePart2();
    }
}
