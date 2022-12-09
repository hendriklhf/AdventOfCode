using AdventOfCode.Year2022.Day1;
using AdventOfCode.Year2022.Day2;
using AdventOfCode.Year2022.Day3;
using AdventOfCode.Year2022.Day4;
using AdventOfCode.Year2022.Day5;
using AdventOfCode.Year2022.Day6;
using AdventOfCode.Year2022.Day7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests;

[TestClass]
public class Tests2022
{
    [TestMethod]
    public void Day1Test()
    {
        (uint max, uint topThree) = new Puzzle1().Solve();
        Assert.AreEqual<uint>(69912, max);
        Assert.AreEqual<uint>(208180, topThree);
    }

    [TestMethod]
    public void Day2Test()
    {
        (ushort scorePart1, ushort scorePart2) = new Puzzle2().Solve();
        Assert.AreEqual(10718, scorePart1);
        Assert.AreEqual(14652, scorePart2);
    }

    [TestMethod]
    public void Day3Test()
    {
        Puzzle3 puzzle = new();
        Assert.AreEqual(7903, puzzle.SolvePart1());
        Assert.AreEqual(2548, puzzle.SolvePart2());
    }

    [TestMethod]
    public void Day4Test()
    {
        Puzzle4 puzzle = new();
        (ushort fullyContainsCount, ushort overlapCount) = puzzle.Solve();
        Assert.AreEqual(526, fullyContainsCount);
        Assert.AreEqual(886, overlapCount);
    }

    [TestMethod]
    public void Day5Test()
    {
        Puzzle5 puzzle = new();
        Assert.AreEqual("VPCDMSLWJ", puzzle.SolvePart1());
        Assert.AreEqual("TPWCGNCCG", puzzle.SolvePart2());
    }

    [TestMethod]
    public void Day6Test()
    {
        Puzzle6 puzzle = new();
        Assert.AreEqual(1356, puzzle.SolvePart1());
        Assert.AreEqual(2564, puzzle.SolvePart2());
    }

    [TestMethod]
    public void Day7Test()
    {
        Puzzle7 puzzle = new();
        Assert.AreEqual((919137, 2877389), puzzle.Solve());
    }
}
