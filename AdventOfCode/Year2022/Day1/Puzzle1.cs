using System;
using System.Reflection;
using HLE;
using HLE.Resources;

namespace AdventOfCode.Year2022.Day1;

public sealed class Puzzle1
{
    private readonly string _input;
    private const string _doubleNewLine = "\r\n\r\n";

    public Puzzle1()
    {
        ResourceReader reader = new(Assembly.GetExecutingAssembly(), false);
        string? input = reader.ReadResource("Year2022.Day1.Input.txt");
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        _input = input;
    }

    public (uint Max, uint TopThree) Solve()
    {
        ReadOnlySpan<char> input = _input;
        input = input[..^2];
        Span<Range> elvsRanges = stackalloc Range[input.Length];
        int elvsRangesLength = input.GetRangesOfSplit(_doubleNewLine, elvsRanges);
        elvsRanges = elvsRanges[..elvsRangesLength];

        uint max = 0;
        Span<uint> topThree = stackalloc uint[3];
        for (int i = 0; i < elvsRangesLength; i++)
        {
            ReadOnlySpan<char> elvCalories = input[elvsRanges[i]];
            uint elvTotal = GetTotalCalories(elvCalories);
            CheckForHigherTopThree(topThree, elvTotal);
            max = elvTotal > max ? elvTotal : max;
        }

        uint topThreeSum = topThree[0] + topThree[1] + topThree[2];
        return (max, topThreeSum);
    }

    private static uint GetTotalCalories(ReadOnlySpan<char> elvCalories)
    {
        Span<Range> elvRanges = stackalloc Range[elvCalories.Length];
        int elvRangesLength = elvCalories.GetRangesOfSplit(Environment.NewLine, elvRanges);
        elvRanges = elvRanges[..elvRangesLength];
        uint elvTotal = 0;
        for (int j = 0; j < elvRangesLength; j++)
        {
            ReadOnlySpan<char> calories = elvCalories[elvRanges[j]];
            elvTotal += uint.Parse(calories);
        }

        return elvTotal;
    }

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
