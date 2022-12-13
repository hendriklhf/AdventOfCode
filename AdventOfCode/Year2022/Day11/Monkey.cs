using System;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Year2022.Day11;

public unsafe struct Monkey
{
    public ulong InspectCount { get; private set; }

    public ulong* Items { get; }

    public int ItemCount { get; set; }

    private readonly char _inspectOperation;
    private readonly byte _inspectChange;
    private readonly byte _divideBy;
    private readonly byte _testTrue;
    private readonly byte _testFalse;

    public Monkey(Span<ulong> items, byte itemCount, char inspectOperation, byte inspectChange, byte divideBy, byte testTrue, byte testFalse)
    {
        Items = (ulong*)Unsafe.AsPointer(ref items[0]);
        ItemCount = itemCount;
        _divideBy = divideBy;
        _inspectOperation = inspectOperation;
        _inspectChange = inspectChange;
        _testTrue = testTrue;
        _testFalse = testFalse;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ulong Inspect(ulong oldWorryLevel)
    {
        InspectCount++;
        return _inspectChange switch
        {
            0 => oldWorryLevel * oldWorryLevel,
            _ => _inspectOperation switch
            {
                '+' => oldWorryLevel + _inspectChange,
                '*' => oldWorryLevel * _inspectChange,
                _ => throw new ArgumentOutOfRangeException()
            }
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly byte GetThrowTarget(ulong worryLevel)
    {
        return worryLevel % _divideBy == 0 ? _testTrue : _testFalse;
    }
}
