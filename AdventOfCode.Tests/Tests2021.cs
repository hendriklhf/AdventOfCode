using AdventOfCode.Year2021.Day01;
using AdventOfCode.Year2021.Day02;
using AdventOfCode.Year2021.Day03;
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

    [TestMethod]
    public void Day2Test()
    {
        Puzzle2 puzzle = new();
        Assert.AreEqual(2019945, puzzle.SolvePart1());
        Assert.AreEqual(1599311480, puzzle.SolvePart2());
    }

    [TestMethod]
    public void Day3Test()
    {
        Puzzle3 puzzle = new();
        Assert.AreEqual(2035764, puzzle.SolvePart1());
    }
}
