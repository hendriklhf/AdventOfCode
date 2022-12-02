using AdventOfCode.Year2021.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests;

[TestClass]
public class Tests2021
{
    [TestMethod]
    public void Day1Test()
    {
        Puzzle1 puzzle = new();
        Assert.AreEqual(1766, puzzle.SolvePart1());
        Assert.AreEqual(1797, puzzle.SolvePart2());
    }
}
