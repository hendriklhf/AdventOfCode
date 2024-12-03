using AdventOfCode.Year2024.Day3;
using Xunit;

namespace AdventOfCode.Tests.Year2024;

public sealed class Puzzle3Test
{
    private readonly Puzzle3 _puzzle = new();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(184511516u, _puzzle.SolvePartOne());

    [Fact]
    public void SolvePartTwoTest() => Assert.Equal(90044227u, _puzzle.SolvePartTwo());
}
