using AdventOfCode.Year2021.Day01;
using AdventOfCode.Year2021.Day02;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[MemoryDiagnoser(false)]
// ReSharper disable once ClassCanBeSealed.Global
public class Benchmarks2021
{
    private readonly Puzzle1 _puzzle1 = new();
    private readonly Puzzle2 _puzzle2 = new();

    [Benchmark]
    public ushort Year2021_Day1_Part1()
    {
        return _puzzle1.SolvePart1();
    }

    [Benchmark]
    public ushort Year2021_Day1_Part2()
    {
        return _puzzle1.SolvePart2();
    }

    [Benchmark]
    public int Year2021_Day2_Part1()
    {
        return _puzzle2.SolvePart1();
    }

    [Benchmark]
    public int Year2021_Day2_Part2()
    {
        return _puzzle2.SolvePart2();
    }
}
