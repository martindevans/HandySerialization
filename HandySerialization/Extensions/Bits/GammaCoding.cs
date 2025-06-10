using HandySerialization.Wrappers;

namespace HandySerialization.Extensions.Bits;

public static class GammaCodingExtensions
{
    /// <summary>
    /// Write out a number using elias gamma coding. Suitable for small numbers.
    /// Writes out the number of bits required in unary, then the value itself using that many bits.
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteEliasGamma32<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        // Write out number of bits needed
        var bits = BitTwiddle.BitsNeeded32(value);
        writer.WriteUnaryInt(ref bytes, bits);

        // Write out the number itself
        writer.WriteSmallUInt(ref bytes, value, bits);
    }

    public static uint ReadEliasGamma32<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        var bits = reader.ReadUnaryInt(ref bytes);
        return (uint)reader.ReadSmallUInt(ref bytes, bits);
    }

    /// <summary>
    /// Write out a number using elias delta gamma coding. Suitable for medium size numbers.
    /// Writes out the number of bits required in elias gamma coding, then the value itself using that many bits.
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteEliasDeltaGamma32<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        // Write out number of bits needed
        var bits = BitTwiddle.BitsNeeded32(value);
        writer.WriteEliasGamma32(ref bytes, bits);

        // Write out the number itself
        writer.WriteSmallUInt(ref bytes, value, bits);
    }

    public static uint ReadEliasDeltaGamma32<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        var bits = reader.ReadEliasGamma32(ref bytes);
        return (uint)reader.ReadSmallUInt(ref bytes, bits);
    }
}