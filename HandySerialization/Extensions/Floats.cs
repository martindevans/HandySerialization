
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
}