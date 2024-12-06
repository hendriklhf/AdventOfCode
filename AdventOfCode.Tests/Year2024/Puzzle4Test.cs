using System;
using AdventOfCode.Year2024.Day4;
using Xunit;

namespace AdventOfCode.Tests.Year2024;

public sealed class Puzzle4Test : IDisposable
{
    private readonly Puzzle4 _puzzle = new();

    public void Dispose() => _puzzle.Dispose();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(2534u, _puzzle.SolvePartOne());

    [Fact]
    public void SolvePartTwoTest() => Assert.Equal(1866u, _puzzle.SolvePartTwo());
}
