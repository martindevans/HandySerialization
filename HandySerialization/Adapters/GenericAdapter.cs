using HandySerialization.Extensions;

namespace HandySerialization.Adapters;

public struct GenericAdapter<TValue>
    : ISerializationAdapter<TValue>
    where TValue : IByteSerializable<TValue>, new()
{
    public void Write<TWriter>(ref TWriter writer, ref readonly TValue value)
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