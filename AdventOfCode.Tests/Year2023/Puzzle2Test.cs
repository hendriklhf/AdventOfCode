using AdventOfCode.Year2023.Day2;
using Xunit;

namespace AdventOfCode.Tests.Year2023;

public sealed class Puzzle2Test
{
    private readonly Puzzle2 _puzzle = new();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(2377, _puzzle.SolvePartOne());

    [Fact]
    public void SolvePartTwoTest() => Assert.Equal(71220, _puzzle.SolvePartTwo());
}
