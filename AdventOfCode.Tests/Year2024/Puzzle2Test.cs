using AdventOfCode.Year2024.Day2;
using Xunit;

namespace AdventOfCode.Tests.Year2024;

public sealed class Puzzle2Test
{
    private readonly Puzzle2 _puzzle = new();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(282u, _puzzle.SolvePartOne());

    [Fact]
    public void SolvePartTwoTest() => Assert.Equal(0u, _puzzle.SolvePartTwo());
}
