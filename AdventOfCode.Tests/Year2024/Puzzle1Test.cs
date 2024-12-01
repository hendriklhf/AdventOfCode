using AdventOfCode.Year2024.Day1;
using Xunit;

namespace AdventOfCode.Tests.Year2024;

public sealed class Puzzle1Test
{
    private readonly Puzzle1 _puzzle = new();

    [Fact]
    public void SolvePartOneTest() => Assert.Equal(3574690, _puzzle.SolvePartOne());

    [Fact]
    public void SolvePartTwoTest() => Assert.Equal(22565391, _puzzle.SolvePartTwo());
}
