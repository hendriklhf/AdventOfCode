using System;
using System.Runtime.CompilerServices;
using HLE;

namespace AdventOfCode.Year2022.Day04;

public sealed class Puzzle4 : Puzzle
{
    public Puzzle4() : base("Year2022.Day04.Input.txt")
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public (ushort FullyContainsCount, ushort OverlapCount) Solve()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[1000];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);

        ushort fullyContainsCount = 0;
        ushort overlapCount = 0;
        for (int i = 0; i < 1000; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            var parsedLine = ParseLine(line);
            if (DoesFullyContainTheOther(parsedLine.Left, parsedLine.Right))
            {
                fullyContainsCount++;
                overlapCount++;
                continue;
            }

            if (DoesOverlap(parsedLine.Left, parsedLine.Right))
            {
                overlapCount++;
            }
        }

        return (fullyContainsCount, overlapCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private static bool DoesFullyContainTheOther((byte Start, byte End) left, (byte Start, byte End) right)
    {
        return left.Start <= right.Start && left.End >= right.End || right.Start <= left.Start && right.End >= left.End;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private static bool DoesOverlap((byte Start, byte End) left, (byte Start, byte End) right)
    {
        return left.Start <= right.Start && left.End >= right.Start || right.Start <= left.Start && right.End >= left.Start;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private static ((byte Start, byte End) Left, (byte Start, byte End) Right) ParseLine(ReadOnlySpan<char> line)
    {
        int commaIdx = -1;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] != ',')
            {
                continue;
            }

            commaIdx = i;
            break;
        }

        (byte leftStart, byte leftEnd) = ParseRange(line[..commaIdx]);
        (byte rightStart, byte rightEnd) = ParseRange(line[++commaIdx..]);
        return ((leftStart, leftEnd), (rightStart, rightEnd));
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private static (byte Start, byte End) ParseRange(ReadOnlySpan<char> range)
    {
        int dashIdx = -1;
        for (int i = 0; i < range.Length; i++)
        {
            if (range[i] != '-')
            {
                continue;
            }

            dashIdx = i;
            break;
        }

        return (byte.Parse(range[..dashIdx]), byte.Parse(range[++dashIdx..]));
    }
}
