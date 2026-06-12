using HandySerialization.Adapters;

namespace HandySerialization.Extensions;

public static class Adapter
{
    /// <summary>
    /// Write a value, using an adapter type.
    /// </summary>
    /// <typeparam name="TWriter"></typeparam>
    /// <typeparam name="TAdapter"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void Write<TWriter, TAdapter, TValue>(ref this TWriter writer, ref readonly TValue value)
        where TWriter : struct, IByteWriter
        where TAdapter : ISerializationAdapter<TValue>, new()
    {
        writer.Write(new TAdapter(), in value);
    }

    /// <summary>
    /// Write a value, using an adapter.
    /// </summary>
    /// <typeparam name="TWriter"></typeparam>
    /// <typeparam name="TAdapter"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="writer"></param>
    /// <param name="adapter"></param>
    /// <param name="value"></param>
    public static void Write<TWriter, TAdapter, TValue>(ref this TWriter writer, TAdapter adapter, ref readonly TValue value)
        where TWriter : struct, IByteWriter
        where TAdapter : ISerializationAdapter<TValue>
    {
        adapter.Write(ref writer, in value);
    }

    /// <summary>
    /// Read a value, using an adapter type.
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TAdapter"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="reader"></param>
    /// <returns></returns>
    public static TValue Read<TReader, TAdapter, TValue>(ref this TReader reader)
        where TReader : struct, IByteReader
        where TAdapter : ISerializationAdapter<TValue>, new()
    {
        return reader.Read<TReader, TAdapter, TValue>(new TAdapter());
    }

    /// <summary>
    /// Read a value, using an adapter.
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TAdapter"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="reader"></param>
    /// <param name="adapter"></param>
    /// <returns></returns>
    public static TValue Read<TReader, TAdapter, TValue>(ref this TReader reader, TAdapter adapter)
        where TReader : struct, IByteReader
        where TAdapter : ISerializationAdapter<TValue>
    {
        return adapter.Read(ref reader);
    }
}