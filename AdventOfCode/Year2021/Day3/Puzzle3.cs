﻿using System;
using HLE;

namespace AdventOfCode.Year2021.Day3;

public sealed class Puzzle3 : Puzzle
{
    public Puzzle3() : base("Year2021.Day3.Input.txt")
    {
    }

    public int SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        Span<short> bitCounts = stackalloc short[16];
        for (int i = 0; i < lineRangesLength; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            for (int j = 4, k = 0; j < 16; j++, k++)
            {
                if (line[k] == '0')
                {
                    bitCounts[j]--;
                }
                else
                {
                    bitCounts[j]++;
                }
            }
        }

        ushort gammaRate = 0;
        for (int i = 4, j = 11; i < 16; i++, j--)
        {
            byte bit = bitCounts[i] switch
            {
                > 0 => 1,
                < 0 => 0,
                _ => throw new InvalidOperationException()
            };
            gammaRate |= (ushort)(bit << j);
        }

        ushort epsilonRate = (ushort)~gammaRate;
        return gammaRate * epsilonRate;
    }
}
