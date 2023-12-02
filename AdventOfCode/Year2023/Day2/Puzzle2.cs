using System;
using HLE.Numerics;

namespace AdventOfCode.Year2023.Day2;

public sealed unsafe class Puzzle2() : Puzzle("Year2023.Day2.input.txt")
{
    private const int RedCubeCount = 12;
    private const int GreenCubeCount = 13;
    private const int BlueCubeCount = 14;

    private const byte CarriageReturn = (byte)'\r';
    private const byte Colon = (byte)':';
    private const byte SemiColon = (byte)';';
    private const byte Comma = (byte)',';
    private const byte Whitespace = (byte)' ';

    public int SolvePartOne()
    {
        ReadOnlySpan<byte> input = _input.AsSpan();

        int gameIdSum = 0;
        int currentGameId = 1;

        while (true)
        {
            int indexOfLineEnd = input.IndexOf(CarriageReturn);
            ReadOnlySpan<byte> line = input[..indexOfLineEnd];

            int index = line.IndexOf(Colon);
            line = line[(index + 2)..];

            Game game = default;
            HandleGame(line, &game);
            bool isPossible = IsPossible(&game);
            if (isPossible)
            {
                gameIdSum += currentGameId;
            }

            currentGameId++;
            input = input[(indexOfLineEnd + 2)..];
            if (input.Length == 0)
            {
                break;
            }
        }

        return gameIdSum;
    }

    public int SolvePartTwo()
    {
        ReadOnlySpan<byte> input = _input.AsSpan();

        int powerSum = 0;

        while (true)
        {
            int indexOfLineEnd = input.IndexOf(CarriageReturn);
            ReadOnlySpan<byte> line = input[..indexOfLineEnd];

            int index = line.IndexOf(Colon);
            line = line[(index + 2)..];

            Game game = default;
            HandleGame(line, &game);
            powerSum += game.MaxRed * game.MaxGreen * game.MaxBlue;

            input = input[(indexOfLineEnd + 2)..];
            if (input.Length == 0)
            {
                break;
            }
        }

        return powerSum;
    }

    private static void HandleGame(ReadOnlySpan<byte> line, Game* game)
    {
        while (true)
        {
            int index = line.IndexOf(SemiColon);
            ReadOnlySpan<byte> roundText;
            if (index == -1)
            {
                roundText = line;
                line = [];
            }
            else
            {
                roundText = line[..index];
                line = line[(index + 2)..];
            }

            Round round = default;
            HandleRound(roundText, &round);

            game->MaxRed = int.Max(round.Red, game->MaxRed);
            game->MaxGreen = int.Max(round.Green, game->MaxGreen);
            game->MaxBlue = int.Max(round.Blue, game->MaxBlue);

            if (line.Length == 0)
            {
                break;
            }
        }
    }

    private static void HandleRound(ReadOnlySpan<byte> roundText, Round* round)
    {
        while (true)
        {
            int index = roundText.IndexOf(Comma);
            ReadOnlySpan<byte> takeText;
            if (index == -1)
            {
                takeText = roundText;
                roundText = [];
            }
            else
            {
                takeText = roundText[..index];
                roundText = roundText[(index + 2)..];
            }

            Take take = HandleTake(takeText);
            byte* roundBytes = (byte*)round;
            roundBytes += (int)take.Color * sizeof(int);
            int* roundField = (int*)roundBytes;
            *roundField = take.Count;

            if (roundText.Length == 0)
            {
                break;
            }
        }
    }

    private static Take HandleTake(ReadOnlySpan<byte> takeText)
    {
        int index = takeText.IndexOf(Whitespace);

        ReadOnlySpan<byte> countText = takeText[..index];
        ReadOnlySpan<byte> colorText = takeText[(index + 1)..];

        Take take = default;
        take.Count = NumberHelpers.ParsePositiveNumber<int>(countText);
        take.Color = colorText[0] switch
        {
            (byte)'r' => Color.Red,
            (byte)'g' => Color.Green,
            (byte)'b' => Color.Blue,
            _ => throw new InvalidOperationException()
        };

        return take;
    }

    private static bool IsPossible(Game* game)
        => game->MaxRed <= RedCubeCount && game->MaxGreen <= GreenCubeCount && game->MaxBlue <= BlueCubeCount;
}
