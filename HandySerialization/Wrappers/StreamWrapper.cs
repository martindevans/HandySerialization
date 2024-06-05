namespace HandySerialization.Wrappers;

public readonly struct StreamByteWriter(Stream stream)
    : IByteWriter
{
    public void Write(ReadOnlySpan<byte> value)
    {
#if NET8_0_OR_GREATER
        stream.Write(value);
#else
        for (var i = 0; i < value.Length; i++)
            stream.WriteByte(value[i]);
#endif
    }
}

public readonly struct StreamByteReader(Stream stream)
    : IByteReader
{
    public long UnreadBytes => stream.Length - stream.Position;

    public void ReadBytes(Span<byte> dest)
    {
#if NET8_0_OR_GREATER
        stream.ReadExactly(dest);
#else
        if (UnreadBytes < dest.Length)
            throw new EndOfStreamException();

        for (var i = 0; i < dest.Length; i++)
            dest[i] = checked((byte)(stream.ReadByte()));
#endif
    }

}