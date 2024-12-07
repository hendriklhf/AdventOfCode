using System;
using AdventOfCode.Year2024.Day7;

namespace AdventOfCode.Runner;

internal static class Program
{
    private static void Main()
    {
        using Puzzle7 p = new();
        ulong result = p.SolvePartOne();
        Console.WriteLine(result);
    }
}
