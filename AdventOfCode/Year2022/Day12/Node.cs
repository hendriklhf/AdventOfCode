using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2022.Day12;

public struct Node
{
    public byte X { get; }

    public byte Y { get; }

    public byte Height { get; }

    public ushort Distance { get; set; }

    public bool Visited { get; set; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Node(byte x, byte y, byte height)
    {
        X = x;
        Y = y;
        Height = height;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool CanVisit(byte height)
    {
        return height <= Height + 1;
    }
}
