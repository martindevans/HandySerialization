namespace HandySerialization.Extensions.Collections;

public interface ISerializationAdapter<TType>
{
    void Write<TWriter>(ref TWriter writer, TType value)
        where TWriter : struct, IByteWriter;

    TType Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader;
}

public struct GenericAdapter<TValue>
    : ISerializationAdapter<TValue>
    where TValue : IByteSerializable<TValue>, new()
{
    public void Write<TWriter>(ref TWriter writer, TValue value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public TValue Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.Read<TReader, TValue>();
    }
}

public struct StringAdapter
    : ISerializationAdapter<string>
{
    public void Write<TWriter>(ref TWriter writer, string value)
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
    public void Write<TWriter>(ref TWriter writer, string? value)
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