using System;
using HLE;

namespace AdventOfCode.Year2022.Day8;

public sealed class Puzzle8 : Puzzle
{
    public Puzzle8() : base("Year2022.Day8.Input.txt")
    {
    }

    public (ushort VisibleCount, uint MaxScenicScore) Solve()
    {
        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[99];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        ushort visibleCount = 98 << 2;
        uint maxScenicScore = 0;
        for (int i = 1; i < 98; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            for (int j = 1; j < 98; j++)
            {
                char treeSize = line[j];
                CheckScenicScore(input, lineRanges, treeSize, ref maxScenicScore, i, j);
                if (treeSize == '0')
                {
                    continue;
                }

                bool isVisibleFromLeft = IsVisibleInRow(line, treeSize, end: j);
                if (isVisibleFromLeft)
                {
                    visibleCount++;
                    continue;
                }

                bool isVisibleFromRight = IsVisibleInRow(line, treeSize, j + 1);
                if (isVisibleFromRight)
                {
                    visibleCount++;
                    continue;
                }

                bool isVisibleFromTop = IsVisibleInColumn(input, lineRanges, treeSize, j, end: i);
                if (isVisibleFromTop)
                {
                    visibleCount++;
                    continue;
                }

                bool isVisibleFromBottom = IsVisibleInColumn(input, lineRanges, treeSize, j, i + 1);
                if (isVisibleFromBottom)
                {
                    visibleCount++;
                }
            }
        }

        return (visibleCount, maxScenicScore);
    }

    private static bool IsVisibleInRow(ReadOnlySpan<char> row, char treeSize, int start = 0, int end = 99)
    {
        for (int i = start; i < end; i++)
        {
            char size = row[i];
            if (size >= treeSize)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsVisibleInColumn(ReadOnlySpan<char> input, Span<Range> ranges, char treeSize, int columnIndex, int start = 0, int end = 99)
    {
        for (int i = start; i < end; i++)
        {
            ReadOnlySpan<char> line = input[ranges[i]];
            char size = line[columnIndex];
            if (size >= treeSize)
            {
                return false;
            }
        }

        return true;
    }

    private static void CheckScenicScore(ReadOnlySpan<char> input, Span<Range> ranges, char treeSize, ref uint maxScenicScore, int rowIndex, int columnIndex)
    {
        ReadOnlySpan<char> row = input[ranges[rowIndex]];
        ushort leftScore = GetLeftScenicScore(row, treeSize, columnIndex - 1);
        ushort rightScore = GetRightScenicScore(row, treeSize, columnIndex + 1);
        ushort topScore = GetTopScenicScore(input, ranges, treeSize, columnIndex, rowIndex - 1);
        ushort bottomScore = GetBottomScenicScore(input, ranges, treeSize, columnIndex, rowIndex + 1);
        uint scenicScore = (uint)(leftScore * rightScore * topScore * bottomScore);
        if (scenicScore > maxScenicScore)
        {
            maxScenicScore = scenicScore;
        }
    }

    private static ushort GetLeftScenicScore(ReadOnlySpan<char> row, char treeSize, int start)
    {
        ushort result = 0;
        for (int i = start; i >= 0; i--)
        {
            char size = row[i];
            if (size >= treeSize)
            {
                return ++result;
            }

            result++;
        }

        return result;
    }

    private static ushort GetRightScenicScore(ReadOnlySpan<char> row, char treeSize, int start)
    {
        ushort result = 0;
        for (int i = start; i < 99; i++)
        {
            char size = row[i];
            if (size >= treeSize)
            {
                return ++result;
            }

            result++;
        }

        return result;
    }

    private static ushort GetTopScenicScore(ReadOnlySpan<char> input, Span<Range> ranges, char treeSize, int columnIndex, int start)
    {
        ushort result = 0;
        for (int i = start; i >= 0; i--)
        {
            ReadOnlySpan<char> line = input[ranges[i]];
            char size = line[columnIndex];
            if (size >= treeSize)
            {
                return ++result;
            }

            result++;
        }

        return result;
    }

    private static ushort GetBottomScenicScore(ReadOnlySpan<char> input, Span<Range> ranges, char treeSize, int columnIndex, int start)
    {
        ushort result = 0;
        for (int i = start; i < 99; i++)
        {
            ReadOnlySpan<char> line = input[ranges[i]];
            char size = line[columnIndex];
            if (size >= treeSize)
            {
                return ++result;
            }

            result++;
        }

        return result;
    }
}
