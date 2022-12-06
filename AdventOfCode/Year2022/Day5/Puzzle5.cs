using System;
using HLE;

namespace AdventOfCode.Year2022.Day5;

public sealed class Puzzle5 : Puzzle
{
    private const byte _stackSize = 50;

    public Puzzle5() : base("Year2022.Day5.Input.txt")
    {
    }

    public unsafe string SolvePart1()
    {
        #region Stacks

        //scuffed stack creation but didnt find another way, if there is even one
        byte* stack1 = stackalloc byte[_stackSize];
        stack1[0] = (byte)'N';
        stack1[1] = (byte)'R';
        stack1[2] = (byte)'G';
        stack1[3] = (byte)'P';
        byte* stack2 = stackalloc byte[_stackSize];
        stack2[0] = (byte)'J';
        stack2[1] = (byte)'T';
        stack2[2] = (byte)'B';
        stack2[3] = (byte)'L';
        stack2[4] = (byte)'F';
        stack2[5] = (byte)'G';
        stack2[6] = (byte)'D';
        stack2[7] = (byte)'C';
        byte* stack3 = stackalloc byte[_stackSize];
        stack3[0] = (byte)'M';
        stack3[1] = (byte)'S';
        stack3[2] = (byte)'V';
        byte* stack4 = stackalloc byte[_stackSize];
        stack4[0] = (byte)'L';
        stack4[1] = (byte)'S';
        stack4[2] = (byte)'R';
        stack4[3] = (byte)'C';
        stack4[4] = (byte)'Z';
        stack4[5] = (byte)'P';
        byte* stack5 = stackalloc byte[_stackSize];
        stack5[0] = (byte)'P';
        stack5[1] = (byte)'S';
        stack5[2] = (byte)'L';
        stack5[3] = (byte)'V';
        stack5[4] = (byte)'C';
        stack5[5] = (byte)'W';
        stack5[6] = (byte)'D';
        stack5[7] = (byte)'Q';
        byte* stack6 = stackalloc byte[_stackSize];
        stack6[0] = (byte)'C';
        stack6[1] = (byte)'T';
        stack6[2] = (byte)'N';
        stack6[3] = (byte)'W';
        stack6[4] = (byte)'D';
        stack6[5] = (byte)'M';
        stack6[6] = (byte)'S';
        byte* stack7 = stackalloc byte[_stackSize];
        stack7[0] = (byte)'H';
        stack7[1] = (byte)'D';
        stack7[2] = (byte)'G';
        stack7[3] = (byte)'W';
        stack7[4] = (byte)'P';
        byte* stack8 = stackalloc byte[_stackSize];
        stack8[0] = (byte)'Z';
        stack8[1] = (byte)'L';
        stack8[2] = (byte)'P';
        stack8[3] = (byte)'H';
        stack8[4] = (byte)'S';
        stack8[5] = (byte)'C';
        stack8[6] = (byte)'M';
        stack8[7] = (byte)'V';
        byte* stack9 = stackalloc byte[_stackSize];
        stack9[0] = (byte)'R';
        stack9[1] = (byte)'P';
        stack9[2] = (byte)'L';
        stack9[3] = (byte)'W';
        stack9[4] = (byte)'G';
        stack9[5] = (byte)'Z';

        Stack* stacks = stackalloc Stack[]
        {
            new(stack1, 4),
            new(stack2, 8),
            new(stack3, 3),
            new(stack4, 6),
            new(stack5, 8),
            new(stack6, 7),
            new(stack7, 5),
            new(stack8, 8),
            new(stack9, 7)
        };

        #endregion Stacks

        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[512];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Span<Range> ranges = stackalloc Range[6];
        for (int i = 10; i < 512; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            line.GetRangesOfSplit(' ', ranges);
            byte count = byte.Parse(line[ranges[1]]);
            byte source = (byte)(byte.Parse(line[ranges[3]]) - 1);
            byte destination = (byte)(byte.Parse(line[ranges[5]]) - 1);

            for (int j = 0; j < count; j++)
            {
                byte item = stacks[source].Pop();
                stacks[destination].Push(item);
            }
        }

        Span<char> chars = stackalloc char[9];
        for (int i = 0; i < 9; i++)
        {
            chars[i] = (char)stacks[i].Peek();
        }

        return new(chars);
    }

    public unsafe string SolvePart2()
    {
        #region Stacks

        //scuffed stack creation but didnt find another way, if there is even one
        byte* stack1 = stackalloc byte[_stackSize];
        stack1[0] = (byte)'N';
        stack1[1] = (byte)'R';
        stack1[2] = (byte)'G';
        stack1[3] = (byte)'P';
        byte* stack2 = stackalloc byte[_stackSize];
        stack2[0] = (byte)'J';
        stack2[1] = (byte)'T';
        stack2[2] = (byte)'B';
        stack2[3] = (byte)'L';
        stack2[4] = (byte)'F';
        stack2[5] = (byte)'G';
        stack2[6] = (byte)'D';
        stack2[7] = (byte)'C';
        byte* stack3 = stackalloc byte[_stackSize];
        stack3[0] = (byte)'M';
        stack3[1] = (byte)'S';
        stack3[2] = (byte)'V';
        byte* stack4 = stackalloc byte[_stackSize];
        stack4[0] = (byte)'L';
        stack4[1] = (byte)'S';
        stack4[2] = (byte)'R';
        stack4[3] = (byte)'C';
        stack4[4] = (byte)'Z';
        stack4[5] = (byte)'P';
        byte* stack5 = stackalloc byte[_stackSize];
        stack5[0] = (byte)'P';
        stack5[1] = (byte)'S';
        stack5[2] = (byte)'L';
        stack5[3] = (byte)'V';
        stack5[4] = (byte)'C';
        stack5[5] = (byte)'W';
        stack5[6] = (byte)'D';
        stack5[7] = (byte)'Q';
        byte* stack6 = stackalloc byte[_stackSize];
        stack6[0] = (byte)'C';
        stack6[1] = (byte)'T';
        stack6[2] = (byte)'N';
        stack6[3] = (byte)'W';
        stack6[4] = (byte)'D';
        stack6[5] = (byte)'M';
        stack6[6] = (byte)'S';
        byte* stack7 = stackalloc byte[_stackSize];
        stack7[0] = (byte)'H';
        stack7[1] = (byte)'D';
        stack7[2] = (byte)'G';
        stack7[3] = (byte)'W';
        stack7[4] = (byte)'P';
        byte* stack8 = stackalloc byte[_stackSize];
        stack8[0] = (byte)'Z';
        stack8[1] = (byte)'L';
        stack8[2] = (byte)'P';
        stack8[3] = (byte)'H';
        stack8[4] = (byte)'S';
        stack8[5] = (byte)'C';
        stack8[6] = (byte)'M';
        stack8[7] = (byte)'V';
        byte* stack9 = stackalloc byte[_stackSize];
        stack9[0] = (byte)'R';
        stack9[1] = (byte)'P';
        stack9[2] = (byte)'F';
        stack9[3] = (byte)'L';
        stack9[4] = (byte)'W';
        stack9[5] = (byte)'G';
        stack9[6] = (byte)'Z';

        Stack* stacks = stackalloc Stack[]
        {
            new(stack1, 4),
            new(stack2, 8),
            new(stack3, 3),
            new(stack4, 6),
            new(stack5, 8),
            new(stack6, 7),
            new(stack7, 5),
            new(stack8, 8),
            new(stack9, 7)
        };

        #endregion Stacks

        ReadOnlySpan<char> input = _input;
        Span<Range> lineRanges = stackalloc Range[512];
        input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        Span<Range> ranges = stackalloc Range[6];
        byte* stackBuffer = stackalloc byte[50];
        for (int i = 10; i < 512; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            line.GetRangesOfSplit(' ', ranges);
            byte count = byte.Parse(line[ranges[1]]);
            byte source = (byte)(byte.Parse(line[ranges[3]]) - 1);
            byte destination = (byte)(byte.Parse(line[ranges[5]]) - 1);

            Stack stack = new(stackBuffer);
            for (int j = 0; j < count; j++)
            {
                byte item = stacks[source].Pop();
                stack.Push(item);
            }

            for (int j = 0; j < count; j++)
            {
                byte item = stack.Pop();
                stacks[destination].Push(item);
            }
        }

        Span<char> chars = stackalloc char[9];
        for (int i = 0; i < 9; i++)
        {
            chars[i] = (char)stacks[i].Peek();
        }

        return new(chars);
    }
}
