﻿using AdventOfCode.Year2022.Day1;
using AdventOfCode.Year2022.Day2;
using AdventOfCode.Year2022.Day3;
using AdventOfCode.Year2022.Day4;
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
}
