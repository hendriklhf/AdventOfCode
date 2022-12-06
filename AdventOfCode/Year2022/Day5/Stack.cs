namespace AdventOfCode.Year2022.Day5;

public unsafe ref struct Stack
{
    private readonly byte* _stack;
    private byte _count = 0;

    public Stack(byte* stack, byte count = 0)
    {
        _stack = stack;
        _count = count;
    }

    public byte Pop() => _stack[--_count];

    public void Push(byte b)
    {
        _stack[_count++] = b;
    }

    public readonly byte Peek() => _stack[_count - 1];
}
