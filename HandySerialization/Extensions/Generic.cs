﻿namespace HandySerialization.Extensions;

public static class Generic
{
    public static void Write<TWriter, TValue>(this ref TWriter writer, ref readonly TValue value)
        where TWriter : struct, IByteWriter
        where TValue : IByteSerializable<TValue>
    {
        value.Write(ref writer);
    }

    public static TValue Read<TReader, TValue>(this ref TReader reader)
        where TReader : struct, IByteReader
        where TValue : IByteSerializable<TValue>, new()
    {
        var result = new TValue();
        return result.Read(ref reader);
    }
}