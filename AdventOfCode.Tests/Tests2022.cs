using AdventOfCode.Year2022.Day01;
using AdventOfCode.Year2022.Day02;
using AdventOfCode.Year2022.Day03;
using AdventOfCode.Year2022.Day04;
using AdventOfCode.Year2022.Day05;
using AdventOfCode.Year2022.Day06;
using AdventOfCode.Year2022.Day07;
using AdventOfCode.Year2022.Day08;
using AdventOfCode.Year2022.Day09;
using AdventOfCode.Year2022.Day10;
using AdventOfCode.Year2022.Day11;
using AdventOfCode.Year2022.Day12;
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
        Assert.AreEqual<(ulong, ulong)>((919137, 2877389), puzzle.Solve());
    }

    [TestMethod]
    public void Day8Test()
    {
        Puzzle8 puzzle = new();
        (ushort visibleCount, uint maxScenicScore) = puzzle.Solve();
        Assert.AreEqual<ushort>(1763, visibleCount);
        Assert.AreEqual<uint>(671160, maxScenicScore);
    }

    [TestMethod]
    public void Day9Test()
    {
        Puzzle9 puzzle = new();
        Assert.AreEqual(6271, puzzle.SolvePart1());
        Assert.AreEqual(2458, puzzle.SolvePart2());
    }

    [TestMethod]
    public void Day10Test()
    {
        Puzzle10 puzzle = new();
        (int signalSum, char[] displayOutput) = puzzle.Solve();
        Assert.AreEqual(12560, signalSum);
        Assert.AreEqual("###  #    ###   ##  #### ###   ##  #    #  # #    #  # #  # #    #  # #  # #    #  # #    #  # #  # ###  ###  #    #    ###  #    ###  #### #    #  # #    #    #    #    #    #  # #    #  # #  # #    #    #### #    #  # #    ###   ##  #### ", new(displayOutput));
    }

    [TestMethod]
    public void Day11Test()
    {
        Puzzle11 puzzle = new();
        Assert.AreEqual<ulong>(99840, puzzle.SolvePart1());
        Assert.AreEqual<ulong>(20683044837, puzzle.SolvePart2());
    }

    [TestMethod]
    public void Day12Test()
    {
        Puzzle12 puzzle = new();
        Assert.AreEqual<ushort>(490, puzzle.SolvePart1());
        Assert.AreEqual<ushort>(488, puzzle.SolvePart2());
    }
}
