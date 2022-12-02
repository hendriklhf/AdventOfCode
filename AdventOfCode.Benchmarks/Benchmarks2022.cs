using AdventOfCode.Year2022.Day1;
using AdventOfCode.Year2022.Day2;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[MemoryDiagnoser(false)]
// ReSharper disable once ClassCanBeSealed.Global
public class Benchmarks2022
{
    private readonly Puzzle1 _puzzle1 = new();
    private readonly Puzzle2 _puzzle2 = new();

    [Benchmark]
    public (uint, uint) Year2022_Day1()
    {
        return _puzzle1.Solve();
    }

    [Benchmark]
    public ushort Year2022_Day2_Part1()
    {
        return _puzzle2.Solve();
    }
}
