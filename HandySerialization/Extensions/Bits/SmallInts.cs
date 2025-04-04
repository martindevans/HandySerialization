
using HandySerialization.Wrappers;

namespace HandySerialization.Extensions.Bits;

public static class SmallIntExtensions
{
	/// <summary>
    /// Write an int with 2 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt2<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b01u) == 0b01u);
        writer.Write((value & 0b10u) == 0b10u);
    }

    public static uint ReadUInt2<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b01u : 0)
             | (reader.Read() ? 0b10u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 3 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt3<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b001u) == 0b001u);
        writer.Write((value & 0b010u) == 0b010u);
        writer.Write((value & 0b100u) == 0b100u);
    }

    public static uint ReadUInt3<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b001u : 0)
             | (reader.Read() ? 0b010u : 0)
             | (reader.Read() ? 0b100u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 4 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt4<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0001u) == 0b0001u);
        writer.Write((value & 0b0010u) == 0b0010u);
        writer.Write((value & 0b0100u) == 0b0100u);
        writer.Write((value & 0b1000u) == 0b1000u);
    }

    public static uint ReadUInt4<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0001u : 0)
             | (reader.Read() ? 0b0010u : 0)
             | (reader.Read() ? 0b0100u : 0)
             | (reader.Read() ? 0b1000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 5 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt5<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00001u) == 0b00001u);
        writer.Write((value & 0b00010u) == 0b00010u);
        writer.Write((value & 0b00100u) == 0b00100u);
        writer.Write((value & 0b01000u) == 0b01000u);
        writer.Write((value & 0b10000u) == 0b10000u);
    }

    public static uint ReadUInt5<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00001u : 0)
             | (reader.Read() ? 0b00010u : 0)
             | (reader.Read() ? 0b00100u : 0)
             | (reader.Read() ? 0b01000u : 0)
             | (reader.Read() ? 0b10000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 6 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt6<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000001u) == 0b000001u);
        writer.Write((value & 0b000010u) == 0b000010u);
        writer.Write((value & 0b000100u) == 0b000100u);
        writer.Write((value & 0b001000u) == 0b001000u);
        writer.Write((value & 0b010000u) == 0b010000u);
        writer.Write((value & 0b100000u) == 0b100000u);
    }

    public static uint ReadUInt6<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000001u : 0)
             | (reader.Read() ? 0b000010u : 0)
             | (reader.Read() ? 0b000100u : 0)
             | (reader.Read() ? 0b001000u : 0)
             | (reader.Read() ? 0b010000u : 0)
             | (reader.Read() ? 0b100000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 7 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt7<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000001u) == 0b0000001u);
        writer.Write((value & 0b0000010u) == 0b0000010u);
        writer.Write((value & 0b0000100u) == 0b0000100u);
        writer.Write((value & 0b0001000u) == 0b0001000u);
        writer.Write((value & 0b0010000u) == 0b0010000u);
        writer.Write((value & 0b0100000u) == 0b0100000u);
        writer.Write((value & 0b1000000u) == 0b1000000u);
    }

    public static uint ReadUInt7<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000001u : 0)
             | (reader.Read() ? 0b0000010u : 0)
             | (reader.Read() ? 0b0000100u : 0)
             | (reader.Read() ? 0b0001000u : 0)
             | (reader.Read() ? 0b0010000u : 0)
             | (reader.Read() ? 0b0100000u : 0)
             | (reader.Read() ? 0b1000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 8 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt8<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000001u) == 0b00000001u);
        writer.Write((value & 0b00000010u) == 0b00000010u);
        writer.Write((value & 0b00000100u) == 0b00000100u);
        writer.Write((value & 0b00001000u) == 0b00001000u);
        writer.Write((value & 0b00010000u) == 0b00010000u);
        writer.Write((value & 0b00100000u) == 0b00100000u);
        writer.Write((value & 0b01000000u) == 0b01000000u);
        writer.Write((value & 0b10000000u) == 0b10000000u);
    }

    public static uint ReadUInt8<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000001u : 0)
             | (reader.Read() ? 0b00000010u : 0)
             | (reader.Read() ? 0b00000100u : 0)
             | (reader.Read() ? 0b00001000u : 0)
             | (reader.Read() ? 0b00010000u : 0)
             | (reader.Read() ? 0b00100000u : 0)
             | (reader.Read() ? 0b01000000u : 0)
             | (reader.Read() ? 0b10000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 9 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt9<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000001u) == 0b000000001u);
        writer.Write((value & 0b000000010u) == 0b000000010u);
        writer.Write((value & 0b000000100u) == 0b000000100u);
        writer.Write((value & 0b000001000u) == 0b000001000u);
        writer.Write((value & 0b000010000u) == 0b000010000u);
        writer.Write((value & 0b000100000u) == 0b000100000u);
        writer.Write((value & 0b001000000u) == 0b001000000u);
        writer.Write((value & 0b010000000u) == 0b010000000u);
        writer.Write((value & 0b100000000u) == 0b100000000u);
    }

    public static uint ReadUInt9<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000001u : 0)
             | (reader.Read() ? 0b000000010u : 0)
             | (reader.Read() ? 0b000000100u : 0)
             | (reader.Read() ? 0b000001000u : 0)
             | (reader.Read() ? 0b000010000u : 0)
             | (reader.Read() ? 0b000100000u : 0)
             | (reader.Read() ? 0b001000000u : 0)
             | (reader.Read() ? 0b010000000u : 0)
             | (reader.Read() ? 0b100000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 10 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt10<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000001u) == 0b0000000001u);
        writer.Write((value & 0b0000000010u) == 0b0000000010u);
        writer.Write((value & 0b0000000100u) == 0b0000000100u);
        writer.Write((value & 0b0000001000u) == 0b0000001000u);
        writer.Write((value & 0b0000010000u) == 0b0000010000u);
        writer.Write((value & 0b0000100000u) == 0b0000100000u);
        writer.Write((value & 0b0001000000u) == 0b0001000000u);
        writer.Write((value & 0b0010000000u) == 0b0010000000u);
        writer.Write((value & 0b0100000000u) == 0b0100000000u);
        writer.Write((value & 0b1000000000u) == 0b1000000000u);
    }

    public static uint ReadUInt10<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000001u : 0)
             | (reader.Read() ? 0b0000000010u : 0)
             | (reader.Read() ? 0b0000000100u : 0)
             | (reader.Read() ? 0b0000001000u : 0)
             | (reader.Read() ? 0b0000010000u : 0)
             | (reader.Read() ? 0b0000100000u : 0)
             | (reader.Read() ? 0b0001000000u : 0)
             | (reader.Read() ? 0b0010000000u : 0)
             | (reader.Read() ? 0b0100000000u : 0)
             | (reader.Read() ? 0b1000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 11 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt11<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000000001u) == 0b00000000001u);
        writer.Write((value & 0b00000000010u) == 0b00000000010u);
        writer.Write((value & 0b00000000100u) == 0b00000000100u);
        writer.Write((value & 0b00000001000u) == 0b00000001000u);
        writer.Write((value & 0b00000010000u) == 0b00000010000u);
        writer.Write((value & 0b00000100000u) == 0b00000100000u);
        writer.Write((value & 0b00001000000u) == 0b00001000000u);
        writer.Write((value & 0b00010000000u) == 0b00010000000u);
        writer.Write((value & 0b00100000000u) == 0b00100000000u);
        writer.Write((value & 0b01000000000u) == 0b01000000000u);
        writer.Write((value & 0b10000000000u) == 0b10000000000u);
    }

    public static uint ReadUInt11<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000000001u : 0)
             | (reader.Read() ? 0b00000000010u : 0)
             | (reader.Read() ? 0b00000000100u : 0)
             | (reader.Read() ? 0b00000001000u : 0)
             | (reader.Read() ? 0b00000010000u : 0)
             | (reader.Read() ? 0b00000100000u : 0)
             | (reader.Read() ? 0b00001000000u : 0)
             | (reader.Read() ? 0b00010000000u : 0)
             | (reader.Read() ? 0b00100000000u : 0)
             | (reader.Read() ? 0b01000000000u : 0)
             | (reader.Read() ? 0b10000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 12 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt12<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000000001u) == 0b000000000001u);
        writer.Write((value & 0b000000000010u) == 0b000000000010u);
        writer.Write((value & 0b000000000100u) == 0b000000000100u);
        writer.Write((value & 0b000000001000u) == 0b000000001000u);
        writer.Write((value & 0b000000010000u) == 0b000000010000u);
        writer.Write((value & 0b000000100000u) == 0b000000100000u);
        writer.Write((value & 0b000001000000u) == 0b000001000000u);
        writer.Write((value & 0b000010000000u) == 0b000010000000u);
        writer.Write((value & 0b000100000000u) == 0b000100000000u);
        writer.Write((value & 0b001000000000u) == 0b001000000000u);
        writer.Write((value & 0b010000000000u) == 0b010000000000u);
        writer.Write((value & 0b100000000000u) == 0b100000000000u);
    }

    public static uint ReadUInt12<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000000001u : 0)
             | (reader.Read() ? 0b000000000010u : 0)
             | (reader.Read() ? 0b000000000100u : 0)
             | (reader.Read() ? 0b000000001000u : 0)
             | (reader.Read() ? 0b000000010000u : 0)
             | (reader.Read() ? 0b000000100000u : 0)
             | (reader.Read() ? 0b000001000000u : 0)
             | (reader.Read() ? 0b000010000000u : 0)
             | (reader.Read() ? 0b000100000000u : 0)
             | (reader.Read() ? 0b001000000000u : 0)
             | (reader.Read() ? 0b010000000000u : 0)
             | (reader.Read() ? 0b100000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 13 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt13<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000000001u) == 0b0000000000001u);
        writer.Write((value & 0b0000000000010u) == 0b0000000000010u);
        writer.Write((value & 0b0000000000100u) == 0b0000000000100u);
        writer.Write((value & 0b0000000001000u) == 0b0000000001000u);
        writer.Write((value & 0b0000000010000u) == 0b0000000010000u);
        writer.Write((value & 0b0000000100000u) == 0b0000000100000u);
        writer.Write((value & 0b0000001000000u) == 0b0000001000000u);
        writer.Write((value & 0b0000010000000u) == 0b0000010000000u);
        writer.Write((value & 0b0000100000000u) == 0b0000100000000u);
        writer.Write((value & 0b0001000000000u) == 0b0001000000000u);
        writer.Write((value & 0b0010000000000u) == 0b0010000000000u);
        writer.Write((value & 0b0100000000000u) == 0b0100000000000u);
        writer.Write((value & 0b1000000000000u) == 0b1000000000000u);
    }

    public static uint ReadUInt13<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000000001u : 0)
             | (reader.Read() ? 0b0000000000010u : 0)
             | (reader.Read() ? 0b0000000000100u : 0)
             | (reader.Read() ? 0b0000000001000u : 0)
             | (reader.Read() ? 0b0000000010000u : 0)
             | (reader.Read() ? 0b0000000100000u : 0)
             | (reader.Read() ? 0b0000001000000u : 0)
             | (reader.Read() ? 0b0000010000000u : 0)
             | (reader.Read() ? 0b0000100000000u : 0)
             | (reader.Read() ? 0b0001000000000u : 0)
             | (reader.Read() ? 0b0010000000000u : 0)
             | (reader.Read() ? 0b0100000000000u : 0)
             | (reader.Read() ? 0b1000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 14 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt14<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000000000001u) == 0b00000000000001u);
        writer.Write((value & 0b00000000000010u) == 0b00000000000010u);
        writer.Write((value & 0b00000000000100u) == 0b00000000000100u);
        writer.Write((value & 0b00000000001000u) == 0b00000000001000u);
        writer.Write((value & 0b00000000010000u) == 0b00000000010000u);
        writer.Write((value & 0b00000000100000u) == 0b00000000100000u);
        writer.Write((value & 0b00000001000000u) == 0b00000001000000u);
        writer.Write((value & 0b00000010000000u) == 0b00000010000000u);
        writer.Write((value & 0b00000100000000u) == 0b00000100000000u);
        writer.Write((value & 0b00001000000000u) == 0b00001000000000u);
        writer.Write((value & 0b00010000000000u) == 0b00010000000000u);
        writer.Write((value & 0b00100000000000u) == 0b00100000000000u);
        writer.Write((value & 0b01000000000000u) == 0b01000000000000u);
        writer.Write((value & 0b10000000000000u) == 0b10000000000000u);
    }

    public static uint ReadUInt14<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000000000001u : 0)
             | (reader.Read() ? 0b00000000000010u : 0)
             | (reader.Read() ? 0b00000000000100u : 0)
             | (reader.Read() ? 0b00000000001000u : 0)
             | (reader.Read() ? 0b00000000010000u : 0)
             | (reader.Read() ? 0b00000000100000u : 0)
             | (reader.Read() ? 0b00000001000000u : 0)
             | (reader.Read() ? 0b00000010000000u : 0)
             | (reader.Read() ? 0b00000100000000u : 0)
             | (reader.Read() ? 0b00001000000000u : 0)
             | (reader.Read() ? 0b00010000000000u : 0)
             | (reader.Read() ? 0b00100000000000u : 0)
             | (reader.Read() ? 0b01000000000000u : 0)
             | (reader.Read() ? 0b10000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 15 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt15<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000000000001u) == 0b000000000000001u);
        writer.Write((value & 0b000000000000010u) == 0b000000000000010u);
        writer.Write((value & 0b000000000000100u) == 0b000000000000100u);
        writer.Write((value & 0b000000000001000u) == 0b000000000001000u);
        writer.Write((value & 0b000000000010000u) == 0b000000000010000u);
        writer.Write((value & 0b000000000100000u) == 0b000000000100000u);
        writer.Write((value & 0b000000001000000u) == 0b000000001000000u);
        writer.Write((value & 0b000000010000000u) == 0b000000010000000u);
        writer.Write((value & 0b000000100000000u) == 0b000000100000000u);
        writer.Write((value & 0b000001000000000u) == 0b000001000000000u);
        writer.Write((value & 0b000010000000000u) == 0b000010000000000u);
        writer.Write((value & 0b000100000000000u) == 0b000100000000000u);
        writer.Write((value & 0b001000000000000u) == 0b001000000000000u);
        writer.Write((value & 0b010000000000000u) == 0b010000000000000u);
        writer.Write((value & 0b100000000000000u) == 0b100000000000000u);
    }

    public static uint ReadUInt15<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000000000001u : 0)
             | (reader.Read() ? 0b000000000000010u : 0)
             | (reader.Read() ? 0b000000000000100u : 0)
             | (reader.Read() ? 0b000000000001000u : 0)
             | (reader.Read() ? 0b000000000010000u : 0)
             | (reader.Read() ? 0b000000000100000u : 0)
             | (reader.Read() ? 0b000000001000000u : 0)
             | (reader.Read() ? 0b000000010000000u : 0)
             | (reader.Read() ? 0b000000100000000u : 0)
             | (reader.Read() ? 0b000001000000000u : 0)
             | (reader.Read() ? 0b000010000000000u : 0)
             | (reader.Read() ? 0b000100000000000u : 0)
             | (reader.Read() ? 0b001000000000000u : 0)
             | (reader.Read() ? 0b010000000000000u : 0)
             | (reader.Read() ? 0b100000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 16 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt16<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000000000001u) == 0b0000000000000001u);
        writer.Write((value & 0b0000000000000010u) == 0b0000000000000010u);
        writer.Write((value & 0b0000000000000100u) == 0b0000000000000100u);
        writer.Write((value & 0b0000000000001000u) == 0b0000000000001000u);
        writer.Write((value & 0b0000000000010000u) == 0b0000000000010000u);
        writer.Write((value & 0b0000000000100000u) == 0b0000000000100000u);
        writer.Write((value & 0b0000000001000000u) == 0b0000000001000000u);
        writer.Write((value & 0b0000000010000000u) == 0b0000000010000000u);
        writer.Write((value & 0b0000000100000000u) == 0b0000000100000000u);
        writer.Write((value & 0b0000001000000000u) == 0b0000001000000000u);
        writer.Write((value & 0b0000010000000000u) == 0b0000010000000000u);
        writer.Write((value & 0b0000100000000000u) == 0b0000100000000000u);
        writer.Write((value & 0b0001000000000000u) == 0b0001000000000000u);
        writer.Write((value & 0b0010000000000000u) == 0b0010000000000000u);
        writer.Write((value & 0b0100000000000000u) == 0b0100000000000000u);
        writer.Write((value & 0b1000000000000000u) == 0b1000000000000000u);
    }

    public static uint ReadUInt16<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000000000001u : 0)
             | (reader.Read() ? 0b0000000000000010u : 0)
             | (reader.Read() ? 0b0000000000000100u : 0)
             | (reader.Read() ? 0b0000000000001000u : 0)
             | (reader.Read() ? 0b0000000000010000u : 0)
             | (reader.Read() ? 0b0000000000100000u : 0)
             | (reader.Read() ? 0b0000000001000000u : 0)
             | (reader.Read() ? 0b0000000010000000u : 0)
             | (reader.Read() ? 0b0000000100000000u : 0)
             | (reader.Read() ? 0b0000001000000000u : 0)
             | (reader.Read() ? 0b0000010000000000u : 0)
             | (reader.Read() ? 0b0000100000000000u : 0)
             | (reader.Read() ? 0b0001000000000000u : 0)
             | (reader.Read() ? 0b0010000000000000u : 0)
             | (reader.Read() ? 0b0100000000000000u : 0)
             | (reader.Read() ? 0b1000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 17 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt17<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000000000000001u) == 0b00000000000000001u);
        writer.Write((value & 0b00000000000000010u) == 0b00000000000000010u);
        writer.Write((value & 0b00000000000000100u) == 0b00000000000000100u);
        writer.Write((value & 0b00000000000001000u) == 0b00000000000001000u);
        writer.Write((value & 0b00000000000010000u) == 0b00000000000010000u);
        writer.Write((value & 0b00000000000100000u) == 0b00000000000100000u);
        writer.Write((value & 0b00000000001000000u) == 0b00000000001000000u);
        writer.Write((value & 0b00000000010000000u) == 0b00000000010000000u);
        writer.Write((value & 0b00000000100000000u) == 0b00000000100000000u);
        writer.Write((value & 0b00000001000000000u) == 0b00000001000000000u);
        writer.Write((value & 0b00000010000000000u) == 0b00000010000000000u);
        writer.Write((value & 0b00000100000000000u) == 0b00000100000000000u);
        writer.Write((value & 0b00001000000000000u) == 0b00001000000000000u);
        writer.Write((value & 0b00010000000000000u) == 0b00010000000000000u);
        writer.Write((value & 0b00100000000000000u) == 0b00100000000000000u);
        writer.Write((value & 0b01000000000000000u) == 0b01000000000000000u);
        writer.Write((value & 0b10000000000000000u) == 0b10000000000000000u);
    }

    public static uint ReadUInt17<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000000000000001u : 0)
             | (reader.Read() ? 0b00000000000000010u : 0)
             | (reader.Read() ? 0b00000000000000100u : 0)
             | (reader.Read() ? 0b00000000000001000u : 0)
             | (reader.Read() ? 0b00000000000010000u : 0)
             | (reader.Read() ? 0b00000000000100000u : 0)
             | (reader.Read() ? 0b00000000001000000u : 0)
             | (reader.Read() ? 0b00000000010000000u : 0)
             | (reader.Read() ? 0b00000000100000000u : 0)
             | (reader.Read() ? 0b00000001000000000u : 0)
             | (reader.Read() ? 0b00000010000000000u : 0)
             | (reader.Read() ? 0b00000100000000000u : 0)
             | (reader.Read() ? 0b00001000000000000u : 0)
             | (reader.Read() ? 0b00010000000000000u : 0)
             | (reader.Read() ? 0b00100000000000000u : 0)
             | (reader.Read() ? 0b01000000000000000u : 0)
             | (reader.Read() ? 0b10000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 18 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt18<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000000000000001u) == 0b000000000000000001u);
        writer.Write((value & 0b000000000000000010u) == 0b000000000000000010u);
        writer.Write((value & 0b000000000000000100u) == 0b000000000000000100u);
        writer.Write((value & 0b000000000000001000u) == 0b000000000000001000u);
        writer.Write((value & 0b000000000000010000u) == 0b000000000000010000u);
        writer.Write((value & 0b000000000000100000u) == 0b000000000000100000u);
        writer.Write((value & 0b000000000001000000u) == 0b000000000001000000u);
        writer.Write((value & 0b000000000010000000u) == 0b000000000010000000u);
        writer.Write((value & 0b000000000100000000u) == 0b000000000100000000u);
        writer.Write((value & 0b000000001000000000u) == 0b000000001000000000u);
        writer.Write((value & 0b000000010000000000u) == 0b000000010000000000u);
        writer.Write((value & 0b000000100000000000u) == 0b000000100000000000u);
        writer.Write((value & 0b000001000000000000u) == 0b000001000000000000u);
        writer.Write((value & 0b000010000000000000u) == 0b000010000000000000u);
        writer.Write((value & 0b000100000000000000u) == 0b000100000000000000u);
        writer.Write((value & 0b001000000000000000u) == 0b001000000000000000u);
        writer.Write((value & 0b010000000000000000u) == 0b010000000000000000u);
        writer.Write((value & 0b100000000000000000u) == 0b100000000000000000u);
    }

    public static uint ReadUInt18<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000000000000001u : 0)
             | (reader.Read() ? 0b000000000000000010u : 0)
             | (reader.Read() ? 0b000000000000000100u : 0)
             | (reader.Read() ? 0b000000000000001000u : 0)
             | (reader.Read() ? 0b000000000000010000u : 0)
             | (reader.Read() ? 0b000000000000100000u : 0)
             | (reader.Read() ? 0b000000000001000000u : 0)
             | (reader.Read() ? 0b000000000010000000u : 0)
             | (reader.Read() ? 0b000000000100000000u : 0)
             | (reader.Read() ? 0b000000001000000000u : 0)
             | (reader.Read() ? 0b000000010000000000u : 0)
             | (reader.Read() ? 0b000000100000000000u : 0)
             | (reader.Read() ? 0b000001000000000000u : 0)
             | (reader.Read() ? 0b000010000000000000u : 0)
             | (reader.Read() ? 0b000100000000000000u : 0)
             | (reader.Read() ? 0b001000000000000000u : 0)
             | (reader.Read() ? 0b010000000000000000u : 0)
             | (reader.Read() ? 0b100000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 19 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt19<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000000000000001u) == 0b0000000000000000001u);
        writer.Write((value & 0b0000000000000000010u) == 0b0000000000000000010u);
        writer.Write((value & 0b0000000000000000100u) == 0b0000000000000000100u);
        writer.Write((value & 0b0000000000000001000u) == 0b0000000000000001000u);
        writer.Write((value & 0b0000000000000010000u) == 0b0000000000000010000u);
        writer.Write((value & 0b0000000000000100000u) == 0b0000000000000100000u);
        writer.Write((value & 0b0000000000001000000u) == 0b0000000000001000000u);
        writer.Write((value & 0b0000000000010000000u) == 0b0000000000010000000u);
        writer.Write((value & 0b0000000000100000000u) == 0b0000000000100000000u);
        writer.Write((value & 0b0000000001000000000u) == 0b0000000001000000000u);
        writer.Write((value & 0b0000000010000000000u) == 0b0000000010000000000u);
        writer.Write((value & 0b0000000100000000000u) == 0b0000000100000000000u);
        writer.Write((value & 0b0000001000000000000u) == 0b0000001000000000000u);
        writer.Write((value & 0b0000010000000000000u) == 0b0000010000000000000u);
        writer.Write((value & 0b0000100000000000000u) == 0b0000100000000000000u);
        writer.Write((value & 0b0001000000000000000u) == 0b0001000000000000000u);
        writer.Write((value & 0b0010000000000000000u) == 0b0010000000000000000u);
        writer.Write((value & 0b0100000000000000000u) == 0b0100000000000000000u);
        writer.Write((value & 0b1000000000000000000u) == 0b1000000000000000000u);
    }

    public static uint ReadUInt19<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000000000000001u : 0)
             | (reader.Read() ? 0b0000000000000000010u : 0)
             | (reader.Read() ? 0b0000000000000000100u : 0)
             | (reader.Read() ? 0b0000000000000001000u : 0)
             | (reader.Read() ? 0b0000000000000010000u : 0)
             | (reader.Read() ? 0b0000000000000100000u : 0)
             | (reader.Read() ? 0b0000000000001000000u : 0)
             | (reader.Read() ? 0b0000000000010000000u : 0)
             | (reader.Read() ? 0b0000000000100000000u : 0)
             | (reader.Read() ? 0b0000000001000000000u : 0)
             | (reader.Read() ? 0b0000000010000000000u : 0)
             | (reader.Read() ? 0b0000000100000000000u : 0)
             | (reader.Read() ? 0b0000001000000000000u : 0)
             | (reader.Read() ? 0b0000010000000000000u : 0)
             | (reader.Read() ? 0b0000100000000000000u : 0)
             | (reader.Read() ? 0b0001000000000000000u : 0)
             | (reader.Read() ? 0b0010000000000000000u : 0)
             | (reader.Read() ? 0b0100000000000000000u : 0)
             | (reader.Read() ? 0b1000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 20 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt20<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000000000000000001u) == 0b00000000000000000001u);
        writer.Write((value & 0b00000000000000000010u) == 0b00000000000000000010u);
        writer.Write((value & 0b00000000000000000100u) == 0b00000000000000000100u);
        writer.Write((value & 0b00000000000000001000u) == 0b00000000000000001000u);
        writer.Write((value & 0b00000000000000010000u) == 0b00000000000000010000u);
        writer.Write((value & 0b00000000000000100000u) == 0b00000000000000100000u);
        writer.Write((value & 0b00000000000001000000u) == 0b00000000000001000000u);
        writer.Write((value & 0b00000000000010000000u) == 0b00000000000010000000u);
        writer.Write((value & 0b00000000000100000000u) == 0b00000000000100000000u);
        writer.Write((value & 0b00000000001000000000u) == 0b00000000001000000000u);
        writer.Write((value & 0b00000000010000000000u) == 0b00000000010000000000u);
        writer.Write((value & 0b00000000100000000000u) == 0b00000000100000000000u);
        writer.Write((value & 0b00000001000000000000u) == 0b00000001000000000000u);
        writer.Write((value & 0b00000010000000000000u) == 0b00000010000000000000u);
        writer.Write((value & 0b00000100000000000000u) == 0b00000100000000000000u);
        writer.Write((value & 0b00001000000000000000u) == 0b00001000000000000000u);
        writer.Write((value & 0b00010000000000000000u) == 0b00010000000000000000u);
        writer.Write((value & 0b00100000000000000000u) == 0b00100000000000000000u);
        writer.Write((value & 0b01000000000000000000u) == 0b01000000000000000000u);
        writer.Write((value & 0b10000000000000000000u) == 0b10000000000000000000u);
    }

    public static uint ReadUInt20<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000000000000000001u : 0)
             | (reader.Read() ? 0b00000000000000000010u : 0)
             | (reader.Read() ? 0b00000000000000000100u : 0)
             | (reader.Read() ? 0b00000000000000001000u : 0)
             | (reader.Read() ? 0b00000000000000010000u : 0)
             | (reader.Read() ? 0b00000000000000100000u : 0)
             | (reader.Read() ? 0b00000000000001000000u : 0)
             | (reader.Read() ? 0b00000000000010000000u : 0)
             | (reader.Read() ? 0b00000000000100000000u : 0)
             | (reader.Read() ? 0b00000000001000000000u : 0)
             | (reader.Read() ? 0b00000000010000000000u : 0)
             | (reader.Read() ? 0b00000000100000000000u : 0)
             | (reader.Read() ? 0b00000001000000000000u : 0)
             | (reader.Read() ? 0b00000010000000000000u : 0)
             | (reader.Read() ? 0b00000100000000000000u : 0)
             | (reader.Read() ? 0b00001000000000000000u : 0)
             | (reader.Read() ? 0b00010000000000000000u : 0)
             | (reader.Read() ? 0b00100000000000000000u : 0)
             | (reader.Read() ? 0b01000000000000000000u : 0)
             | (reader.Read() ? 0b10000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 21 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt21<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000000000000000001u) == 0b000000000000000000001u);
        writer.Write((value & 0b000000000000000000010u) == 0b000000000000000000010u);
        writer.Write((value & 0b000000000000000000100u) == 0b000000000000000000100u);
        writer.Write((value & 0b000000000000000001000u) == 0b000000000000000001000u);
        writer.Write((value & 0b000000000000000010000u) == 0b000000000000000010000u);
        writer.Write((value & 0b000000000000000100000u) == 0b000000000000000100000u);
        writer.Write((value & 0b000000000000001000000u) == 0b000000000000001000000u);
        writer.Write((value & 0b000000000000010000000u) == 0b000000000000010000000u);
        writer.Write((value & 0b000000000000100000000u) == 0b000000000000100000000u);
        writer.Write((value & 0b000000000001000000000u) == 0b000000000001000000000u);
        writer.Write((value & 0b000000000010000000000u) == 0b000000000010000000000u);
        writer.Write((value & 0b000000000100000000000u) == 0b000000000100000000000u);
        writer.Write((value & 0b000000001000000000000u) == 0b000000001000000000000u);
        writer.Write((value & 0b000000010000000000000u) == 0b000000010000000000000u);
        writer.Write((value & 0b000000100000000000000u) == 0b000000100000000000000u);
        writer.Write((value & 0b000001000000000000000u) == 0b000001000000000000000u);
        writer.Write((value & 0b000010000000000000000u) == 0b000010000000000000000u);
        writer.Write((value & 0b000100000000000000000u) == 0b000100000000000000000u);
        writer.Write((value & 0b001000000000000000000u) == 0b001000000000000000000u);
        writer.Write((value & 0b010000000000000000000u) == 0b010000000000000000000u);
        writer.Write((value & 0b100000000000000000000u) == 0b100000000000000000000u);
    }

    public static uint ReadUInt21<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000000000000000001u : 0)
             | (reader.Read() ? 0b000000000000000000010u : 0)
             | (reader.Read() ? 0b000000000000000000100u : 0)
             | (reader.Read() ? 0b000000000000000001000u : 0)
             | (reader.Read() ? 0b000000000000000010000u : 0)
             | (reader.Read() ? 0b000000000000000100000u : 0)
             | (reader.Read() ? 0b000000000000001000000u : 0)
             | (reader.Read() ? 0b000000000000010000000u : 0)
             | (reader.Read() ? 0b000000000000100000000u : 0)
             | (reader.Read() ? 0b000000000001000000000u : 0)
             | (reader.Read() ? 0b000000000010000000000u : 0)
             | (reader.Read() ? 0b000000000100000000000u : 0)
             | (reader.Read() ? 0b000000001000000000000u : 0)
             | (reader.Read() ? 0b000000010000000000000u : 0)
             | (reader.Read() ? 0b000000100000000000000u : 0)
             | (reader.Read() ? 0b000001000000000000000u : 0)
             | (reader.Read() ? 0b000010000000000000000u : 0)
             | (reader.Read() ? 0b000100000000000000000u : 0)
             | (reader.Read() ? 0b001000000000000000000u : 0)
             | (reader.Read() ? 0b010000000000000000000u : 0)
             | (reader.Read() ? 0b100000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 22 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt22<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000000000000000001u) == 0b0000000000000000000001u);
        writer.Write((value & 0b0000000000000000000010u) == 0b0000000000000000000010u);
        writer.Write((value & 0b0000000000000000000100u) == 0b0000000000000000000100u);
        writer.Write((value & 0b0000000000000000001000u) == 0b0000000000000000001000u);
        writer.Write((value & 0b0000000000000000010000u) == 0b0000000000000000010000u);
        writer.Write((value & 0b0000000000000000100000u) == 0b0000000000000000100000u);
        writer.Write((value & 0b0000000000000001000000u) == 0b0000000000000001000000u);
        writer.Write((value & 0b0000000000000010000000u) == 0b0000000000000010000000u);
        writer.Write((value & 0b0000000000000100000000u) == 0b0000000000000100000000u);
        writer.Write((value & 0b0000000000001000000000u) == 0b0000000000001000000000u);
        writer.Write((value & 0b0000000000010000000000u) == 0b0000000000010000000000u);
        writer.Write((value & 0b0000000000100000000000u) == 0b0000000000100000000000u);
        writer.Write((value & 0b0000000001000000000000u) == 0b0000000001000000000000u);
        writer.Write((value & 0b0000000010000000000000u) == 0b0000000010000000000000u);
        writer.Write((value & 0b0000000100000000000000u) == 0b0000000100000000000000u);
        writer.Write((value & 0b0000001000000000000000u) == 0b0000001000000000000000u);
        writer.Write((value & 0b0000010000000000000000u) == 0b0000010000000000000000u);
        writer.Write((value & 0b0000100000000000000000u) == 0b0000100000000000000000u);
        writer.Write((value & 0b0001000000000000000000u) == 0b0001000000000000000000u);
        writer.Write((value & 0b0010000000000000000000u) == 0b0010000000000000000000u);
        writer.Write((value & 0b0100000000000000000000u) == 0b0100000000000000000000u);
        writer.Write((value & 0b1000000000000000000000u) == 0b1000000000000000000000u);
    }

    public static uint ReadUInt22<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000000000000000001u : 0)
             | (reader.Read() ? 0b0000000000000000000010u : 0)
             | (reader.Read() ? 0b0000000000000000000100u : 0)
             | (reader.Read() ? 0b0000000000000000001000u : 0)
             | (reader.Read() ? 0b0000000000000000010000u : 0)
             | (reader.Read() ? 0b0000000000000000100000u : 0)
             | (reader.Read() ? 0b0000000000000001000000u : 0)
             | (reader.Read() ? 0b0000000000000010000000u : 0)
             | (reader.Read() ? 0b0000000000000100000000u : 0)
             | (reader.Read() ? 0b0000000000001000000000u : 0)
             | (reader.Read() ? 0b0000000000010000000000u : 0)
             | (reader.Read() ? 0b0000000000100000000000u : 0)
             | (reader.Read() ? 0b0000000001000000000000u : 0)
             | (reader.Read() ? 0b0000000010000000000000u : 0)
             | (reader.Read() ? 0b0000000100000000000000u : 0)
             | (reader.Read() ? 0b0000001000000000000000u : 0)
             | (reader.Read() ? 0b0000010000000000000000u : 0)
             | (reader.Read() ? 0b0000100000000000000000u : 0)
             | (reader.Read() ? 0b0001000000000000000000u : 0)
             | (reader.Read() ? 0b0010000000000000000000u : 0)
             | (reader.Read() ? 0b0100000000000000000000u : 0)
             | (reader.Read() ? 0b1000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 23 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt23<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000000000000000000001u) == 0b00000000000000000000001u);
        writer.Write((value & 0b00000000000000000000010u) == 0b00000000000000000000010u);
        writer.Write((value & 0b00000000000000000000100u) == 0b00000000000000000000100u);
        writer.Write((value & 0b00000000000000000001000u) == 0b00000000000000000001000u);
        writer.Write((value & 0b00000000000000000010000u) == 0b00000000000000000010000u);
        writer.Write((value & 0b00000000000000000100000u) == 0b00000000000000000100000u);
        writer.Write((value & 0b00000000000000001000000u) == 0b00000000000000001000000u);
        writer.Write((value & 0b00000000000000010000000u) == 0b00000000000000010000000u);
        writer.Write((value & 0b00000000000000100000000u) == 0b00000000000000100000000u);
        writer.Write((value & 0b00000000000001000000000u) == 0b00000000000001000000000u);
        writer.Write((value & 0b00000000000010000000000u) == 0b00000000000010000000000u);
        writer.Write((value & 0b00000000000100000000000u) == 0b00000000000100000000000u);
        writer.Write((value & 0b00000000001000000000000u) == 0b00000000001000000000000u);
        writer.Write((value & 0b00000000010000000000000u) == 0b00000000010000000000000u);
        writer.Write((value & 0b00000000100000000000000u) == 0b00000000100000000000000u);
        writer.Write((value & 0b00000001000000000000000u) == 0b00000001000000000000000u);
        writer.Write((value & 0b00000010000000000000000u) == 0b00000010000000000000000u);
        writer.Write((value & 0b00000100000000000000000u) == 0b00000100000000000000000u);
        writer.Write((value & 0b00001000000000000000000u) == 0b00001000000000000000000u);
        writer.Write((value & 0b00010000000000000000000u) == 0b00010000000000000000000u);
        writer.Write((value & 0b00100000000000000000000u) == 0b00100000000000000000000u);
        writer.Write((value & 0b01000000000000000000000u) == 0b01000000000000000000000u);
        writer.Write((value & 0b10000000000000000000000u) == 0b10000000000000000000000u);
    }

    public static uint ReadUInt23<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000000000000000000001u : 0)
             | (reader.Read() ? 0b00000000000000000000010u : 0)
             | (reader.Read() ? 0b00000000000000000000100u : 0)
             | (reader.Read() ? 0b00000000000000000001000u : 0)
             | (reader.Read() ? 0b00000000000000000010000u : 0)
             | (reader.Read() ? 0b00000000000000000100000u : 0)
             | (reader.Read() ? 0b00000000000000001000000u : 0)
             | (reader.Read() ? 0b00000000000000010000000u : 0)
             | (reader.Read() ? 0b00000000000000100000000u : 0)
             | (reader.Read() ? 0b00000000000001000000000u : 0)
             | (reader.Read() ? 0b00000000000010000000000u : 0)
             | (reader.Read() ? 0b00000000000100000000000u : 0)
             | (reader.Read() ? 0b00000000001000000000000u : 0)
             | (reader.Read() ? 0b00000000010000000000000u : 0)
             | (reader.Read() ? 0b00000000100000000000000u : 0)
             | (reader.Read() ? 0b00000001000000000000000u : 0)
             | (reader.Read() ? 0b00000010000000000000000u : 0)
             | (reader.Read() ? 0b00000100000000000000000u : 0)
             | (reader.Read() ? 0b00001000000000000000000u : 0)
             | (reader.Read() ? 0b00010000000000000000000u : 0)
             | (reader.Read() ? 0b00100000000000000000000u : 0)
             | (reader.Read() ? 0b01000000000000000000000u : 0)
             | (reader.Read() ? 0b10000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 24 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt24<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000000000000000000001u) == 0b000000000000000000000001u);
        writer.Write((value & 0b000000000000000000000010u) == 0b000000000000000000000010u);
        writer.Write((value & 0b000000000000000000000100u) == 0b000000000000000000000100u);
        writer.Write((value & 0b000000000000000000001000u) == 0b000000000000000000001000u);
        writer.Write((value & 0b000000000000000000010000u) == 0b000000000000000000010000u);
        writer.Write((value & 0b000000000000000000100000u) == 0b000000000000000000100000u);
        writer.Write((value & 0b000000000000000001000000u) == 0b000000000000000001000000u);
        writer.Write((value & 0b000000000000000010000000u) == 0b000000000000000010000000u);
        writer.Write((value & 0b000000000000000100000000u) == 0b000000000000000100000000u);
        writer.Write((value & 0b000000000000001000000000u) == 0b000000000000001000000000u);
        writer.Write((value & 0b000000000000010000000000u) == 0b000000000000010000000000u);
        writer.Write((value & 0b000000000000100000000000u) == 0b000000000000100000000000u);
        writer.Write((value & 0b000000000001000000000000u) == 0b000000000001000000000000u);
        writer.Write((value & 0b000000000010000000000000u) == 0b000000000010000000000000u);
        writer.Write((value & 0b000000000100000000000000u) == 0b000000000100000000000000u);
        writer.Write((value & 0b000000001000000000000000u) == 0b000000001000000000000000u);
        writer.Write((value & 0b000000010000000000000000u) == 0b000000010000000000000000u);
        writer.Write((value & 0b000000100000000000000000u) == 0b000000100000000000000000u);
        writer.Write((value & 0b000001000000000000000000u) == 0b000001000000000000000000u);
        writer.Write((value & 0b000010000000000000000000u) == 0b000010000000000000000000u);
        writer.Write((value & 0b000100000000000000000000u) == 0b000100000000000000000000u);
        writer.Write((value & 0b001000000000000000000000u) == 0b001000000000000000000000u);
        writer.Write((value & 0b010000000000000000000000u) == 0b010000000000000000000000u);
        writer.Write((value & 0b100000000000000000000000u) == 0b100000000000000000000000u);
    }

    public static uint ReadUInt24<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000000000000000000001u : 0)
             | (reader.Read() ? 0b000000000000000000000010u : 0)
             | (reader.Read() ? 0b000000000000000000000100u : 0)
             | (reader.Read() ? 0b000000000000000000001000u : 0)
             | (reader.Read() ? 0b000000000000000000010000u : 0)
             | (reader.Read() ? 0b000000000000000000100000u : 0)
             | (reader.Read() ? 0b000000000000000001000000u : 0)
             | (reader.Read() ? 0b000000000000000010000000u : 0)
             | (reader.Read() ? 0b000000000000000100000000u : 0)
             | (reader.Read() ? 0b000000000000001000000000u : 0)
             | (reader.Read() ? 0b000000000000010000000000u : 0)
             | (reader.Read() ? 0b000000000000100000000000u : 0)
             | (reader.Read() ? 0b000000000001000000000000u : 0)
             | (reader.Read() ? 0b000000000010000000000000u : 0)
             | (reader.Read() ? 0b000000000100000000000000u : 0)
             | (reader.Read() ? 0b000000001000000000000000u : 0)
             | (reader.Read() ? 0b000000010000000000000000u : 0)
             | (reader.Read() ? 0b000000100000000000000000u : 0)
             | (reader.Read() ? 0b000001000000000000000000u : 0)
             | (reader.Read() ? 0b000010000000000000000000u : 0)
             | (reader.Read() ? 0b000100000000000000000000u : 0)
             | (reader.Read() ? 0b001000000000000000000000u : 0)
             | (reader.Read() ? 0b010000000000000000000000u : 0)
             | (reader.Read() ? 0b100000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 25 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt25<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000000000000000000001u) == 0b0000000000000000000000001u);
        writer.Write((value & 0b0000000000000000000000010u) == 0b0000000000000000000000010u);
        writer.Write((value & 0b0000000000000000000000100u) == 0b0000000000000000000000100u);
        writer.Write((value & 0b0000000000000000000001000u) == 0b0000000000000000000001000u);
        writer.Write((value & 0b0000000000000000000010000u) == 0b0000000000000000000010000u);
        writer.Write((value & 0b0000000000000000000100000u) == 0b0000000000000000000100000u);
        writer.Write((value & 0b0000000000000000001000000u) == 0b0000000000000000001000000u);
        writer.Write((value & 0b0000000000000000010000000u) == 0b0000000000000000010000000u);
        writer.Write((value & 0b0000000000000000100000000u) == 0b0000000000000000100000000u);
        writer.Write((value & 0b0000000000000001000000000u) == 0b0000000000000001000000000u);
        writer.Write((value & 0b0000000000000010000000000u) == 0b0000000000000010000000000u);
        writer.Write((value & 0b0000000000000100000000000u) == 0b0000000000000100000000000u);
        writer.Write((value & 0b0000000000001000000000000u) == 0b0000000000001000000000000u);
        writer.Write((value & 0b0000000000010000000000000u) == 0b0000000000010000000000000u);
        writer.Write((value & 0b0000000000100000000000000u) == 0b0000000000100000000000000u);
        writer.Write((value & 0b0000000001000000000000000u) == 0b0000000001000000000000000u);
        writer.Write((value & 0b0000000010000000000000000u) == 0b0000000010000000000000000u);
        writer.Write((value & 0b0000000100000000000000000u) == 0b0000000100000000000000000u);
        writer.Write((value & 0b0000001000000000000000000u) == 0b0000001000000000000000000u);
        writer.Write((value & 0b0000010000000000000000000u) == 0b0000010000000000000000000u);
        writer.Write((value & 0b0000100000000000000000000u) == 0b0000100000000000000000000u);
        writer.Write((value & 0b0001000000000000000000000u) == 0b0001000000000000000000000u);
        writer.Write((value & 0b0010000000000000000000000u) == 0b0010000000000000000000000u);
        writer.Write((value & 0b0100000000000000000000000u) == 0b0100000000000000000000000u);
        writer.Write((value & 0b1000000000000000000000000u) == 0b1000000000000000000000000u);
    }

    public static uint ReadUInt25<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000000000000000000001u : 0)
             | (reader.Read() ? 0b0000000000000000000000010u : 0)
             | (reader.Read() ? 0b0000000000000000000000100u : 0)
             | (reader.Read() ? 0b0000000000000000000001000u : 0)
             | (reader.Read() ? 0b0000000000000000000010000u : 0)
             | (reader.Read() ? 0b0000000000000000000100000u : 0)
             | (reader.Read() ? 0b0000000000000000001000000u : 0)
             | (reader.Read() ? 0b0000000000000000010000000u : 0)
             | (reader.Read() ? 0b0000000000000000100000000u : 0)
             | (reader.Read() ? 0b0000000000000001000000000u : 0)
             | (reader.Read() ? 0b0000000000000010000000000u : 0)
             | (reader.Read() ? 0b0000000000000100000000000u : 0)
             | (reader.Read() ? 0b0000000000001000000000000u : 0)
             | (reader.Read() ? 0b0000000000010000000000000u : 0)
             | (reader.Read() ? 0b0000000000100000000000000u : 0)
             | (reader.Read() ? 0b0000000001000000000000000u : 0)
             | (reader.Read() ? 0b0000000010000000000000000u : 0)
             | (reader.Read() ? 0b0000000100000000000000000u : 0)
             | (reader.Read() ? 0b0000001000000000000000000u : 0)
             | (reader.Read() ? 0b0000010000000000000000000u : 0)
             | (reader.Read() ? 0b0000100000000000000000000u : 0)
             | (reader.Read() ? 0b0001000000000000000000000u : 0)
             | (reader.Read() ? 0b0010000000000000000000000u : 0)
             | (reader.Read() ? 0b0100000000000000000000000u : 0)
             | (reader.Read() ? 0b1000000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 26 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt26<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000000000000000000000001u) == 0b00000000000000000000000001u);
        writer.Write((value & 0b00000000000000000000000010u) == 0b00000000000000000000000010u);
        writer.Write((value & 0b00000000000000000000000100u) == 0b00000000000000000000000100u);
        writer.Write((value & 0b00000000000000000000001000u) == 0b00000000000000000000001000u);
        writer.Write((value & 0b00000000000000000000010000u) == 0b00000000000000000000010000u);
        writer.Write((value & 0b00000000000000000000100000u) == 0b00000000000000000000100000u);
        writer.Write((value & 0b00000000000000000001000000u) == 0b00000000000000000001000000u);
        writer.Write((value & 0b00000000000000000010000000u) == 0b00000000000000000010000000u);
        writer.Write((value & 0b00000000000000000100000000u) == 0b00000000000000000100000000u);
        writer.Write((value & 0b00000000000000001000000000u) == 0b00000000000000001000000000u);
        writer.Write((value & 0b00000000000000010000000000u) == 0b00000000000000010000000000u);
        writer.Write((value & 0b00000000000000100000000000u) == 0b00000000000000100000000000u);
        writer.Write((value & 0b00000000000001000000000000u) == 0b00000000000001000000000000u);
        writer.Write((value & 0b00000000000010000000000000u) == 0b00000000000010000000000000u);
        writer.Write((value & 0b00000000000100000000000000u) == 0b00000000000100000000000000u);
        writer.Write((value & 0b00000000001000000000000000u) == 0b00000000001000000000000000u);
        writer.Write((value & 0b00000000010000000000000000u) == 0b00000000010000000000000000u);
        writer.Write((value & 0b00000000100000000000000000u) == 0b00000000100000000000000000u);
        writer.Write((value & 0b00000001000000000000000000u) == 0b00000001000000000000000000u);
        writer.Write((value & 0b00000010000000000000000000u) == 0b00000010000000000000000000u);
        writer.Write((value & 0b00000100000000000000000000u) == 0b00000100000000000000000000u);
        writer.Write((value & 0b00001000000000000000000000u) == 0b00001000000000000000000000u);
        writer.Write((value & 0b00010000000000000000000000u) == 0b00010000000000000000000000u);
        writer.Write((value & 0b00100000000000000000000000u) == 0b00100000000000000000000000u);
        writer.Write((value & 0b01000000000000000000000000u) == 0b01000000000000000000000000u);
        writer.Write((value & 0b10000000000000000000000000u) == 0b10000000000000000000000000u);
    }

    public static uint ReadUInt26<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000000000000000000000001u : 0)
             | (reader.Read() ? 0b00000000000000000000000010u : 0)
             | (reader.Read() ? 0b00000000000000000000000100u : 0)
             | (reader.Read() ? 0b00000000000000000000001000u : 0)
             | (reader.Read() ? 0b00000000000000000000010000u : 0)
             | (reader.Read() ? 0b00000000000000000000100000u : 0)
             | (reader.Read() ? 0b00000000000000000001000000u : 0)
             | (reader.Read() ? 0b00000000000000000010000000u : 0)
             | (reader.Read() ? 0b00000000000000000100000000u : 0)
             | (reader.Read() ? 0b00000000000000001000000000u : 0)
             | (reader.Read() ? 0b00000000000000010000000000u : 0)
             | (reader.Read() ? 0b00000000000000100000000000u : 0)
             | (reader.Read() ? 0b00000000000001000000000000u : 0)
             | (reader.Read() ? 0b00000000000010000000000000u : 0)
             | (reader.Read() ? 0b00000000000100000000000000u : 0)
             | (reader.Read() ? 0b00000000001000000000000000u : 0)
             | (reader.Read() ? 0b00000000010000000000000000u : 0)
             | (reader.Read() ? 0b00000000100000000000000000u : 0)
             | (reader.Read() ? 0b00000001000000000000000000u : 0)
             | (reader.Read() ? 0b00000010000000000000000000u : 0)
             | (reader.Read() ? 0b00000100000000000000000000u : 0)
             | (reader.Read() ? 0b00001000000000000000000000u : 0)
             | (reader.Read() ? 0b00010000000000000000000000u : 0)
             | (reader.Read() ? 0b00100000000000000000000000u : 0)
             | (reader.Read() ? 0b01000000000000000000000000u : 0)
             | (reader.Read() ? 0b10000000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 27 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt27<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000000000000000000000001u) == 0b000000000000000000000000001u);
        writer.Write((value & 0b000000000000000000000000010u) == 0b000000000000000000000000010u);
        writer.Write((value & 0b000000000000000000000000100u) == 0b000000000000000000000000100u);
        writer.Write((value & 0b000000000000000000000001000u) == 0b000000000000000000000001000u);
        writer.Write((value & 0b000000000000000000000010000u) == 0b000000000000000000000010000u);
        writer.Write((value & 0b000000000000000000000100000u) == 0b000000000000000000000100000u);
        writer.Write((value & 0b000000000000000000001000000u) == 0b000000000000000000001000000u);
        writer.Write((value & 0b000000000000000000010000000u) == 0b000000000000000000010000000u);
        writer.Write((value & 0b000000000000000000100000000u) == 0b000000000000000000100000000u);
        writer.Write((value & 0b000000000000000001000000000u) == 0b000000000000000001000000000u);
        writer.Write((value & 0b000000000000000010000000000u) == 0b000000000000000010000000000u);
        writer.Write((value & 0b000000000000000100000000000u) == 0b000000000000000100000000000u);
        writer.Write((value & 0b000000000000001000000000000u) == 0b000000000000001000000000000u);
        writer.Write((value & 0b000000000000010000000000000u) == 0b000000000000010000000000000u);
        writer.Write((value & 0b000000000000100000000000000u) == 0b000000000000100000000000000u);
        writer.Write((value & 0b000000000001000000000000000u) == 0b000000000001000000000000000u);
        writer.Write((value & 0b000000000010000000000000000u) == 0b000000000010000000000000000u);
        writer.Write((value & 0b000000000100000000000000000u) == 0b000000000100000000000000000u);
        writer.Write((value & 0b000000001000000000000000000u) == 0b000000001000000000000000000u);
        writer.Write((value & 0b000000010000000000000000000u) == 0b000000010000000000000000000u);
        writer.Write((value & 0b000000100000000000000000000u) == 0b000000100000000000000000000u);
        writer.Write((value & 0b000001000000000000000000000u) == 0b000001000000000000000000000u);
        writer.Write((value & 0b000010000000000000000000000u) == 0b000010000000000000000000000u);
        writer.Write((value & 0b000100000000000000000000000u) == 0b000100000000000000000000000u);
        writer.Write((value & 0b001000000000000000000000000u) == 0b001000000000000000000000000u);
        writer.Write((value & 0b010000000000000000000000000u) == 0b010000000000000000000000000u);
        writer.Write((value & 0b100000000000000000000000000u) == 0b100000000000000000000000000u);
    }

    public static uint ReadUInt27<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000000000000000000000001u : 0)
             | (reader.Read() ? 0b000000000000000000000000010u : 0)
             | (reader.Read() ? 0b000000000000000000000000100u : 0)
             | (reader.Read() ? 0b000000000000000000000001000u : 0)
             | (reader.Read() ? 0b000000000000000000000010000u : 0)
             | (reader.Read() ? 0b000000000000000000000100000u : 0)
             | (reader.Read() ? 0b000000000000000000001000000u : 0)
             | (reader.Read() ? 0b000000000000000000010000000u : 0)
             | (reader.Read() ? 0b000000000000000000100000000u : 0)
             | (reader.Read() ? 0b000000000000000001000000000u : 0)
             | (reader.Read() ? 0b000000000000000010000000000u : 0)
             | (reader.Read() ? 0b000000000000000100000000000u : 0)
             | (reader.Read() ? 0b000000000000001000000000000u : 0)
             | (reader.Read() ? 0b000000000000010000000000000u : 0)
             | (reader.Read() ? 0b000000000000100000000000000u : 0)
             | (reader.Read() ? 0b000000000001000000000000000u : 0)
             | (reader.Read() ? 0b000000000010000000000000000u : 0)
             | (reader.Read() ? 0b000000000100000000000000000u : 0)
             | (reader.Read() ? 0b000000001000000000000000000u : 0)
             | (reader.Read() ? 0b000000010000000000000000000u : 0)
             | (reader.Read() ? 0b000000100000000000000000000u : 0)
             | (reader.Read() ? 0b000001000000000000000000000u : 0)
             | (reader.Read() ? 0b000010000000000000000000000u : 0)
             | (reader.Read() ? 0b000100000000000000000000000u : 0)
             | (reader.Read() ? 0b001000000000000000000000000u : 0)
             | (reader.Read() ? 0b010000000000000000000000000u : 0)
             | (reader.Read() ? 0b100000000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 28 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt28<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000000000000000000000001u) == 0b0000000000000000000000000001u);
        writer.Write((value & 0b0000000000000000000000000010u) == 0b0000000000000000000000000010u);
        writer.Write((value & 0b0000000000000000000000000100u) == 0b0000000000000000000000000100u);
        writer.Write((value & 0b0000000000000000000000001000u) == 0b0000000000000000000000001000u);
        writer.Write((value & 0b0000000000000000000000010000u) == 0b0000000000000000000000010000u);
        writer.Write((value & 0b0000000000000000000000100000u) == 0b0000000000000000000000100000u);
        writer.Write((value & 0b0000000000000000000001000000u) == 0b0000000000000000000001000000u);
        writer.Write((value & 0b0000000000000000000010000000u) == 0b0000000000000000000010000000u);
        writer.Write((value & 0b0000000000000000000100000000u) == 0b0000000000000000000100000000u);
        writer.Write((value & 0b0000000000000000001000000000u) == 0b0000000000000000001000000000u);
        writer.Write((value & 0b0000000000000000010000000000u) == 0b0000000000000000010000000000u);
        writer.Write((value & 0b0000000000000000100000000000u) == 0b0000000000000000100000000000u);
        writer.Write((value & 0b0000000000000001000000000000u) == 0b0000000000000001000000000000u);
        writer.Write((value & 0b0000000000000010000000000000u) == 0b0000000000000010000000000000u);
        writer.Write((value & 0b0000000000000100000000000000u) == 0b0000000000000100000000000000u);
        writer.Write((value & 0b0000000000001000000000000000u) == 0b0000000000001000000000000000u);
        writer.Write((value & 0b0000000000010000000000000000u) == 0b0000000000010000000000000000u);
        writer.Write((value & 0b0000000000100000000000000000u) == 0b0000000000100000000000000000u);
        writer.Write((value & 0b0000000001000000000000000000u) == 0b0000000001000000000000000000u);
        writer.Write((value & 0b0000000010000000000000000000u) == 0b0000000010000000000000000000u);
        writer.Write((value & 0b0000000100000000000000000000u) == 0b0000000100000000000000000000u);
        writer.Write((value & 0b0000001000000000000000000000u) == 0b0000001000000000000000000000u);
        writer.Write((value & 0b0000010000000000000000000000u) == 0b0000010000000000000000000000u);
        writer.Write((value & 0b0000100000000000000000000000u) == 0b0000100000000000000000000000u);
        writer.Write((value & 0b0001000000000000000000000000u) == 0b0001000000000000000000000000u);
        writer.Write((value & 0b0010000000000000000000000000u) == 0b0010000000000000000000000000u);
        writer.Write((value & 0b0100000000000000000000000000u) == 0b0100000000000000000000000000u);
        writer.Write((value & 0b1000000000000000000000000000u) == 0b1000000000000000000000000000u);
    }

    public static uint ReadUInt28<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000000000000000000000001u : 0)
             | (reader.Read() ? 0b0000000000000000000000000010u : 0)
             | (reader.Read() ? 0b0000000000000000000000000100u : 0)
             | (reader.Read() ? 0b0000000000000000000000001000u : 0)
             | (reader.Read() ? 0b0000000000000000000000010000u : 0)
             | (reader.Read() ? 0b0000000000000000000000100000u : 0)
             | (reader.Read() ? 0b0000000000000000000001000000u : 0)
             | (reader.Read() ? 0b0000000000000000000010000000u : 0)
             | (reader.Read() ? 0b0000000000000000000100000000u : 0)
             | (reader.Read() ? 0b0000000000000000001000000000u : 0)
             | (reader.Read() ? 0b0000000000000000010000000000u : 0)
             | (reader.Read() ? 0b0000000000000000100000000000u : 0)
             | (reader.Read() ? 0b0000000000000001000000000000u : 0)
             | (reader.Read() ? 0b0000000000000010000000000000u : 0)
             | (reader.Read() ? 0b0000000000000100000000000000u : 0)
             | (reader.Read() ? 0b0000000000001000000000000000u : 0)
             | (reader.Read() ? 0b0000000000010000000000000000u : 0)
             | (reader.Read() ? 0b0000000000100000000000000000u : 0)
             | (reader.Read() ? 0b0000000001000000000000000000u : 0)
             | (reader.Read() ? 0b0000000010000000000000000000u : 0)
             | (reader.Read() ? 0b0000000100000000000000000000u : 0)
             | (reader.Read() ? 0b0000001000000000000000000000u : 0)
             | (reader.Read() ? 0b0000010000000000000000000000u : 0)
             | (reader.Read() ? 0b0000100000000000000000000000u : 0)
             | (reader.Read() ? 0b0001000000000000000000000000u : 0)
             | (reader.Read() ? 0b0010000000000000000000000000u : 0)
             | (reader.Read() ? 0b0100000000000000000000000000u : 0)
             | (reader.Read() ? 0b1000000000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 29 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt29<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b00000000000000000000000000001u) == 0b00000000000000000000000000001u);
        writer.Write((value & 0b00000000000000000000000000010u) == 0b00000000000000000000000000010u);
        writer.Write((value & 0b00000000000000000000000000100u) == 0b00000000000000000000000000100u);
        writer.Write((value & 0b00000000000000000000000001000u) == 0b00000000000000000000000001000u);
        writer.Write((value & 0b00000000000000000000000010000u) == 0b00000000000000000000000010000u);
        writer.Write((value & 0b00000000000000000000000100000u) == 0b00000000000000000000000100000u);
        writer.Write((value & 0b00000000000000000000001000000u) == 0b00000000000000000000001000000u);
        writer.Write((value & 0b00000000000000000000010000000u) == 0b00000000000000000000010000000u);
        writer.Write((value & 0b00000000000000000000100000000u) == 0b00000000000000000000100000000u);
        writer.Write((value & 0b00000000000000000001000000000u) == 0b00000000000000000001000000000u);
        writer.Write((value & 0b00000000000000000010000000000u) == 0b00000000000000000010000000000u);
        writer.Write((value & 0b00000000000000000100000000000u) == 0b00000000000000000100000000000u);
        writer.Write((value & 0b00000000000000001000000000000u) == 0b00000000000000001000000000000u);
        writer.Write((value & 0b00000000000000010000000000000u) == 0b00000000000000010000000000000u);
        writer.Write((value & 0b00000000000000100000000000000u) == 0b00000000000000100000000000000u);
        writer.Write((value & 0b00000000000001000000000000000u) == 0b00000000000001000000000000000u);
        writer.Write((value & 0b00000000000010000000000000000u) == 0b00000000000010000000000000000u);
        writer.Write((value & 0b00000000000100000000000000000u) == 0b00000000000100000000000000000u);
        writer.Write((value & 0b00000000001000000000000000000u) == 0b00000000001000000000000000000u);
        writer.Write((value & 0b00000000010000000000000000000u) == 0b00000000010000000000000000000u);
        writer.Write((value & 0b00000000100000000000000000000u) == 0b00000000100000000000000000000u);
        writer.Write((value & 0b00000001000000000000000000000u) == 0b00000001000000000000000000000u);
        writer.Write((value & 0b00000010000000000000000000000u) == 0b00000010000000000000000000000u);
        writer.Write((value & 0b00000100000000000000000000000u) == 0b00000100000000000000000000000u);
        writer.Write((value & 0b00001000000000000000000000000u) == 0b00001000000000000000000000000u);
        writer.Write((value & 0b00010000000000000000000000000u) == 0b00010000000000000000000000000u);
        writer.Write((value & 0b00100000000000000000000000000u) == 0b00100000000000000000000000000u);
        writer.Write((value & 0b01000000000000000000000000000u) == 0b01000000000000000000000000000u);
        writer.Write((value & 0b10000000000000000000000000000u) == 0b10000000000000000000000000000u);
    }

    public static uint ReadUInt29<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b00000000000000000000000000001u : 0)
             | (reader.Read() ? 0b00000000000000000000000000010u : 0)
             | (reader.Read() ? 0b00000000000000000000000000100u : 0)
             | (reader.Read() ? 0b00000000000000000000000001000u : 0)
             | (reader.Read() ? 0b00000000000000000000000010000u : 0)
             | (reader.Read() ? 0b00000000000000000000000100000u : 0)
             | (reader.Read() ? 0b00000000000000000000001000000u : 0)
             | (reader.Read() ? 0b00000000000000000000010000000u : 0)
             | (reader.Read() ? 0b00000000000000000000100000000u : 0)
             | (reader.Read() ? 0b00000000000000000001000000000u : 0)
             | (reader.Read() ? 0b00000000000000000010000000000u : 0)
             | (reader.Read() ? 0b00000000000000000100000000000u : 0)
             | (reader.Read() ? 0b00000000000000001000000000000u : 0)
             | (reader.Read() ? 0b00000000000000010000000000000u : 0)
             | (reader.Read() ? 0b00000000000000100000000000000u : 0)
             | (reader.Read() ? 0b00000000000001000000000000000u : 0)
             | (reader.Read() ? 0b00000000000010000000000000000u : 0)
             | (reader.Read() ? 0b00000000000100000000000000000u : 0)
             | (reader.Read() ? 0b00000000001000000000000000000u : 0)
             | (reader.Read() ? 0b00000000010000000000000000000u : 0)
             | (reader.Read() ? 0b00000000100000000000000000000u : 0)
             | (reader.Read() ? 0b00000001000000000000000000000u : 0)
             | (reader.Read() ? 0b00000010000000000000000000000u : 0)
             | (reader.Read() ? 0b00000100000000000000000000000u : 0)
             | (reader.Read() ? 0b00001000000000000000000000000u : 0)
             | (reader.Read() ? 0b00010000000000000000000000000u : 0)
             | (reader.Read() ? 0b00100000000000000000000000000u : 0)
             | (reader.Read() ? 0b01000000000000000000000000000u : 0)
             | (reader.Read() ? 0b10000000000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 30 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt30<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b000000000000000000000000000001u) == 0b000000000000000000000000000001u);
        writer.Write((value & 0b000000000000000000000000000010u) == 0b000000000000000000000000000010u);
        writer.Write((value & 0b000000000000000000000000000100u) == 0b000000000000000000000000000100u);
        writer.Write((value & 0b000000000000000000000000001000u) == 0b000000000000000000000000001000u);
        writer.Write((value & 0b000000000000000000000000010000u) == 0b000000000000000000000000010000u);
        writer.Write((value & 0b000000000000000000000000100000u) == 0b000000000000000000000000100000u);
        writer.Write((value & 0b000000000000000000000001000000u) == 0b000000000000000000000001000000u);
        writer.Write((value & 0b000000000000000000000010000000u) == 0b000000000000000000000010000000u);
        writer.Write((value & 0b000000000000000000000100000000u) == 0b000000000000000000000100000000u);
        writer.Write((value & 0b000000000000000000001000000000u) == 0b000000000000000000001000000000u);
        writer.Write((value & 0b000000000000000000010000000000u) == 0b000000000000000000010000000000u);
        writer.Write((value & 0b000000000000000000100000000000u) == 0b000000000000000000100000000000u);
        writer.Write((value & 0b000000000000000001000000000000u) == 0b000000000000000001000000000000u);
        writer.Write((value & 0b000000000000000010000000000000u) == 0b000000000000000010000000000000u);
        writer.Write((value & 0b000000000000000100000000000000u) == 0b000000000000000100000000000000u);
        writer.Write((value & 0b000000000000001000000000000000u) == 0b000000000000001000000000000000u);
        writer.Write((value & 0b000000000000010000000000000000u) == 0b000000000000010000000000000000u);
        writer.Write((value & 0b000000000000100000000000000000u) == 0b000000000000100000000000000000u);
        writer.Write((value & 0b000000000001000000000000000000u) == 0b000000000001000000000000000000u);
        writer.Write((value & 0b000000000010000000000000000000u) == 0b000000000010000000000000000000u);
        writer.Write((value & 0b000000000100000000000000000000u) == 0b000000000100000000000000000000u);
        writer.Write((value & 0b000000001000000000000000000000u) == 0b000000001000000000000000000000u);
        writer.Write((value & 0b000000010000000000000000000000u) == 0b000000010000000000000000000000u);
        writer.Write((value & 0b000000100000000000000000000000u) == 0b000000100000000000000000000000u);
        writer.Write((value & 0b000001000000000000000000000000u) == 0b000001000000000000000000000000u);
        writer.Write((value & 0b000010000000000000000000000000u) == 0b000010000000000000000000000000u);
        writer.Write((value & 0b000100000000000000000000000000u) == 0b000100000000000000000000000000u);
        writer.Write((value & 0b001000000000000000000000000000u) == 0b001000000000000000000000000000u);
        writer.Write((value & 0b010000000000000000000000000000u) == 0b010000000000000000000000000000u);
        writer.Write((value & 0b100000000000000000000000000000u) == 0b100000000000000000000000000000u);
    }

    public static uint ReadUInt30<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b000000000000000000000000000001u : 0)
             | (reader.Read() ? 0b000000000000000000000000000010u : 0)
             | (reader.Read() ? 0b000000000000000000000000000100u : 0)
             | (reader.Read() ? 0b000000000000000000000000001000u : 0)
             | (reader.Read() ? 0b000000000000000000000000010000u : 0)
             | (reader.Read() ? 0b000000000000000000000000100000u : 0)
             | (reader.Read() ? 0b000000000000000000000001000000u : 0)
             | (reader.Read() ? 0b000000000000000000000010000000u : 0)
             | (reader.Read() ? 0b000000000000000000000100000000u : 0)
             | (reader.Read() ? 0b000000000000000000001000000000u : 0)
             | (reader.Read() ? 0b000000000000000000010000000000u : 0)
             | (reader.Read() ? 0b000000000000000000100000000000u : 0)
             | (reader.Read() ? 0b000000000000000001000000000000u : 0)
             | (reader.Read() ? 0b000000000000000010000000000000u : 0)
             | (reader.Read() ? 0b000000000000000100000000000000u : 0)
             | (reader.Read() ? 0b000000000000001000000000000000u : 0)
             | (reader.Read() ? 0b000000000000010000000000000000u : 0)
             | (reader.Read() ? 0b000000000000100000000000000000u : 0)
             | (reader.Read() ? 0b000000000001000000000000000000u : 0)
             | (reader.Read() ? 0b000000000010000000000000000000u : 0)
             | (reader.Read() ? 0b000000000100000000000000000000u : 0)
             | (reader.Read() ? 0b000000001000000000000000000000u : 0)
             | (reader.Read() ? 0b000000010000000000000000000000u : 0)
             | (reader.Read() ? 0b000000100000000000000000000000u : 0)
             | (reader.Read() ? 0b000001000000000000000000000000u : 0)
             | (reader.Read() ? 0b000010000000000000000000000000u : 0)
             | (reader.Read() ? 0b000100000000000000000000000000u : 0)
             | (reader.Read() ? 0b001000000000000000000000000000u : 0)
             | (reader.Read() ? 0b010000000000000000000000000000u : 0)
             | (reader.Read() ? 0b100000000000000000000000000000u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 31 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUInt31<TBytes>(ref this BitWriter<TBytes> writer, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write((value & 0b0000000000000000000000000000001u) == 0b0000000000000000000000000000001u);
        writer.Write((value & 0b0000000000000000000000000000010u) == 0b0000000000000000000000000000010u);
        writer.Write((value & 0b0000000000000000000000000000100u) == 0b0000000000000000000000000000100u);
        writer.Write((value & 0b0000000000000000000000000001000u) == 0b0000000000000000000000000001000u);
        writer.Write((value & 0b0000000000000000000000000010000u) == 0b0000000000000000000000000010000u);
        writer.Write((value & 0b0000000000000000000000000100000u) == 0b0000000000000000000000000100000u);
        writer.Write((value & 0b0000000000000000000000001000000u) == 0b0000000000000000000000001000000u);
        writer.Write((value & 0b0000000000000000000000010000000u) == 0b0000000000000000000000010000000u);
        writer.Write((value & 0b0000000000000000000000100000000u) == 0b0000000000000000000000100000000u);
        writer.Write((value & 0b0000000000000000000001000000000u) == 0b0000000000000000000001000000000u);
        writer.Write((value & 0b0000000000000000000010000000000u) == 0b0000000000000000000010000000000u);
        writer.Write((value & 0b0000000000000000000100000000000u) == 0b0000000000000000000100000000000u);
        writer.Write((value & 0b0000000000000000001000000000000u) == 0b0000000000000000001000000000000u);
        writer.Write((value & 0b0000000000000000010000000000000u) == 0b0000000000000000010000000000000u);
        writer.Write((value & 0b0000000000000000100000000000000u) == 0b0000000000000000100000000000000u);
        writer.Write((value & 0b0000000000000001000000000000000u) == 0b0000000000000001000000000000000u);
        writer.Write((value & 0b0000000000000010000000000000000u) == 0b0000000000000010000000000000000u);
        writer.Write((value & 0b0000000000000100000000000000000u) == 0b0000000000000100000000000000000u);
        writer.Write((value & 0b0000000000001000000000000000000u) == 0b0000000000001000000000000000000u);
        writer.Write((value & 0b0000000000010000000000000000000u) == 0b0000000000010000000000000000000u);
        writer.Write((value & 0b0000000000100000000000000000000u) == 0b0000000000100000000000000000000u);
        writer.Write((value & 0b0000000001000000000000000000000u) == 0b0000000001000000000000000000000u);
        writer.Write((value & 0b0000000010000000000000000000000u) == 0b0000000010000000000000000000000u);
        writer.Write((value & 0b0000000100000000000000000000000u) == 0b0000000100000000000000000000000u);
        writer.Write((value & 0b0000001000000000000000000000000u) == 0b0000001000000000000000000000000u);
        writer.Write((value & 0b0000010000000000000000000000000u) == 0b0000010000000000000000000000000u);
        writer.Write((value & 0b0000100000000000000000000000000u) == 0b0000100000000000000000000000000u);
        writer.Write((value & 0b0001000000000000000000000000000u) == 0b0001000000000000000000000000000u);
        writer.Write((value & 0b0010000000000000000000000000000u) == 0b0010000000000000000000000000000u);
        writer.Write((value & 0b0100000000000000000000000000000u) == 0b0100000000000000000000000000000u);
        writer.Write((value & 0b1000000000000000000000000000000u) == 0b1000000000000000000000000000000u);
    }

    public static uint ReadUInt31<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        return (reader.Read() ? 0b0000000000000000000000000000001u : 0)
             | (reader.Read() ? 0b0000000000000000000000000000010u : 0)
             | (reader.Read() ? 0b0000000000000000000000000000100u : 0)
             | (reader.Read() ? 0b0000000000000000000000000001000u : 0)
             | (reader.Read() ? 0b0000000000000000000000000010000u : 0)
             | (reader.Read() ? 0b0000000000000000000000000100000u : 0)
             | (reader.Read() ? 0b0000000000000000000000001000000u : 0)
             | (reader.Read() ? 0b0000000000000000000000010000000u : 0)
             | (reader.Read() ? 0b0000000000000000000000100000000u : 0)
             | (reader.Read() ? 0b0000000000000000000001000000000u : 0)
             | (reader.Read() ? 0b0000000000000000000010000000000u : 0)
             | (reader.Read() ? 0b0000000000000000000100000000000u : 0)
             | (reader.Read() ? 0b0000000000000000001000000000000u : 0)
             | (reader.Read() ? 0b0000000000000000010000000000000u : 0)
             | (reader.Read() ? 0b0000000000000000100000000000000u : 0)
             | (reader.Read() ? 0b0000000000000001000000000000000u : 0)
             | (reader.Read() ? 0b0000000000000010000000000000000u : 0)
             | (reader.Read() ? 0b0000000000000100000000000000000u : 0)
             | (reader.Read() ? 0b0000000000001000000000000000000u : 0)
             | (reader.Read() ? 0b0000000000010000000000000000000u : 0)
             | (reader.Read() ? 0b0000000000100000000000000000000u : 0)
             | (reader.Read() ? 0b0000000001000000000000000000000u : 0)
             | (reader.Read() ? 0b0000000010000000000000000000000u : 0)
             | (reader.Read() ? 0b0000000100000000000000000000000u : 0)
             | (reader.Read() ? 0b0000001000000000000000000000000u : 0)
             | (reader.Read() ? 0b0000010000000000000000000000000u : 0)
             | (reader.Read() ? 0b0000100000000000000000000000000u : 0)
             | (reader.Read() ? 0b0001000000000000000000000000000u : 0)
             | (reader.Read() ? 0b0010000000000000000000000000000u : 0)
             | (reader.Read() ? 0b0100000000000000000000000000000u : 0)
             | (reader.Read() ? 0b1000000000000000000000000000000u : 0)
             ;
    }

    /// <summary>
    /// Write an int with a specific number of bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="bits"></param>
    public static void WriteSmallUInt<TBytes>(ref this BitWriter<TBytes> writer, uint value, uint bits)
        where TBytes : struct, IByteWriter
    {
        for (var i = 0; i < bits; i++)
        {
            writer.Write((value & 0b1) == 1);
            value >>= 1;
        }
    }

    public static uint ReadSmallUInt<TBytes>(ref this BitReader<TBytes> reader, uint bits)
        where TBytes : struct, IByteReader
    {
        var value = 0u;

        for (var i = 0; i < bits; i++)
            value |= reader.Read() ? 1u << i : 0u;

        return value;
    }

    /// <summary>
    /// Write a number as N zeroes, followed by a one
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    public static void WriteUnaryInt<TBytes>(ref this BitWriter<TBytes> writer, byte value)
        where TBytes : struct, IByteWriter
    {
        for (var i = 0; i < value; i++)
            writer.Write(false);
        writer.Write(true);
    }

    public static byte ReadUnaryInt<TBytes>(ref this BitReader<TBytes> reader)
        where TBytes : struct, IByteReader
    {
        var count = 0;
        while (!reader.Read())
            count++;
        return (byte)count;
    }
}

