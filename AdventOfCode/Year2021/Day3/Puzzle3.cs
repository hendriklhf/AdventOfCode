using System;
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
        Span<Range> lineRanges = stackalloc Range[1000];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);

        Span<short> bitCounts = stackalloc short[16];
        for (int i = 0; i < 1000; i++)
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

        ushort epsilonRate = (ushort)(~gammaRate & 0x0FFF);
        return gammaRate * epsilonRate;
    }

    public int SolvePart2()
    {
        return 0;
    }
}
