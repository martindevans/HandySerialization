namespace HandySerialization;

public interface IByteWriter
{
    void Write(ReadOnlySpan<byte> value);
}