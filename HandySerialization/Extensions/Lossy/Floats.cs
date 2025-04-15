namespace HandySerialization.Extensions.Lossy;

public static class Floats
{
    /// <summary>
    /// Write a float in [0, 1] using 8 bits (approx 2.5 decimal places)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="f"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void WriteNormalizedFloat8<T>(ref this T writer, float f)
        where T : struct, IByteWriter
    {
        if (f is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(f), "Value must be [0, 1]");

        writer.Write((byte)(f * byte.MaxValue));
    }

    public static float ReadNormalizedFloat8<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return reader.ReadUInt8() / (float)byte.MaxValue;
    }


    /// <summary>
    /// Write a float in [0, 1] using 16 bits (approx 4.8 decimal places)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="f"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void WriteNormalizedFloat16<T>(ref this T writer, float f)
        where T : struct, IByteWriter
    {
        if (f is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(f), "Value must be [0, 1]");

        writer.Write((ushort)(f * ushort.MaxValue));
    }

    public static float ReadNormalizedFloat16<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return reader.ReadUInt16() / (float)ushort.MaxValue;
    }


    private const int U24_MaxValue = 16777215;

    /// <summary>
    /// Write a float in [0, 1] using 24 bits (approx 7.2 decimal places)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="f"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void WriteNormalizedFloat24<T>(ref this T writer, float f)
        where T : struct, IByteWriter
    {
        if (f is < 0 or > 1)
            throw new ArgumentOutOfRangeException(nameof(f), "Value must be [0, 1]");

        var value = (int)(f * U24_MaxValue);

        var a = (byte)((value & 0x0000FF) >> 0);
        var b = (byte)((value & 0x00FF00) >> 8);
        var c = (byte)((value & 0xFF0000) >> 16);

        writer.Write(a);
        writer.Write(b);
        writer.Write(c);
    }

    public static float ReadNormalizedFloat24<T>(ref this T reader)
        where T : struct, IByteReader
    {
        var a = reader.ReadUInt8();
        var b = reader.ReadUInt8();
        var c = reader.ReadUInt8();

        return ((a << 0) | (b << 8) | (c << 16)) / (float)U24_MaxValue;
    }


    /// <summary>
    /// Write a float in [min, min + range] using 8 bits
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="f"></param>
    /// <param name="min"></param>
    /// <param name="range"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void WriteRangeLimitedFloat8<T>(ref this T writer, float f, float min, float range)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedFloat8((f - min) / range);
    }

    public static float ReadRangeLimitedFloat8<T>(ref this T reader, float min, float range)
        where T : struct, IByteReader
    {
        return reader.ReadNormalizedFloat8() * range + min;
    }


    /// <summary>
    /// Write a float in [min, min + range] using 16 bits
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="f"></param>
    /// <param name="min"></param>
    /// <param name="range"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void WriteRangeLimitedFloat16<T>(ref this T writer, float f, float min, float range)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedFloat16((f - min) / range);
    }

    public static float ReadRangeLimitedFloat16<T>(ref this T reader, float min, float range)
        where T : struct, IByteReader
    {
        return reader.ReadNormalizedFloat16() * range + min;
    }


    /// <summary>
    /// Write a float in [min, min + range] using 24 bits
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="f"></param>
    /// <param name="min"></param>
    /// <param name="range"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void WriteRangeLimitedFloat24<T>(ref this T writer, float f, float min, float range)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedFloat24((f - min) / range);
    }

    public static float ReadRangeLimitedFloat24<T>(ref this T reader, float min, float range)
        where T : struct, IByteReader
    {
        return reader.ReadNormalizedFloat24() * range + min;
    }
}