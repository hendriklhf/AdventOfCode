using System;
using System.Diagnostics;
using HLE.Collections;
using HLE.Numerics;

namespace AdventOfCode.Year2024.Day7;

public sealed unsafe class Puzzle7() : Puzzle("AdventOfCode.Year2024.Day7.input.txt")
{
    public ulong SolvePartOne()
    {
        ReadOnlySpan<byte> input = InputUtf8;
        uint* numbers = stackalloc uint[16];
        ulong result = 0;
        do
        {
            int newLineIndex = input.IndexOf((byte)'\n');
            ReadOnlySpan<byte> line = newLineIndex >= 0 ? input.SliceUnsafe(..newLineIndex) : input;
            int colonIndex = line.IndexOf((byte)':');
            ulong testValue = NumberHelpers.ParsePositiveNumber<ulong>(line.SliceUnsafe(..colonIndex));

            ReadOnlySpan<byte> numbersText = line.SliceUnsafe((colonIndex + 2)..);
            int i = 0;
            do
            {
                int spaceIndex = numbersText.IndexOf((byte)' ');
                ReadOnlySpan<byte> numberText = spaceIndex >= 0 ? numbersText.SliceUnsafe(..spaceIndex) : numbersText;
                numbers[i++] = NumberHelpers.ParsePositiveNumber<uint>(numberText);
                numbersText = spaceIndex >= 0 ? numbersText.SliceUnsafe((spaceIndex + 1)..) : [];
            }
            while (numbersText.Length != 0);

            if (CheckLine(testValue, numbers, i))
            {
                result += testValue;
            }

            input = newLineIndex >= 0 ? input.SliceUnsafe((newLineIndex + 1)..) : [];
        }
        while (input.Length != 0);

        return result;
    }

    private static bool CheckLine(ulong testValue, uint* numbers, int numbersLength)
    {
        Debug.Assert(numbersLength <= 16);

        ushort operators = 0;
        int last = numbersLength - 1;
        ushort end = (ushort)(ushort.MaxValue >> (16 - last));
        do
        {
            ulong result = *numbers;
            for (int i = 0; i < last; i++)
            {
                if ((operators & (1 << i)) == 0)
                {
                    result += numbers[i + 1];
                }
                else
                {
                    result *= numbers[i + 1];
                }
            }

            if (result == testValue)
            {
                return true;
            }

            operators++;
        }
        while (operators <= end);

        return false;
    }
}
