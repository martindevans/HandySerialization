
using HandySerialization.Wrappers;

namespace HandySerialization.Extensions.Bits;

public static class SmallIntExtensions
{
    /// <summary>
    /// Write an int with a specific number of bits (up to 64)
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    /// <param name="bits"></param>
    public static void WriteSmallUInt<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value, uint bits)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, bits);
    }

    public static ulong ReadSmallUInt<TBytes>(ref this BitReader reader, ref TBytes bytes, uint bits)
        where TBytes : struct, IByteReader
    {
        return reader.Read(ref bytes, bits);
    }


    /// <summary>
    /// Write a number as N zeroes, followed by a one
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUnaryInt<TBytes>(ref this BitWriter writer, ref TBytes bytes, byte value)
        where TBytes : struct, IByteWriter
    {
        for (var i = 0; i < value; i++)
            writer.Write(ref bytes, false);
        writer.Write(ref bytes, true);
    }

    public static byte ReadUnaryInt<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        var count = 0;
        while (!reader.Read(ref bytes))
            count++;
        return (byte)count;
    }
}

