using System;
using AdventOfCode.Year2024.Day6;

namespace AdventOfCode.Runner;

internal static class Program
{
    private static void Main()
    {
        using Puzzle6 p = new();
        uint result = p.SolvePartOne();
        Console.WriteLine(result);
    }
}
