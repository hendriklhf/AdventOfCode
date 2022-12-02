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
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        ushort count = 0;
        ReadOnlySpan<char> firstLine = input[lineRanges[0]];
        ushort previousDepth = ushort.Parse(firstLine);
        for (int i = 1; i < lineRangesLength; i++)
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
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        Span<ushort> depthes = stackalloc ushort[lineRangesLength];
        ushort count = 0;
        ushort previousDepth = GetDepthSum(input, lineRanges, depthes, 0);
        lineRangesLength -= 2;
        for (int i = 1; i < lineRangesLength; i++)
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
            ushort depth = depthes[lineStartIdx + i];
            if (depth > 0)
            {
                result += depth;
                continue;
            }

            ReadOnlySpan<char> line = input[ranges[lineStartIdx + i]];
            result += ushort.Parse(line);
        }

        return result;
    }
}
