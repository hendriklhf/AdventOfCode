using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2022.Day10;

public struct Task
{
    public byte ClockCount { get; } = 1;

    public sbyte Value { get; }

    public readonly bool Completed => ClockCount == _process;

    private byte _process;

    public static Task Nop { get; } = new();

    public Task()
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task(sbyte value)
    {
        ClockCount = 2;
        Value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Work()
    {
        _process++;
    }
}
