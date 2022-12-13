using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdventOfCode.Year2022.Day07;

public unsafe struct Directory
{
    public readonly ReadOnlySpan<char> Name => new(_name, _nameLength);

    public Directory* Parent { get; }

    public Directory* ChildDirectories { get; }

    public int ChildCount { get; private set; }

    public ulong Size { get; set; }

    public readonly ulong TotalSize => GetTotalSize();

    private readonly char* _name;
    private readonly int _nameLength;

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public Directory(ReadOnlySpan<char> name, Span<Directory> childDirectories, Directory* parent)
    {
        ref char firstChar = ref MemoryMarshal.GetReference(name);
        _name = (char*)Unsafe.AsPointer(ref firstChar);
        _nameLength = name.Length;

        ref Directory firstChild = ref MemoryMarshal.GetReference(childDirectories);
        ChildDirectories = (Directory*)Unsafe.AsPointer(ref firstChild);

        Parent = parent;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddChildDirectory(Directory* directory)
    {
        ChildDirectories[ChildCount++] = *directory;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public readonly Directory* GetChildDirectoryByName(ReadOnlySpan<char> name)
    {
        for (int i = 0; i < ChildCount; i++)
        {
            Directory* child = &ChildDirectories[i];
            if (child->Name.Equals(name, StringComparison.Ordinal))
            {
                return child;
            }
        }

        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private readonly ulong GetTotalSize()
    {
        ulong result = Size;
        for (int i = 0; i < ChildCount; i++)
        {
            Directory* child = &ChildDirectories[i];
            result += child->TotalSize;
        }

        return result;
    }
}
