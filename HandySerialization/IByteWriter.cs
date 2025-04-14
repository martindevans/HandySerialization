using HandySerialization.Wrappers;

namespace HandySerialization;

public interface IByteWriter
{
    void Write(ReadOnlySpan<byte> value);
}

public static class IByteWriterExtensions
{
    public static BitWriter<TSelf> AsBitWriter<TSelf>(this TSelf byteWriter)
        where TSelf : struct, IByteWriter
    {
        return new BitWriter<TSelf>(byteWriter);
    }
}