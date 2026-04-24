namespace HandySerialization.Extensions.Collections;

public static class ListSerializationExtensions
{
    /// <summary>
    /// Write a list with adapter
    /// </summary>
    /// <typeparam name="TWriter"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="writer"></param>
    /// <param name="list"></param>
    /// <param name="valAdapter"></param>
    public static void Write<TWriter, TValue, TValueAdapter>(ref this TWriter writer, IReadOnlyList<TValue> list, TValueAdapter valAdapter)
        where TWriter : struct, IByteWriter
        where TValueAdapter : ISerializationAdapter<TValue>
    {
        writer.WriteVariableUInt64((ulong)list.Count);

        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            valAdapter.Write(ref writer, item);
        }
    }


    /// <summary>
    /// Read a list with adapters
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="reader"></param>
    /// <param name="output"></param>
    /// <param name="valAdapter"></param>
    public static void ReadList<TReader, TValue, TValueAdapter>(ref this TReader reader, List<TValue> output, TValueAdapter valAdapter)
        where TReader : struct, IByteReader
        where TValueAdapter : ISerializationAdapter<TValue>
    {
        var count = checked((int)reader.ReadVariableUInt64());
        output.Capacity = Math.Max(output.Capacity, output.Count + count);

        for (var i = 0; i < count; i++)
        {
            var v = valAdapter.Read(ref reader);
            output.Add(v);
        }
    }

    /// <summary>
    /// Read a list with adapters
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="reader"></param>
    /// <param name="valAdapter"></param>
    public static List<TValue> ReadList<TReader, TValue, TValueAdapter>(ref this TReader reader, TValueAdapter valAdapter)
        where TReader : struct, IByteReader
        where TValueAdapter : ISerializationAdapter<TValue>
    {
        var output = new List<TValue>();
        reader.ReadList(output, valAdapter);
        return output;
    }

    /// <summary>
    /// Read a list with adapters
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="reader"></param>
    public static List<TValue> ReadList<TReader, TValue, TValueAdapter>(ref this TReader reader)
        where TReader : struct, IByteReader
        where TValueAdapter : ISerializationAdapter<TValue>, new()
    {
        var valAdapter = new TValueAdapter();
        return reader.ReadList<TReader, TValue, TValueAdapter>(valAdapter);
    }
}