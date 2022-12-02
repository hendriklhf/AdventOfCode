using System;
using HLE;

namespace AdventOfCode.Year2022.Day2;

public sealed class Puzzle2 : Puzzle
{
    private const byte _rockOpponent = 65;
    private const byte _paperOpponent = 66;
    private const byte _scissorsOpponent = 67;
    private const byte _rockMe = 88;
    private const byte _paperMe = 89;
    private const byte _scissorsMe = 90;

    private const byte _rockBonus = 1;
    private const byte _paperBonus = 2;
    private const byte _scissorsBonus = 3;

    private const byte _win = 6;
    private const byte _draw = 3;
    private const byte _loss = 0;

    public Puzzle2() : base("Year2022.Day2.Input.txt")
    {
    }

    public ushort Solve()
    {
        ReadOnlySpan<char> input = _input;
        input = input[..^2];
        Span<Range> lineRanges = stackalloc Range[input.Length];
        int lineRangesLength = input.GetRangesOfSplit(Environment.NewLine, lineRanges);
        lineRanges = lineRanges[..lineRangesLength];

        ushort score = 0;
        for (int i = 0; i < lineRangesLength; i++)
        {
            ReadOnlySpan<char> line = input[lineRanges[i]];
            byte opponent = (byte)line[0];
            byte me = (byte)line[2];

            switch (me)
            {
                case _rockMe:
                {
                    score += _rockBonus;
                    score += opponent switch
                    {
                        _rockOpponent => _draw,
                        _paperOpponent => _loss,
                        _scissorsOpponent => _win,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                }
                case _paperMe:
                {
                    score += _paperBonus;
                    score += opponent switch
                    {
                        _rockOpponent => _win,
                        _paperOpponent => _draw,
                        _scissorsOpponent => _loss,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                }
                case _scissorsMe:
                {
                    score += _scissorsBonus;
                    score += opponent switch
                    {
                        _rockOpponent => _loss,
                        _paperOpponent => _win,
                        _scissorsOpponent => _draw,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                }
            }
        }

        return score;
    }
}
