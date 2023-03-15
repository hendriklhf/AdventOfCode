﻿using System;
using System.Runtime.CompilerServices;
using HLE;

namespace AdventOfCode.Year2022.Day01;

public sealed class Puzzle1 : Puzzle
{
    public Puzzle1() : base("Year2022.Day01.Input.txt")
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public (uint Max, uint TopThree) Solve()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[2266];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);

        uint max = 0;
        uint elfTotal = 0;
        Span<uint> topThree = stackalloc uint[3];
        for (int i = 0; i < 2266; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            if (line.Length == 0)
            {
                CheckForHigherTopThree(topThree, elfTotal);
                max = elfTotal > max ? elfTotal : max;
                elfTotal = 0;
                continue;
            }

            elfTotal += NumberHelper.ParseUInt32(line);
        }

        uint topThreeSum = topThree[0] + topThree[1] + topThree[2];
        return (max, topThreeSum);
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private static void CheckForHigherTopThree(Span<uint> topThree, uint newValue)
    {
        int minIdx = -1;
        uint min = uint.MaxValue;
        for (int i = 0; i < 3; i++)
        {
            uint top = topThree[i];
            if (top >= min)
            {
                continue;
            }

            min = top;
            minIdx = i;
        }

        if (min < newValue && minIdx != -1)
        {
            topThree[minIdx] = newValue;
        }
    }
}
