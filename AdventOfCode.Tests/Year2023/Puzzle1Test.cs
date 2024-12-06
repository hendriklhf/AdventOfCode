using System;
using AdventOfCode.Year2023.Day1;
using Xunit;

namespace AdventOfCode.Tests.Year2023;

public sealed class Puzzle1Test : IDisposable
{
    private readonly Puzzle1 _puzzle = new();

    public void Dispose() => _puzzle.Dispose();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(54630, _puzzle.SolvePartOne());

    [Fact]
    public void SolvePartTwoTest() => Assert.Equal(54770, _puzzle.SolvePartTwo());
}
