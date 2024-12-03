using System;
using AdventOfCode.Year2024.Day3;

namespace AdventOfCode.Runner;

internal static class Program
{
    private static void Main()
    {
        Puzzle3 p1 = new();
        uint result = p1.SolvePartTwo();
        Console.WriteLine(result);
    }
}
