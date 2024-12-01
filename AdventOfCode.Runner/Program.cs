using System;
using AdventOfCode.Year2024.Day1;

namespace AdventOfCode.Runner;

internal static class Program
{
    private static void Main()
    {
        Puzzle1 p1 = new();
        int result = p1.SolvePartTwo();
        Console.WriteLine(result);
    }
}
