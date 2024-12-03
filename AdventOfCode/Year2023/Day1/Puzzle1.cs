using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdventOfCode.Year2023.Day1;

public sealed class Puzzle1() : Puzzle("AdventOfCode.Year2023.Day1.input.txt")
{
    private static readonly SearchValues<byte> s_digitSearchValues = SearchValues.Create("123456789"u8);
    private static readonly SearchValues<byte> s_digitAndTextSearchValues = SearchValues.Create("123456789otfsen"u8);

    private const byte Zero = (byte)'0';

    public int SolvePartOne()
    {
        const byte LineFeed = (byte)'\n';

        int sum = 0;

        ReadOnlySpan<byte> input = InputUtf8;
        do
        {
            int indexOfNewLine = input.IndexOf(LineFeed);
            ReadOnlySpan<byte> line = input[..indexOfNewLine];

            int firstDigitIndex = line.IndexOfAny(s_digitSearchValues);
            int lastDigitIndex = line.LastIndexOfAny(s_digitSearchValues);

            byte firstDigitUtf8 = line[firstDigitIndex];
            byte lastDigitUtf8 = line[lastDigitIndex];

            int firstDigit = firstDigitUtf8 - Zero;
            int lastDigit = lastDigitUtf8 - Zero;

            int number = firstDigit * 10 + lastDigit;
            sum += number;

            input = input[(indexOfNewLine + 1)..];
        }
        while (input.Length != 0);

        return sum;
    }

    public int SolvePartTwo()
    {
        const byte LineFeed = (byte)'\n';

        int sum = 0;

        ReadOnlySpan<byte> input = InputUtf8;
        do
        {
            int indexOfNewLine = input.IndexOf(LineFeed);
            ReadOnlySpan<byte> line = input[..indexOfNewLine];

            sum += FindNumber(line);

            input = input[(indexOfNewLine + 1)..];
        }
        while (input.Length != 0);

        return sum;
    }

    private static unsafe int FindNumber(ReadOnlySpan<byte> line)
    {
        int firstDigit = 0;
        int secondDigit = 0;

        while (firstDigit == 0)
        {
            byte* linePtr = (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(line));
            int firstIndex = line.IndexOfAny(s_digitAndTextSearchValues);
            byte firstUtf8 = linePtr[firstIndex];
            if (IsDigit(firstUtf8))
            {
                firstDigit = firstUtf8 - Zero;
            }
            else
            {
                byte* text = linePtr + firstIndex;
                line = TryParseText(text, line.Length, out firstDigit, out int firstDigitLength)
                    ? line[(firstIndex + firstDigitLength)..]
                    : line[(firstIndex + 1)..];
            }
        }

        if (line.Length == 0)
        {
            secondDigit = firstDigit;
#pragma warning disable S907
            goto Result;
#pragma warning restore S907
        }

        ReadOnlySpan<byte> lineSearch = line;
        while (secondDigit == 0)
        {
            byte* linePtr = (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(line));
            int secondIndex = lineSearch.LastIndexOfAny(s_digitAndTextSearchValues);
            byte secondUtf8 = linePtr[secondIndex];
            if (IsDigit(secondUtf8))
            {
                secondDigit = secondUtf8 - Zero;
            }
            else
            {
                byte* text = linePtr + secondIndex;
                if (TryParseText(text, line.Length - secondIndex, out secondDigit, out _))
                {
                    break;
                }

                lineSearch = lineSearch[..secondIndex];
            }

            if (lineSearch.Length == 0)
            {
                break;
            }
        }

        if (secondDigit == 0)
        {
            secondDigit = firstDigit;
        }

    Result:
        return firstDigit * 10 + secondDigit;
    }

    private static unsafe bool TryParseText(byte* text, int lineLength, out int firstDigit, out int firstDigitLength)
    {
        firstDigit = 0;
        firstDigitLength = 0;

        switch (lineLength)
        {
            case >= 5 when new ReadOnlySpan<byte>(text, 5).SequenceEqual("seven"u8):
                firstDigit = 7;
                firstDigitLength = 5;
                break;
            case >= 5 when new ReadOnlySpan<byte>(text, 5).SequenceEqual("eight"u8):
                firstDigit = 8;
                firstDigitLength = 5;
                break;
            case >= 5 when new ReadOnlySpan<byte>(text, 5).SequenceEqual("three"u8):
                firstDigit = 3;
                firstDigitLength = 5;
                break;
            case >= 4 when new ReadOnlySpan<byte>(text, 4).SequenceEqual("four"u8):
                firstDigit = 4;
                firstDigitLength = 4;
                break;
            case >= 4 when new ReadOnlySpan<byte>(text, 4).SequenceEqual("five"u8):
                firstDigit = 5;
                firstDigitLength = 4;
                break;
            case >= 4 when new ReadOnlySpan<byte>(text, 4).SequenceEqual("nine"u8):
                firstDigit = 9;
                firstDigitLength = 4;
                break;
            case >= 3 when new ReadOnlySpan<byte>(text, 3).SequenceEqual("one"u8):
                firstDigit = 1;
                firstDigitLength = 3;
                break;
            case >= 3 when new ReadOnlySpan<byte>(text, 3).SequenceEqual("two"u8):
                firstDigit = 2;
                firstDigitLength = 3;
                break;
            case >= 3 when new ReadOnlySpan<byte>(text, 3).SequenceEqual("six"u8):
                firstDigit = 6;
                firstDigitLength = 3;
                break;
            default:
                return false;
        }

        return true;
    }

    private static bool IsDigit(byte b) => b is >= (byte)'0' and <= (byte)'9';
}
