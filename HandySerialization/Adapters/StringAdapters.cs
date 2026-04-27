using HandySerialization.Extensions;

namespace HandySerialization.Adapters;

public struct StringAdapter
    : ISerializationAdapter<string>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly string value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public string Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadString()!;
    }
}

public struct NullableStringAdapter
    : ISerializationAdapter<string?>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly string? value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public string? Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadString();
    }
}