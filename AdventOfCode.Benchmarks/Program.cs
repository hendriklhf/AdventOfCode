using BenchmarkDotNet.Running;

namespace AdventOfCode.Benchmarks;

internal static class Program
{
    private static void Main() => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
}
