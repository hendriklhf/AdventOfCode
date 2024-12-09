using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AdventOfCode.Year2024.Day7;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Benchmarks;

[SuppressMessage("ReSharper", "ClassCanBeSealed.Global")]
[SuppressMessage("ReSharper", "ReplaceAsyncWithTaskReturn")]
public class BenchmarkYear2024Day7 : Bench
{
    private static readonly Puzzle7 s_puzzle7 = new();

    [Benchmark]
    public async Task<ulong> Day7_Part1() => await s_puzzle7.SolvePartOneAsync();
}
