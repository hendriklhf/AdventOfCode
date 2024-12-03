using System;
using System.Runtime.CompilerServices;
using HLE.Numerics;

namespace AdventOfCode.Year2024.Day2;

public sealed class Puzzle2() : Puzzle("AdventOfCode.Year2024.Day2.input.txt")
{
    [SkipLocalsInit]
    public uint SolvePartOne()
    {
        uint result = 0;
        ReadOnlySpan<byte> input = InputUtf8;
        foreach (Range lineRange in input.Split((byte)'\n'))
        {
            ReadOnlySpan<byte> line = input[lineRange];
            MemoryExtensions.SpanSplitEnumerator<byte> enumerator = line.Split((byte)' ');
            bool b = true;
            sbyte wasPositive = -1;
            while (enumerator.MoveNext())
            {
                sbyte left = NumberHelpers.ParsePositiveNumber<sbyte>(line[enumerator.Current]);
                MemoryExtensions.SpanSplitEnumerator<byte> copy = enumerator;
                if (!copy.MoveNext())
                {
                    break;
                }

                sbyte right = NumberHelpers.ParsePositiveNumber<sbyte>(line[copy.Current]);
                if (left == right)
                {
                    b = false;
                    break;
                }

                int diff = left - right;

                if (wasPositive == -1)
                {
                    wasPositive = Unsafe.BitCast<bool, sbyte>(diff > 0);
                }

                if (diff > 0 ^ Unsafe.BitCast<sbyte, bool>(wasPositive))
                {
                    b = false;
                    break;
                }

                diff = Math.Abs(diff);
                if (diff > 3)
                {
                    b = false;
                    break;
                }
            }

            if (b)
            {
                result++;
            }
        }

        return result;
    }

    [SkipLocalsInit]
    public uint SolvePartTwo()
    {
        uint result = 0;
        ReadOnlySpan<byte> input = InputUtf8;
        foreach (Range lineRange in input.Split((byte)'\n'))
        {
            ReadOnlySpan<byte> line = input[lineRange];
            int numberCount = line.Count((byte)' ') + 1;
            for (int i = -1; i < numberCount; i++)
            {
                MemoryExtensions.SpanSplitEnumerator<byte> enumerator = line.Split((byte)' ');
                sbyte wasPositive = -1;
                bool b = true;
                int n = -1;
                while (enumerator.MoveNext())
                {
                    n++;
                    if ((n | i) == 0)
                    {
                        enumerator.MoveNext();
                        continue;
                    }

                    sbyte left = NumberHelpers.ParsePositiveNumber<sbyte>(line[enumerator.Current]);
                    MemoryExtensions.SpanSplitEnumerator<byte> copy = enumerator;
                    if (!copy.MoveNext())
                    {
                        break;
                    }

                    if (i != -1 && n != 0 && n == i && !copy.MoveNext())
                    {
                        break;
                    }

                    sbyte right = NumberHelpers.ParsePositiveNumber<sbyte>(line[copy.Current]);

                    if (left == right)
                    {
                        b = false;
                        break;
                    }

                    int diff = left - right;

                    if (wasPositive == -1)
                    {
                        wasPositive = Unsafe.BitCast<bool, sbyte>(diff > 0);
                    }

                    if (diff > 0 ^ Unsafe.BitCast<sbyte, bool>(wasPositive))
                    {
                        b = false;
                        break;
                    }

                    diff = Math.Abs(diff);
                    if (diff > 3)
                    {
                        b = false;
                        break;
                    }
                }

                if (b)
                {
                    result++;
                    break;
                }
            }
        }

        return result;
    }
}
