using System.Runtime.InteropServices;

namespace AdventOfCode.Year2023.Day2;

#pragma warning disable

[StructLayout(LayoutKind.Sequential)]
public struct Round
{
    public int Red;

    public int Green;

    public int Blue;
}
