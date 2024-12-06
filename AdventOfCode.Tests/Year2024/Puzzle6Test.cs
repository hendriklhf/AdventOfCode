using System;
using AdventOfCode.Year2024.Day6;
using Xunit;

namespace AdventOfCode.Tests.Year2024;

public sealed class Puzzle6Test : IDisposable
{
    private readonly Puzzle6 _puzzle = new();

    public void Dispose() => _puzzle.Dispose();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(4977u, _puzzle.SolvePartOne());
}
