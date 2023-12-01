using BenchmarkDotNet.Running;

namespace AdventOfCode.Benchmarks;

public static class Program
{
    private static void Main() => BenchmarkRunner.Run<Benchmarks2023>();
}
