using HandySerialization.Extensions;

namespace HandySerialization.Adapters;

public struct Int8Adapter
    : ISerializationAdapter<sbyte>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly sbyte value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public sbyte Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadInt8();
    }
}

public struct Int16Adapter
    : ISerializationAdapter<short>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly short value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public short Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadInt16();
    }
}

public struct Int32Adapter
    : ISerializationAdapter<int>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly int value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public int Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadInt32();
    }
}

public struct Int64Adapter
    : ISerializationAdapter<long>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly long value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public long Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadInt64();
    }
}


public struct VarInt16Adapter
    : ISerializationAdapter<short>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly short value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteVariableInt64(value);
    }

    public short Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return (short)reader.ReadVariableInt64();
    }
}

public struct VarInt32Adapter
    : ISerializationAdapter<int>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly int value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteVariableInt64(value);
    }

    public int Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return (int)reader.ReadVariableInt64();
    }
}

public struct VarInt64Adapter
    : ISerializationAdapter<long>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly long value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteVariableInt64(value);
    }

    public long Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadVariableInt64();
    }
}


public struct UInt8Adapter
    : ISerializationAdapter<byte>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly byte value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public byte Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadUInt8();
    }
}

public struct UInt16Adapter
    : ISerializationAdapter<ushort>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly ushort value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public ushort Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadUInt16();
    }
}

public struct UInt32Adapter
    : ISerializationAdapter<uint>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly uint value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public uint Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadUInt32();
    }
}

public struct UInt64Adapter
    : ISerializationAdapter<ulong>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly ulong value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value);
    }

    public ulong Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadUInt64();
    }
}


public struct VarUInt16Adapter
    : ISerializationAdapter<ushort>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly ushort value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteVariableUInt64(value);
    }

    public ushort Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return (ushort)reader.ReadVariableUInt64();
    }
}

public struct VarUInt32Adapter
    : ISerializationAdapter<uint>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly uint value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteVariableUInt64(value);
    }

    public uint Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return (uint)reader.ReadVariableUInt64();
    }
}

public struct VarUInt64Adapter
    : ISerializationAdapter<ulong>
{
    public void Write<TWriter>(ref TWriter writer, ref readonly ulong value)
        where TWriter : struct, IByteWriter
    {
        writer.WriteVariableUInt64(value);
    }

    public ulong Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return reader.ReadVariableUInt64();
    }
}