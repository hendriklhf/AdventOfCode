using System.Runtime.InteropServices;

namespace AdventOfCode.Year2023.Day2;

#pragma warning disable

[StructLayout(LayoutKind.Sequential)]
public struct Game
{
    public int MaxRed;

    public int MaxGreen;

    public int MaxBlue;
}
