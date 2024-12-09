using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HLE.Collections;
using HLE.Memory;
using HLE.Numerics;

namespace AdventOfCode.Year2024.Day7;

public sealed partial class Puzzle7() : Puzzle("AdventOfCode.Year2024.Day7.input.txt")
{
    public async Task<ulong> SolvePartOneAsync()
    {
        ReadOnlySpan<byte> input = InputUtf8;
        using NativeMemory<uint> buffer = new(16 * 2, false);
        int middleIndex = input[(input.Length / 2)..].IndexOf((byte)'\n') + input.Length / 2;

        ReadOnlySpan<byte> firstHalf = input[..middleIndex];
        ReadOnlySpan<byte> secondHalf = input[(middleIndex + 1)..];

        Task<ulong> firstHalfTask = Task.Factory.StartNew(CheckInput, new State(ref buffer.Reference, firstHalf), default, TaskCreationOptions.None, TaskScheduler.Default);
        Task<ulong> secondHalfTask = Task.Factory.StartNew(CheckInput, new State(ref Unsafe.Add(ref buffer.Reference, 16), secondHalf), default, TaskCreationOptions.None, TaskScheduler.Default);

        ulong firstResult = await firstHalfTask;
        ulong secondResult = await secondHalfTask;

        return firstResult + secondResult;
    }

    private static unsafe ulong CheckInput(object? state)
    {
        ReadOnlySpan<byte> input = Unsafe.As<State>(state)!.Input;
        uint* numbers = Unsafe.As<State>(state)!.Numbers;

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

    private static unsafe bool CheckLine(ulong testValue, uint* numbers, int numbersLength)
        => CheckLine(testValue, *numbers, numbers + 1, numbers + numbersLength - 1);

    [SkipLocalsInit]
    private static unsafe bool CheckLine(ulong testValue, ulong value, uint* numbers, uint* end)
    {
        if (numbers == end)
        {
            return value + *numbers == testValue || value * *numbers == testValue;
        }

        if (value >= testValue)
        {
            return false;
        }

        return CheckLine(testValue, value + *numbers, numbers + 1, end) ||
               CheckLine(testValue, value * *numbers, numbers + 1, end);
    }
}
