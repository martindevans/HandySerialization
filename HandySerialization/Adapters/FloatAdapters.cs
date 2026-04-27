using HandySerialization.Extensions;
using HandySerialization.Extensions.Lossy;

namespace HandySerialization.Adapters;

public struct NormalizedFloat8Adapter
    : ISerializationAdapter<float>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly float value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteNormalizedFloat8(value);
    }

    public float Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadNormalizedFloat8();
    }
}

public struct NormalizedFloat16Adapter
    : ISerializationAdapter<float>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly float value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteNormalizedFloat16(value);
    }

    public float Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadNormalizedFloat16();
    }
}

public struct NormalizedFloat24Adapter
    : ISerializationAdapter<float>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly float value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteNormalizedFloat24(value);
    }

    public float Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadNormalizedFloat24();
    }
}

public struct Float32Adapter
    : ISerializationAdapter<float>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly float value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public float Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadFloat32();
    }
}

public struct Float64Adapter
    : ISerializationAdapter<double>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly double value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public double Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadFloat64();
    }
}