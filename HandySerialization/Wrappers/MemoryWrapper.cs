namespace HandySerialization.Wrappers;

public struct MemoryByteWriter(Memory<byte> memory)
    : IByteWriter
{
    public int Written { get; private set; }

    public void Write(ReadOnlySpan<byte> value)
    {
        value.CopyTo(memory[Written..].Span);
        Written += value.Length;
    }
}

public struct MemoryByteReader(ReadOnlyMemory<byte> memory)
    : IByteReader
{
    private int _readBytes = 0;
    public readonly long UnreadBytes => memory.Length - _readBytes;

    public void ReadBytes(Span<byte> dest)
    {
        memory.Slice(_readBytes, dest.Length).Span.CopyTo(dest);
        _readBytes += dest.Length;
    }

    public ReadOnlySpan<byte> ReadBytes(int count)
    {
        var slice = memory.Slice(_readBytes, count).Span;
        _readBytes += count;
        return slice;
    }
}