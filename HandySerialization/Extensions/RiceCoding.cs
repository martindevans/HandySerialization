using HandySerialization.Wrappers;

namespace HandySerialization.Extensions;

public static class RiceCoding
{
    /// <summary>
    /// Write an int with 2 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteInt2<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b01) == 0b01);
        writer.Write((value & 0b10) == 0b10);
    }

    public static uint ReadInt2<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b01u : 0)
             | (reader.Read() ? 0b10u : 0);
    }

    /// <summary>
    /// Write an int with a specific number of bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="bits"></param>
    public static void WriteSmallInt<TBytes>(ref this BitWriter<TBytes> writer, uint value, uint bits)
        where TBytes : struct, IByteWriter
    {
        for (var i = 0; i < bits; i++)
        {
            writer.Write((value & 0b1) == 1);
            value >>= 1;
        }
    }

    public static uint ReadSmallInt<TBytes>(ref this BitReader<TBytes> reader, uint bits)
        where TBytes : struct, IByteReader
    {
        var value = 0u;

        for (var i = 0; i < bits; i++)
            value |= reader.Read() ? (1u << i) : 0u;

        return value;
    }

    /// <summary>
    /// Write a number as N zeroes, followed by a one
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUnaryInt<TBytes>(ref this BitWriter<TBytes> writer, byte value)
        where TBytes : struct, IByteWriter
    {
        for (var i = 0; i < value; i++)
            writer.Write(false);
        writer.Write(true);
    }

    public static byte ReadUnaryInt<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        var count = 0;
        while (!reader.Read())
            count++;
        return (byte)count;
    }

    /// <summary>
    /// Write out a number using rice coding. Suitable for small numbers. K should be chosen such that 
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="k"></param>
    public static void WriteRiceCode32<TBytes>(ref this BitWriter<TBytes> writer, uint value, byte k)
        where TBytes : struct, IByteWriter
    {
        var mask = (1u << k) - 1u;

        var q = value >> k;
        var r = value & mask;

        writer.WriteUnaryInt((byte)q);
        writer.WriteSmallInt(r, k);
    }

    public static uint ReadRiceCode32<TBytes>(ref this BitReader<TBytes> reader, byte k)
        where TBytes : struct, IByteReader
    {
        var q = (uint)reader.ReadUnaryInt();
        var r = reader.ReadSmallInt(k);

        return (q << k) | r;
    }
}