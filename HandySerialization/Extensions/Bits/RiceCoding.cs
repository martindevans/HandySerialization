using HandySerialization.Wrappers;

namespace HandySerialization.Extensions.Bits;

public static class RiceCodingExtensions
{
    /// <summary>
    /// Write out a number using rice coding. Suitable for small numbers.
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    /// <param name="k"></param>
    public static void WriteRiceCode32<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value, byte k)
        where TBytes : struct, IByteWriter
    {
        var mask = (1u << k) - 1u;

        var q = value >> k;
        var r = value & mask;

        writer.WriteUnaryInt(ref bytes, (byte)q);
        writer.WriteSmallUInt(ref bytes, r, k);
    }

    public static uint ReadRiceCode32<TBytes>(ref this BitReader reader, ref TBytes bytes, byte k)
        where TBytes : struct, IByteReader
    {
        var q = (uint)reader.ReadUnaryInt(ref bytes);
        var r = reader.ReadSmallUInt(ref bytes, k);

        return q << k | r;
    }
}