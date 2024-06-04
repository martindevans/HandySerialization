using System.Buffers;
using System.Text;
using HandySerialization.Unions;

namespace HandySerialization.Extensions;

public static class Primitives
{
    public static void Write<T>(this ref T writer, bool b0, bool b1 = false, bool b2 = false, bool b3 = false, bool b4 = false, bool b5 = false, bool b6 = false, bool b7 = false)
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

    public static void ReadBool<T>(this ref T reader, out bool b0, out bool b1, out bool b2, out bool b3, out bool b4, out bool b5, out bool b6, out bool b7)
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


    public static void Write<T>(this ref T writer, byte b)
        where T : struct, IByteWriter
    {
        Span<byte> dest = [ b ];
        writer.Write(dest);
    }

    public static byte ReadUInt8<T>(this ref T reader)
        where T : struct, IByteReader
    {
        Span<byte> dest = stackalloc byte[1];
        reader.ReadBytes(dest);
        return dest[0];
    }


    public static void Write<T>(this ref T writer, sbyte b)
        where T : struct, IByteWriter
    {
        var union8 = new Union8 { SByte = b };
        writer.Write(union8.Byte);
    }

    public static sbyte ReadInt8<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union8 = new Union8 { Byte = reader.ReadUInt8() };
        return union8.SByte;
    }


    public static void Write<T>(this ref T writer, ushort s)
        where T : struct, IByteWriter
    {
        var union16 = new Union16 { UShort = s };

        writer.Write(union16.Byte0);
        writer.Write(union16.Byte1);
    }

    public static ushort ReadUInt16<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union16 = new Union16 { Byte0 = reader.ReadUInt8(), Byte1 = reader.ReadUInt8() };
        return union16.UShort;
    }


    public static void Write<T>(this ref T writer, short s)
        where T : struct, IByteWriter
    {
        var union16 = new Union16 { Short = s };

        writer.Write(union16.Byte0);
        writer.Write(union16.Byte1);
    }

    public static short ReadInt16<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union16 = new Union16 { Byte0 = reader.ReadUInt8(), Byte1 = reader.ReadUInt8() };
        return union16.Short;
    }


    public static void Write<T>(this ref T writer, uint i)
        where T : struct, IByteWriter
    {
        var union32 = new Union32 { UInt = i };

        writer.Write(union32.Byte0);
        writer.Write(union32.Byte1);
        writer.Write(union32.Byte2);
        writer.Write(union32.Byte3);
    }

    public static uint ReadUInt32<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union32 = new Union32
        {
            Byte0 = reader.ReadUInt8(),
            Byte1 = reader.ReadUInt8(),
            Byte2 = reader.ReadUInt8(),
            Byte3 = reader.ReadUInt8()
        };
        return union32.UInt;
    }


    public static void Write<T>(this ref T writer, int i)
        where T : struct, IByteWriter
    {
        var union32 = new Union32 { Int = i };

        writer.Write(union32.Byte0);
        writer.Write(union32.Byte1);
        writer.Write(union32.Byte2);
        writer.Write(union32.Byte3);
    }

    public static int ReadInt32<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union32 = new Union32
        {
            Byte0 = reader.ReadUInt8(),
            Byte1 = reader.ReadUInt8(),
            Byte2 = reader.ReadUInt8(),
            Byte3 = reader.ReadUInt8()
        };
        return union32.Int;
    }


    public static void Write<T>(this ref T writer, ulong l)
        where T : struct, IByteWriter
    {
        var union64 = new Union64 { ULong = l };

        writer.Write(union64.Byte0);
        writer.Write(union64.Byte1);
        writer.Write(union64.Byte2);
        writer.Write(union64.Byte3);
        writer.Write(union64.Byte4);
        writer.Write(union64.Byte5);
        writer.Write(union64.Byte6);
        writer.Write(union64.Byte7);
    }

    public static ulong ReadUInt64<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union64 = new Union64
        {
            Byte0 = reader.ReadUInt8(),
            Byte1 = reader.ReadUInt8(),
            Byte2 = reader.ReadUInt8(),
            Byte3 = reader.ReadUInt8(),
            Byte4 = reader.ReadUInt8(),
            Byte5 = reader.ReadUInt8(),
            Byte6 = reader.ReadUInt8(),
            Byte7 = reader.ReadUInt8(),
        };
        return union64.ULong;
    }


    public static void Write<T>(this ref T writer, long l)
        where T : struct, IByteWriter
    {
        var union64 = new Union64 { Long = l };

        writer.Write(union64.Byte0);
        writer.Write(union64.Byte1);
        writer.Write(union64.Byte2);
        writer.Write(union64.Byte3);
        writer.Write(union64.Byte4);
        writer.Write(union64.Byte5);
        writer.Write(union64.Byte6);
        writer.Write(union64.Byte7);
    }

    public static long ReadInt64<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union64 = new Union64
        {
            Byte0 = reader.ReadUInt8(),
            Byte1 = reader.ReadUInt8(),
            Byte2 = reader.ReadUInt8(),
            Byte3 = reader.ReadUInt8(),
            Byte4 = reader.ReadUInt8(),
            Byte5 = reader.ReadUInt8(),
            Byte6 = reader.ReadUInt8(),
            Byte7 = reader.ReadUInt8(),
        };
        return union64.Long;
    }


    public static void Write<T>(this ref T writer, float f)
        where T : struct, IByteWriter
    {
        var union32 = new Union32 { Float = f };

        writer.Write(union32.Byte0);
        writer.Write(union32.Byte1);
        writer.Write(union32.Byte2);
        writer.Write(union32.Byte3);
    }

    public static float ReadFloat32<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union32 = new Union32
        {
            Byte0 = reader.ReadUInt8(),
            Byte1 = reader.ReadUInt8(),
            Byte2 = reader.ReadUInt8(),
            Byte3 = reader.ReadUInt8()
        };
        return union32.Float;
    }


    public static void Write<T>(this ref T writer, double d)
        where T : struct, IByteWriter
    {
        var union64 = new Union64 { Double = d };

        writer.Write(union64.Byte0);
        writer.Write(union64.Byte1);
        writer.Write(union64.Byte2);
        writer.Write(union64.Byte3);
        writer.Write(union64.Byte4);
        writer.Write(union64.Byte5);
        writer.Write(union64.Byte6);
        writer.Write(union64.Byte7);
    }

    public static double ReadFloat64<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var union64 = new Union64
        {
            Byte0 = reader.ReadUInt8(),
            Byte1 = reader.ReadUInt8(),
            Byte2 = reader.ReadUInt8(),
            Byte3 = reader.ReadUInt8(),
            Byte4 = reader.ReadUInt8(),
            Byte5 = reader.ReadUInt8(),
            Byte6 = reader.ReadUInt8(),
            Byte7 = reader.ReadUInt8(),
        };
        return union64.Double;
    }


    public static void Write<T>(this ref T writer, string str)
        where T : struct, IByteWriter
    {
        var byteCount = Encoding.UTF8.GetByteCount(str);
        writer.WriteVariableUInt64((uint)byteCount);

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

    public static string ReadString<T>(this ref T reader)
        where T : struct, IByteReader
    {
        var byteCount = (int)reader.ReadVariableUInt64();
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


    public static void Write<T>(this ref T writer, TimeSpan t)
        where T : struct, IByteWriter
    {
        writer.WriteVariableInt64(t.Ticks);
    }

    public static TimeSpan ReadTimeSpan<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new TimeSpan(reader.ReadVariableInt64());
    }
}