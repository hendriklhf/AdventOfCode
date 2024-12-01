using BenchmarkDotNet.Running;

namespace AdventOfCode.Benchmarks;

internal static class Program
{
    private static void Main() => BenchmarkRunner.Run<Benchmarks2023>();
}
