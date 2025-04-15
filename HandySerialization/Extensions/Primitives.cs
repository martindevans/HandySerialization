using System.Buffers.Binary;
using System.Runtime.InteropServices;
using System.Text;

namespace HandySerialization.Extensions;

public static class Primitives
{
    public static void Write<T>(ref this T writer, bool b0, bool b1 = false, bool b2 = false, bool b3 = false, bool b4 = false, bool b5 = false, bool b6 = false, bool b7 = false)
        where T : struct, IByteWriter
    {
        var b = (byte)(
              (b0 ? 0b1000_0000 : 0)
            | (b1 ? 0b0100_0000 : 0)
            | (b2 ? 0b0010_0000 : 0)
            | (b3 ? 0b0001_0000 : 0)
            | (b4 ? 0b0000_1000 : 0)
            | (b5 ? 0b0000_0100 : 0)
            | (b6 ? 0b0000_0010 : 0)
            | (b7 ? 0b0000_0001 : 0)
        );
        writer.Write(b);
    }

    public static void ReadBool<T>(ref this T reader, out bool b0, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6, out bool b7)
        where T : struct, IByteReader
    {
        var b = reader.ReadUInt8();

        b0 = (b & 0b1000_0000) != 0;
        b1 = (b & 0b0100_0000) != 0;
        b2 = (b & 0b0010_0000) != 0;
        b3 = (b & 0b0001_0000) != 0;
        b4 = (b & 0b0000_1000) != 0;
        b5 = (b & 0b0000_0100) != 0;
        b6 = (b & 0b0000_0010) != 0;
        b7 = (b & 0b0000_0001) != 0;
    }


    public static void Write<T>(ref this T writer, byte b)
        where T : struct, IByteWriter
    {
        Span<byte> dest = stackalloc byte[] { b };
        writer.Write(dest);
    }

    public static byte ReadUInt8<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> dest = stackalloc byte[1];
        reader.ReadBytes(dest);
        return dest[0];
    }


    public static void Write<T>(ref this T writer, sbyte b)
        where T : struct, IByteWriter
    {
        writer.Write(unchecked((byte)b));
    }

    public static sbyte ReadInt8<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return unchecked((sbyte)reader.ReadUInt8());
    }


    public static void Write<T>(ref this T writer, ushort s)
        where T : struct, IByteWriter
    {
        Span<byte> span = stackalloc byte[2];
        BinaryPrimitives.WriteUInt16BigEndian(span, s);

        writer.Write(span);
    }

    public static ushort ReadUInt16<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[2];
        reader.ReadBytes(span);

        return BinaryPrimitives.ReadUInt16BigEndian(span);
    }


    public static void Write<T>(ref this T writer, short s)
        where T : struct, IByteWriter
    {
        Span<byte> span = stackalloc byte[2];
        BinaryPrimitives.WriteInt16BigEndian(span, s);

        writer.Write(span);
    }

    public static short ReadInt16<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[2];
        reader.ReadBytes(span);

        return BinaryPrimitives.ReadInt16BigEndian(span);
    }


    public static void Write<T>(ref this T writer, uint i)
        where T : struct, IByteWriter
    {
        Span<byte> span = stackalloc byte[4];
        BinaryPrimitives.WriteUInt32BigEndian(span, i);

        writer.Write(span);
    }

    public static uint ReadUInt32<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[4];
        reader.ReadBytes(span);

        return BinaryPrimitives.ReadUInt32BigEndian(span);
    }


    public static void Write<T>(ref this T writer, int i)
        where T : struct, IByteWriter
    {
        Span<byte> span = stackalloc byte[4];
        BinaryPrimitives.WriteInt32BigEndian(span, i);

        writer.Write(span);
    }

    public static int ReadInt32<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[4];
        reader.ReadBytes(span);

        return BinaryPrimitives.ReadInt32BigEndian(span);
    }


    public static void Write<T>(ref this T writer, ulong l)
        where T : struct, IByteWriter
    {
        Span<byte> span = stackalloc byte[8];
        BinaryPrimitives.WriteUInt64BigEndian(span, l);

        writer.Write(span);
    }

    public static ulong ReadUInt64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[8];
        reader.ReadBytes(span);

        return BinaryPrimitives.ReadUInt64BigEndian(span);
    }


    public static void Write<T>(ref this T writer, long l)
        where T : struct, IByteWriter
    {
        Span<byte> span = stackalloc byte[8];
        BinaryPrimitives.WriteInt64BigEndian(span, l);

        writer.Write(span);
    }

    public static long ReadInt64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[8];
        reader.ReadBytes(span);

        return BinaryPrimitives.ReadInt64BigEndian(span);
    }


    public static void Write<T>(ref this T writer, float f)
        where T : struct, IByteWriter
    {
        var span = MemoryMarshal.Cast<float, byte>(stackalloc float[1] { f });
        if (BitConverter.IsLittleEndian)
            span.Reverse();

        writer.Write(span);
    }

    public static float ReadFloat32<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[4];
        reader.ReadBytes(span);

        if (BitConverter.IsLittleEndian)
            span.Reverse();

        return MemoryMarshal.Cast<byte, float>(span)[0];
    }


    public static void Write<T>(ref this T writer, double d)
        where T : struct, IByteWriter
    {
        var span = MemoryMarshal.Cast<double, byte>(stackalloc double[1] { d });
        if (BitConverter.IsLittleEndian)
            span.Reverse();

        writer.Write(span);
    }

    public static double ReadFloat64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[8];
        reader.ReadBytes(span);

        if (BitConverter.IsLittleEndian)
            span.Reverse();

        return MemoryMarshal.Cast<byte, double>(span)[0];
    }


    public static void Write<T>(ref this T writer, string? str)
        where T : struct, IByteWriter
    {
        // Use 0 to indicate a null string
        if (str == null)
        {
            writer.WriteVariableUInt64((uint)0);
            return;
        }

        // We already used zero to indicate null, write out the length + 1
        var byteCount = Encoding.UTF8.GetByteCount(str);
        writer.WriteVariableUInt64((uint)(byteCount + 1));

        // Write out the bytes
        var bytes = ArrayPool<byte>.Shared.Rent(byteCount);
        try
        {
            Encoding.UTF8.GetBytes(str, 0, str.Length, bytes, 0);
            writer.Write(bytes.AsSpan(0, byteCount));
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(bytes);
        }
    }

    public static string? ReadString<T>(ref this T reader)
        where T : struct, IByteReader
    {
        var byteCount = (int)reader.ReadVariableUInt64();
        if (byteCount == 0)
            return null;

        byteCount--;
        if (byteCount == 0)
            return "";

        var bytes = ArrayPool<byte>.Shared.Rent(byteCount);
        try
        {
            reader.ReadBytes(bytes.AsSpan(0, byteCount));
            return Encoding.UTF8.GetString(bytes, 0, byteCount);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(bytes);
        }
    }


    public static void Write<T>(ref this T writer, char c)
        where T : struct, IByteWriter
    {
        Span<byte> span = stackalloc byte[2];
        BinaryPrimitives.WriteUInt16BigEndian(span, c);

        writer.Write(span);
    }

    public static char ReadChar<T>(ref this T reader)
        where T : struct, IByteReader
    {
        Span<byte> span = stackalloc byte[2];
        reader.ReadBytes(span);

        return (char)BinaryPrimitives.ReadUInt16BigEndian(span);
    }



    public static void Write<T>(ref this T writer, TimeSpan t)
        where T : struct, IByteWriter
    {
        writer.WriteVariableInt64(t.Ticks);
    }

    public static TimeSpan ReadTimeSpan<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new TimeSpan(reader.ReadVariableInt64());
    }
}