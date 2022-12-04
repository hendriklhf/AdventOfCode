using System;
using HLE;

namespace AdventOfCode.Year2021.Day1;

public sealed class Puzzle1 : Puzzle
{
    public Puzzle1() : base("Year2021.Day1.Input.txt")
    {
    }

    public ushort SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[2000];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);

        ushort count = 0;
        ReadOnlySpan<char> firstLine = input[lineRanges[0]];
        ushort previousDepth = ushort.Parse(firstLine);
        for (int i = 1; i < 2000; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            ushort currentDepth = ushort.Parse(line);
            if (currentDepth > previousDepth)
            {
                count++;
            }

            previousDepth = currentDepth;
        }

        return count;
    }

    public ushort SolvePart2()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[2000];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);

        Span<ushort> depthes = stackalloc ushort[2000];
        ushort count = 0;
        ushort previousDepth = GetDepthSum(input, lineRanges, depthes, 0);
        for (int i = 1; i < 1998; i++)
        {
            ushort currentDepth = GetDepthSum(input, lineRanges, depthes, i);
            if (currentDepth > previousDepth)
            {
                count++;
            }

            previousDepth = currentDepth;
        }

        return count;
    }

    private static ushort GetDepthSum(ReadOnlySpan<char> input, Span<Range> ranges, Span<ushort> depthes, int lineStartIdx)
    {
        ushort result = 0;
        for (int i = 0; i < 3; i++)
        {
            int idx = lineStartIdx + i;
            ushort depth = depthes[idx];
            if (depth > 0)
            {
                result += depth;
                continue;
            }

            ReadOnlySpan<char> line = input[ranges[idx]];
            depth = ushort.Parse(line);
            depthes[idx] = depth;
            result += depth;
        }

        return result;
    }
}
