using System;
using System.Threading.Tasks;
using AdventOfCode.Year2024.Day7;
using Xunit;

namespace AdventOfCode.Tests.Year2024;

public sealed class Puzzle7Test : IDisposable
{
    private readonly Puzzle7 _puzzle = new();

    public void Dispose() => _puzzle.Dispose();

    [Fact]
    public async Task SolvePartOneTest() => Assert.Equal(12839601725877UL, await _puzzle.SolvePartOneAsync());
}
