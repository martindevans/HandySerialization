namespace HandySerialization.Tests;

public readonly struct TestWriterReader
    : IByteWriter, IByteReader
{
    private readonly List<byte> _bytes = [ ];

    public TestWriterReader()
    {
    }

    public void Write(ReadOnlySpan<byte> value)
    {
        _bytes.AddRange(value);
    }


    public long UnreadBytes => _bytes.Count;

    public void ReadBytes(Span<byte> dest)
    {
        _bytes[..dest.Length].CopyTo(dest);
        _bytes.RemoveRange(0, dest.Length);
    }
}