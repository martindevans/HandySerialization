using HandySerialization.Wrappers;

namespace HandySerialization.Extensions.Bits;

public static class RiceCodingExtensions
{
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
        writer.WriteSmallUInt(r, k);
    }

    public static uint ReadRiceCode32<TBytes>(ref this BitReader<TBytes> reader, byte k)
        where TBytes : struct, IByteReader
    {
        var q = (uint)reader.ReadUnaryInt();
        var r = reader.ReadSmallUInt(k);

        return q << k | r;
    }
}