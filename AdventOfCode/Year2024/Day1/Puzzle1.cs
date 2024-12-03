using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using HLE.Numerics;

namespace AdventOfCode.Year2024.Day1;

public sealed unsafe class Puzzle1() : Puzzle("AdventOfCode.Year2024.Day1.input.txt")
{
    private const int LineCount = 1000;

    [SkipLocalsInit]
    public int SolvePartOne()
    {
        int* leftNumbers = stackalloc int[LineCount];
        int* rightNumbers = stackalloc int[LineCount];
        ReadOnlySpan<byte> input = InputUtf8;

        uint i = 0;
        foreach (Range range in input.Split((byte)'\n'))
        {
            ReadOnlySpan<byte> line = input[range];

            ReadOnlySpan<byte> leftNumber = line[..5];
            leftNumbers[i] = NumberHelpers.ParsePositiveNumber<int>(leftNumber);

            ReadOnlySpan<byte> rightNumber = line[8..];
            rightNumbers[i] = NumberHelpers.ParsePositiveNumber<int>(rightNumber);

            i++;
        }

        new Span<uint>(leftNumbers, LineCount).Sort();
        new Span<uint>(rightNumbers, LineCount).Sort();

        int remaining = LineCount;
        Vector512<int> sum = Vector512<int>.Zero;
        while (remaining >= Vector512<int>.Count)
        {
            Vector512<int> left = Vector512.Load(leftNumbers);
            Vector512<int> right = Vector512.Load(rightNumbers);
            Vector512<int> abs = Vector512.Abs(left - right);
            sum += abs;

            leftNumbers += Vector512<int>.Count;
            rightNumbers += Vector512<int>.Count;
            remaining -= Vector512<int>.Count;
        }

        int result = Vector512.Sum(sum);
        if (remaining != 0)
        {
            for (int r = 0; r < remaining; r++)
            {
                result += Math.Abs(leftNumbers[r] - rightNumbers[r]);
            }
        }

        return result;
    }

    [SkipLocalsInit]
    public int SolvePartTwo()
    {
        int* leftNumbers = stackalloc int[LineCount];
        int* rightNumbers = stackalloc int[LineCount];
        ReadOnlySpan<byte> input = InputUtf8;

        uint i = 0;
        foreach (Range range in input.Split((byte)'\n'))
        {
            ReadOnlySpan<byte> line = input[range];

            ReadOnlySpan<byte> leftNumber = line[..5];
            leftNumbers[i] = NumberHelpers.ParsePositiveNumber<int>(leftNumber);

            ReadOnlySpan<byte> rightNumber = line[8..];
            rightNumbers[i] = NumberHelpers.ParsePositiveNumber<int>(rightNumber);

            i++;
        }

        int remaining = LineCount;
        Vector512<int> sum = Vector512<int>.Zero;
        Vector512<int> counts = Vector512<int>.Zero;
        while (remaining >= Vector512<int>.Count)
        {
            Vector512<int> left = Vector512.Load(leftNumbers);
            for (int j = 0; j < Vector512<int>.Count; j++)
            {
                Unsafe.Add(ref Unsafe.As<Vector512<int>, int>(ref counts), j) = Count(rightNumbers, leftNumbers[j]);
            }

            sum += left * counts;

            leftNumbers += Vector512<int>.Count;
            remaining -= Vector512<int>.Count;
        }

        int result = Vector512.Sum(sum);
        if (remaining != 0)
        {
            for (int r = 0; r < remaining; r++)
            {
                result += leftNumbers[r] * Count(rightNumbers, leftNumbers[r]);
            }
        }

        return result;
    }

    private static int Count(int* numbers, int needle)
        => new ReadOnlySpan<int>(numbers, LineCount).Count(needle);
}
