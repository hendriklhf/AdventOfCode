using AdventOfCode.Year2023.Day1;
using Xunit;

namespace AdventOfCode.Tests.Year2023;

public sealed class Puzzle1Test
{
    private readonly Puzzle1 _puzzle = new();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(54630, _puzzle.SolvePartOne());

    [Fact]
    public void SolvePartTwoTest() => Assert.Equal(54770, _puzzle.SolvePartTwo());
}
