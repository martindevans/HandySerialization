namespace HandySerialization.Extensions.Collections;

public static class DictionarySerializationExtensions
{
    /// <summary>
    /// Write a dictionary with fully generic key and value
    /// </summary>
    /// <typeparam name="TWriter"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void Write<TWriter, TKey, TValue>(ref this TWriter writer, Dictionary<TKey, TValue> value)
        where TWriter : struct, IByteWriter
        where TKey : IByteSerializable<TKey>
        where TValue : IByteSerializable<TValue>
    {
        writer.WriteVariableUInt64((ulong)value.Count);

        foreach (var (key, val) in value)
        {
            writer.Write(key);
            writer.Write(val);
        }
    }

    /// <summary>
    /// Write a dictionary with adapters
    /// </summary>
    /// <typeparam name="TWriter"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TKeyAdapter"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="keyAdapter"></param>
    /// <param name="valAdapter"></param>
    public static void Write<TWriter, TKey, TKeyAdapter, TValue, TValueAdapter>(ref this TWriter writer, Dictionary<TKey, TValue> value, TKeyAdapter keyAdapter, TValueAdapter valAdapter)
        where TWriter : struct, IByteWriter
        where TKeyAdapter : ISerializationAdapter<TKey>
        where TValueAdapter : ISerializationAdapter<TValue>
        where TKey : notnull
    {
        writer.WriteVariableUInt64((ulong)value.Count);

        foreach (var (key, val) in value)
        {
            keyAdapter.Write(ref writer, key);
            valAdapter.Write(ref writer, val);
        }
    }
    

    /// <summary>
    /// Read a dictionary previously written with <see cref="Write{TWriter, TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="reader"></param>
    /// <param name="output"></param>
    public static void ReadDictionary<TReader, TKey, TValue>(ref this TReader reader, Dictionary<TKey, TValue> output)
        where TReader : struct, IByteReader
        where TKey : IByteSerializable<TKey>, new()
        where TValue : IByteSerializable<TValue>, new()
    {
        reader.ReadDictionary(
            output,
            new GenericAdapter<TKey>(),
            new GenericAdapter<TValue>()
        );
    }

    /// <summary>
    /// Read a dictionary previously written with <see cref="Write{TWriter, TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="reader"></param>
    public static Dictionary<TKey, TValue> ReadDictionary<TReader, TKey, TValue>(ref this TReader reader)
        where TReader : struct, IByteReader
        where TKey : IByteSerializable<TKey>, new()
        where TValue : IByteSerializable<TValue>, new()
    {
        return reader.ReadDictionary<TReader, TKey, GenericAdapter<TKey>, TValue, GenericAdapter<TValue>>(
            new GenericAdapter<TKey>(),
            new GenericAdapter<TValue>()
        );
    }

    /// <summary>
    /// Read a dictionary with adapters
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TKeyAdapter"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="reader"></param>
    /// <param name="output"></param>
    /// <param name="keyAdapter"></param>
    /// <param name="valAdapter"></param>
    public static void ReadDictionary<TReader, TKey, TKeyAdapter, TValue, TValueAdapter>(ref this TReader reader, Dictionary<TKey, TValue> output, TKeyAdapter keyAdapter, TValueAdapter valAdapter)
        where TReader : struct, IByteReader
        where TKeyAdapter : ISerializationAdapter<TKey>
        where TValueAdapter : ISerializationAdapter<TValue>
        where TKey : notnull
    {
        var count = checked((int)reader.ReadVariableUInt64());
        output.EnsureCapacity(output.Count + count);

        for (var i = 0; i < count; i++)
        {
            var k = keyAdapter.Read(ref reader);
            var v = valAdapter.Read(ref reader);
            output[k] = v;
        }
    }

    /// <summary>
    /// Read a dictionary with adapters
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TKeyAdapter"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="reader"></param>
    /// <param name="keyAdapter"></param>
    /// <param name="valAdapter"></param>
    public static Dictionary<TKey, TValue> ReadDictionary<TReader, TKey, TKeyAdapter, TValue, TValueAdapter>(ref this TReader reader, TKeyAdapter keyAdapter, TValueAdapter valAdapter)
        where TReader : struct, IByteReader
        where TKeyAdapter : ISerializationAdapter<TKey>
        where TValueAdapter : ISerializationAdapter<TValue>
        where TKey : notnull
    {
        var output = new Dictionary<TKey, TValue>();
        reader.ReadDictionary(output, keyAdapter, valAdapter);
        return output;
    }

    /// <summary>
    /// Read a dictionary with adapters
    /// </summary>
    /// <typeparam name="TReader"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TKeyAdapter"></typeparam>
    /// <typeparam name="TValueAdapter"></typeparam>
    /// <param name="reader"></param>
    public static Dictionary<TKey, TValue> ReadDictionary<TReader, TKey, TKeyAdapter, TValue, TValueAdapter>(ref this TReader reader)
        where TReader : struct, IByteReader
        where TKeyAdapter : ISerializationAdapter<TKey>, new()
        where TValueAdapter : ISerializationAdapter<TValue>, new()
        where TKey : notnull
    {
        var keyAdapter = new TKeyAdapter();
        var valAdapter = new TValueAdapter();
        return reader.ReadDictionary<TReader, TKey, TKeyAdapter, TValue, TValueAdapter>(keyAdapter, valAdapter);
    }
}