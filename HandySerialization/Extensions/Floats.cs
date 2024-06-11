namespace HandySerialization.Extensions;

public static class Floats
{
    public static void WriteNormalizedFloat8<T>(this ref T writer, float f)
        where T : struct, IByteWriter
    {
        if (f is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(f), "Value must be [0, 1]");

        writer.Write((byte)(f * byte.MaxValue));
    }

    public static float ReadNormalizedFloat8<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return reader.ReadUInt8() / (float)byte.MaxValue;
    }


    public static void WriteNormalizedFloat16<T>(this ref T writer, float f)
        where T : struct, IByteWriter
    {
        if (f is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(f), "Value must be [0, 1]");

        writer.Write((ushort)(f * ushort.MaxValue));
    }

    public static float ReadNormalizedFloat16<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return reader.ReadUInt16() / (float)ushort.MaxValue;
    }


    public static void WriteRangeLimitedFloat8<T>(this ref T writer, float f, float min, float range)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedFloat8((f - min) / range);
    }

    public static float ReadRangeLimitedFloat8<T>(this ref T reader, float min, float range)
        where T : struct, IByteReader
    {
        return reader.ReadNormalizedFloat8() * range + min;
    }


    public static void WriteRangeLimitedFloat16<T>(this ref T writer, float f, float min, float range)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedFloat16((f - min) / range);
    }

    public static float ReadRangeLimitedFloat16<T>(this ref T reader, float min, float range)
        where T : struct, IByteReader
    {
        return reader.ReadNormalizedFloat16() * range + min;
    }


    /// <summary>
    /// Write a sequence of floats, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="floats"></param>
    public static void WriteSequenceFloat32<T>(this ref T writer, ReadOnlySpan<float> floats)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)floats.Length);

        var prev = 0;
        for (var i = 0; i < floats.Length; i++)
        {
            var fint = BitConverter.SingleToInt32Bits(floats[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    public static int ReadSequenceLengthFloat32<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return checked((int)reader.ReadVariableUInt64());
    }

    public static void ReadSequenceValuesFloat32<T>(this ref T reader, Span<float> dest)
        where T : struct, IByteReader
    {
        var prev = 0;

        for (var i = 0; i < dest.Length; i++)
        {
            var xor = (int)reader.ReadVariableInt64();
            var fint = xor ^ prev;
            prev = fint;

            dest[i] = BitConverter.Int32BitsToSingle(fint);
        }
    }


    /// <summary>
    /// Write a sequence of doubles, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="floats"></param>
    public static void WriteSequenceFloat64<T>(this ref T writer, ReadOnlySpan<double> floats)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)floats.Length);

        var prev = 0L;
        for (var i = 0; i < floats.Length; i++)
        {
            var fint = BitConverter.DoubleToInt64Bits(floats[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    public static int ReadSequenceLengthFloat64<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return checked((int)reader.ReadVariableUInt64());
    }

    public static void ReadSequenceValuesFloat64<T>(this ref T reader, Span<double> dest)
        where T : struct, IByteReader
    {
        var prev = 0L;
        for (var i = 0; i < dest.Length; i++)
        {
            var xor = reader.ReadVariableInt64();
            var fint = xor ^ prev;
            prev = fint;

            dest[i] = BitConverter.Int64BitsToDouble(fint);
        }
    }
}