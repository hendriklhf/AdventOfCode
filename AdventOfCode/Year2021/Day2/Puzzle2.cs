using System;
using HLE;

namespace AdventOfCode.Year2021.Day2;

public sealed class Puzzle2 : Puzzle
{
    private const char _cmdForward = 'f';
    private const char _cmdUp = 'u';
    private const char _cmdDown = 'd';
    private const char _zero = '0';

    public Puzzle2() : base("Year2021.Day2.Input.txt")
    {
    }

    public int SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        int x = 0;
        int y = 0;
        for (int i = 0; i < lineRangesLength; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            byte value = (byte)(line[^1] - _zero);
            char cmd = line[0];
            switch (cmd)
            {
                case _cmdForward:
                    x += value;
                    break;
                case _cmdDown:
                    y += value;
                    break;
                case _cmdUp:
                    y -= value;
                    break;
            }
        }

        return x * y;
    }

    public int SolvePart2()
    {
        ReadOnlySpan<char> input = _input;
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        int x = 0;
        int y = 0;
        int aim = 0;
        for (int i = 0; i < lineRangesLength; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            byte value = (byte)(line[^1] - _zero);
            char cmd = line[0];
            switch (cmd)
            {
                case _cmdForward:
                    x += value;
                    y += aim * value;
                    break;
                case _cmdDown:
                    aim += value;
                    break;
                case _cmdUp:
                    aim -= value;
                    break;
            }
        }

        return x * y;
    }
}
