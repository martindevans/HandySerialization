using HandySerialization.Adapters;

namespace HandySerialization.Extensions;

public static class Adapter
{
    public static void Write<TWriter, TAdapter, TValue>(ref this TWriter writer, ref readonly TValue value)
        where TWriter : struct, IByteWriter
        where TAdapter : ISerializationAdapter<TValue>, new()
    {
        writer.Write(new TAdapter(), in value);
    }

    public static void Write<TWriter, TAdapter, TValue>(ref this TWriter writer, TAdapter adapter, ref readonly TValue value)
        where TWriter : struct, IByteWriter
        where TAdapter : ISerializationAdapter<TValue>
    {
        adapter.Write(ref writer, in value);
    }

    public static TValue Read<TReader, TAdapter, TValue>(ref this TReader reader)
        where TReader : struct, IByteReader
        where TAdapter : ISerializationAdapter<TValue>, new()
    {
        return reader.Read<TReader, TAdapter, TValue>(new TAdapter());
    }

    public static TValue Read<TReader, TAdapter, TValue>(ref this TReader reader, TAdapter adapter)
        where TReader : struct, IByteReader
        where TAdapter : ISerializationAdapter<TValue>
    {
        return adapter.Read(ref reader);
    }
}