using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day3;

public sealed partial class Puzzle3() : Puzzle("AdventOfCode.Year2024.Day3.input.txt")
{
    [GeneratedRegex(@"mul\(\d+,\d+\)")]
    public static partial Regex PartOnePattern { get; }

    [GeneratedRegex(@"(mul\(\d+,\d+\))|(do(n't)?\(\))")]
    public static partial Regex PartTwoPattern { get; }

    public uint SolvePartOne()
    {
        uint result = 0;
        ReadOnlySpan<char> input = Input;
        foreach (ValueMatch match in PartOnePattern.EnumerateMatches(input))
        {
            ReadOnlySpan<char> value = input.Slice(match.Index + 4, match.Length - 5);
            Debug.WriteLine($"Match: \"{value}\"");
            int mid = value.IndexOf(',');
            uint left = uint.Parse(value[..mid]);
            uint right = uint.Parse(value[(mid + 1)..]);
            result += left * right;
        }

        return result;
    }

    public uint SolvePartTwo()
    {
        uint result = 0;
        ReadOnlySpan<char> input = Input;
        bool active = true;
        foreach (ValueMatch match in PartTwoPattern.EnumerateMatches(input))
        {
            ReadOnlySpan<char> value = input.Slice(match.Index, match.Length);

            switch (value.Length)
            {
                case 4: // "do()"
                    active = true;
                    continue;
                case 7: // "don't()"
                    active = false;
                    continue;
            }

            if (!active)
            {
                continue;
            }

            int comma = value.IndexOf(',');
            uint left = uint.Parse(value[4..comma]);
            uint right = uint.Parse(value[(comma + 1)..^1]);
            result += left * right;
        }

        return result;
    }
}
