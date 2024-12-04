using System;
using System.Runtime.CompilerServices;
using HLE.Collections;

namespace AdventOfCode.Year2024.Day4;

public sealed unsafe class Puzzle4 : Puzzle
{
    private readonly uint _lineLength;
    private readonly uint _lineCount;

    private const uint NeedleLength = 4;
    private const byte X = (byte)'X';
    private const byte M = (byte)'M';
    private const byte A = (byte)'A';
    private const byte S = (byte)'S';

    public Puzzle4() : base("AdventOfCode.Year2024.Day4.input.txt")
    {
        ReadOnlySpan<byte> input = InputUtf8;
        _lineLength = (uint)input.IndexOf((byte)'\n');
        _lineCount = (uint)(input.Count((byte)'\n')) + 1;
    }

    [SkipLocalsInit]
    public uint SolvePartOne()
    {
        ReadOnlySpan<byte> input = InputUtf8;
        byte* inputPtr = InputUtf8Pointer;
        uint result = 0;

        int offset = 0;
        int index = input.IndexOf(X);
        while (index >= 0)
        {
            index += offset;

            (uint x, uint y) = ConvertIndexToCoordinates(index);
            if (CheckTop(inputPtr, x, y))
            {
                result++;
            }

            if (CheckTopRight(inputPtr, x, y))
            {
                result++;
            }

            if (CheckRight(inputPtr, x, y))
            {
                result++;
            }

            if (CheckBottomRight(inputPtr, x, y))
            {
                result++;
            }

            if (CheckBottom(inputPtr, x, y))
            {
                result++;
            }

            if (CheckBottomLeft(inputPtr, x, y))
            {
                result++;
            }

            if (CheckLeft(inputPtr, x, y))
            {
                result++;
            }

            if (CheckTopLeft(inputPtr, x, y))
            {
                result++;
            }

            offset = index + 1;
            index = input.SliceUnsafe(offset..).IndexOf((byte)'X');
        }

        return result;
    }

    private bool CheckTop(byte* input, uint x, uint y)
    {
        if (y < NeedleLength - 1)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x, y - 1)] == M &&
               input[ConvertCoordinatesToIndex(x, y - 2)] == A &&
               input[ConvertCoordinatesToIndex(x, y - 3)] == S;
    }

    private bool CheckTopRight(byte* input, uint x, uint y)
    {
        if (y < NeedleLength - 1 || x > _lineLength - NeedleLength)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x + 1, y - 1)] == M &&
               input[ConvertCoordinatesToIndex(x + 2, y - 2)] == A &&
               input[ConvertCoordinatesToIndex(x + 3, y - 3)] == S;
    }

    private bool CheckRight(byte* input, uint x, uint y)
    {
        if (x > _lineLength - NeedleLength)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x + 1, y)] == M &&
               input[ConvertCoordinatesToIndex(x + 2, y)] == A &&
               input[ConvertCoordinatesToIndex(x + 3, y)] == S;
    }

    private bool CheckBottomRight(byte* input, uint x, uint y)
    {
        if (x > _lineLength - NeedleLength || y > _lineCount - NeedleLength)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x + 1, y + 1)] == M &&
               input[ConvertCoordinatesToIndex(x + 2, y + 2)] == A &&
               input[ConvertCoordinatesToIndex(x + 3, y + 3)] == S;
    }

    private bool CheckBottom(byte* input, uint x, uint y)
    {
        if (y > _lineCount - NeedleLength)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x, y + 1)] == M &&
               input[ConvertCoordinatesToIndex(x, y + 2)] == A &&
               input[ConvertCoordinatesToIndex(x, y + 3)] == S;
    }

    private bool CheckBottomLeft(byte* input, uint x, uint y)
    {
        if (y > _lineCount - NeedleLength || x < NeedleLength - 1)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x - 1, y + 1)] == M &&
               input[ConvertCoordinatesToIndex(x - 2, y + 2)] == A &&
               input[ConvertCoordinatesToIndex(x - 3, y + 3)] == S;
    }

    private bool CheckLeft(byte* input, uint x, uint y)
    {
        if (x < NeedleLength - 1)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x - 1, y)] == M &&
               input[ConvertCoordinatesToIndex(x - 2, y)] == A &&
               input[ConvertCoordinatesToIndex(x - 3, y)] == S;
    }

    private bool CheckTopLeft(byte* input, uint x, uint y)
    {
        if (y < NeedleLength - 1 || x < NeedleLength - 1)
        {
            return false;
        }

        return input[ConvertCoordinatesToIndex(x - 1, y - 1)] == M &&
               input[ConvertCoordinatesToIndex(x - 2, y - 2)] == A &&
               input[ConvertCoordinatesToIndex(x - 3, y - 3)] == S;
    }

    private (uint X, uint Y) ConvertIndexToCoordinates(int index)
    {
        (uint y, uint x) = Math.DivRem((uint)index, _lineLength + 1);
        return (x, y);
    }

    private int ConvertCoordinatesToIndex(uint x, uint y) => (int)(y * _lineLength + y + x);
}
