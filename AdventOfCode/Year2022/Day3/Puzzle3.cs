using System;
using HLE;

namespace AdventOfCode.Year2022.Day3;

public sealed class Puzzle3 : Puzzle
{
    public Puzzle3() : base("Year2022.Day3.Input.txt")
    {
    }

    public uint SolvePart1()
    {
        ReadOnlySpan<char> input = _input;
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        uint prioritySum = 0;
        for (int i = 0; i < lineRangesLength; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            int halfLength = line.Length >> 1;
            ReadOnlySpan<char> left = line[..halfLength];
            ReadOnlySpan<char> right = line[halfLength..];
            char commonChar = '\0';
            for (int j = 0; commonChar == '\0'; j++)
            {
                char leftChar = left[j];
                for (int k = 0; k < halfLength; k++)
                {
                    if (leftChar != right[k])
                    {
                        continue;
                    }

                    commonChar = leftChar;
                    break;
                }
            }

            prioritySum += (byte)(commonChar - (commonChar <= 'Z' ? 38 : 96));
        }

        return prioritySum;
    }

    public uint SolvePart2()
    {
        ReadOnlySpan<char> input = _input;
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        uint prioritySum = 0;
        for (int i = 0; i < lineRangesLength;)
        {
            ReadOnlySpan<char> team1 = input[lineRanges[i++]];
            ReadOnlySpan<char> team2 = input[lineRanges[i++]];
            ReadOnlySpan<char> team3 = input[lineRanges[i++]];

            char badgeChar = '\0';
            for (int j = 0; badgeChar == '\0'; j++)
            {
                char c = team1[j];
                for (int k = 0; k < team2.Length; k++)
                {
                    if (c != team2[k])
                    {
                        continue;
                    }

                    for (int l = 0; l < team3.Length; l++)
                    {
                        if (c == team3[l])
                        {
                            badgeChar = c;
                        }
                    }
                }
            }

            prioritySum += (byte)(badgeChar - (badgeChar <= 'Z' ? 38 : 96));
        }

        return prioritySum;
    }
}
