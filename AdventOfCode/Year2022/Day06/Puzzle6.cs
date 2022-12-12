using System;

namespace AdventOfCode.Year2022.Day06;

public sealed class Puzzle6 : Puzzle
{
    public Puzzle6() : base("Year2022.Day06.Input.txt")
    {
    }

    public int SolvePart1() => Solve(4);

    public int SolvePart2() => Solve(14);

    private int Solve(int distinctCharCount)
    {
        ReadOnlySpan<char> input = _input;
        for (int i = distinctCharCount; i < input.Length; i++)
        {
            int start = i - distinctCharCount;
            ReadOnlySpan<char> segment = input[start..i];
            if (!ContainsDuplicate(segment))
            {
                return i;
            }
        }

        return -1;
    }

    private static bool ContainsDuplicate(ReadOnlySpan<char> segment)
    {
        int segmentLengthMinus1 = segment.Length - 1;
        for (int i = 0; i < segmentLengthMinus1; i++)
        {
            for (int j = i + 1; j < segment.Length; j++)
            {
                if (segment[i] == segment[j])
                {
                    return true;
                }
            }
        }

        return false;
    }
}
