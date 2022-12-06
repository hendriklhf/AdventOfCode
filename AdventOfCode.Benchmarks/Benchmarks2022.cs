using AdventOfCode.Year2022.Day1;
using AdventOfCode.Year2022.Day2;
using AdventOfCode.Year2022.Day3;
using AdventOfCode.Year2022.Day4;
using AdventOfCode.Year2022.Day5;
using AdventOfCode.Year2022.Day6;
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
}
