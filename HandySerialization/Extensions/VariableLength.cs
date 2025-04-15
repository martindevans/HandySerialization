namespace HandySerialization.Extensions;

public static class VariableLength
{
    public static void WriteVariableInt64<T>(ref this T writer, long l)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64(l.ZigZag());
    }

    public static long ReadVariableInt64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return reader.ReadVariableUInt64().DecodeZigZag();
    }


    public static void WriteVariableUInt64<T>(ref this T writer, ulong u)
        where T : struct, IByteWriter
    {
        var count = 0;
        Span<byte> bytes = stackalloc byte[10];

        do
        {
            var writeByte = (byte)(u & 127);
            u >>= 7;

            if (u != 0)
                writeByte |= 128;

            bytes[count++] = writeByte;
        } while (u != 0);

        writer.Write(bytes[..count]);
    }

    public static ulong ReadVariableUInt64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        ulong accumulator = 0;
        var iterations = 0;

        byte readByte;
        do
        {
            readByte = reader.ReadUInt8();
            accumulator |= ((ulong)readByte & 127) << (iterations * 7);
            iterations++;
        } while ((readByte & 128) != 0);

        return accumulator;
    }
}