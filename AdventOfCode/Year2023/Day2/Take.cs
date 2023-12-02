using System.Runtime.InteropServices;

namespace AdventOfCode.Year2023.Day2;

#pragma warning disable

[StructLayout(LayoutKind.Sequential)]
public struct Take
{
    public int Count;

    public Color Color;
}
