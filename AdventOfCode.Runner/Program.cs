using System;
using AdventOfCode.Year2024.Day4;

namespace AdventOfCode.Runner;

internal static class Program
{
    private static void Main()
    {
        Puzzle4 p = new();
        uint result = p.SolvePartOne();
        Console.WriteLine(result);
    }
}
