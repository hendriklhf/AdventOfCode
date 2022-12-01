using AdventOfCode.Year2022.Day1;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[MemoryDiagnoser(false)]
// ReSharper disable once ClassCanBeSealed.Global
public class Benchmarks
{
    private readonly Puzzle1 _puzzle1 = new();

    [Benchmark]
    public (uint, uint) Day1()
    {
        return _puzzle1.Solve();
    }
}
