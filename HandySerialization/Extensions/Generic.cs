namespace HandySerialization.Extensions;

public static class Generic
{
    public static void Write<TWriter, TValue>(ref this TWriter writer, TValue value)
        where TWriter : struct, IByteWriter
        where TValue : IByteSerializable<TValue>
    {
        writer.Write(ref value);
    }

    public static void Write<TWriter, TValue>(ref this TWriter writer, ref readonly TValue value)
        where TWriter : struct, IByteWriter
        where TValue : IByteSerializable<TValue>
    {
        value.Write(ref writer);
    }

    public static TValue Read<TReader, TValue>(ref this TReader reader)
        where TReader : struct, IByteReader
        where TValue : IByteSerializable<TValue>, new()
    {
        var result = new TValue();
        return result.Read(ref reader);
    }
}