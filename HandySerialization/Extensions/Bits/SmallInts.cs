
using HandySerialization.Wrappers;

namespace HandySerialization.Extensions.Bits;

public static class SmallIntExtensions
{
	/// <summary>
    /// Write an int with 2 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt2<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 2);
    }

    public static uint ReadUInt2<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10u : 0)
             | (reader.Read(ref bytes) ? 0b01u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 3 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt3<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 3);
    }

    public static uint ReadUInt3<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100u : 0)
             | (reader.Read(ref bytes) ? 0b010u : 0)
             | (reader.Read(ref bytes) ? 0b001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 4 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt4<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 4);
    }

    public static uint ReadUInt4<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000u : 0)
             | (reader.Read(ref bytes) ? 0b0100u : 0)
             | (reader.Read(ref bytes) ? 0b0010u : 0)
             | (reader.Read(ref bytes) ? 0b0001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 5 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt5<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 5);
    }

    public static uint ReadUInt5<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000u : 0)
             | (reader.Read(ref bytes) ? 0b01000u : 0)
             | (reader.Read(ref bytes) ? 0b00100u : 0)
             | (reader.Read(ref bytes) ? 0b00010u : 0)
             | (reader.Read(ref bytes) ? 0b00001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 6 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt6<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 6);
    }

    public static uint ReadUInt6<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000u : 0)
             | (reader.Read(ref bytes) ? 0b010000u : 0)
             | (reader.Read(ref bytes) ? 0b001000u : 0)
             | (reader.Read(ref bytes) ? 0b000100u : 0)
             | (reader.Read(ref bytes) ? 0b000010u : 0)
             | (reader.Read(ref bytes) ? 0b000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 7 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt7<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 7);
    }

    public static uint ReadUInt7<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 8 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt8<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 8);
    }

    public static uint ReadUInt8<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 9 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt9<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 9);
    }

    public static uint ReadUInt9<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 10 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt10<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 10);
    }

    public static uint ReadUInt10<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 11 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt11<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 11);
    }

    public static uint ReadUInt11<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 12 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt12<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 12);
    }

    public static uint ReadUInt12<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 13 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt13<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 13);
    }

    public static uint ReadUInt13<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 14 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt14<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 14);
    }

    public static uint ReadUInt14<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 15 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt15<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 15);
    }

    public static uint ReadUInt15<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 16 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt16<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 16);
    }

    public static uint ReadUInt16<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 17 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt17<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 17);
    }

    public static uint ReadUInt17<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 18 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt18<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 18);
    }

    public static uint ReadUInt18<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 19 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt19<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 19);
    }

    public static uint ReadUInt19<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 20 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt20<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 20);
    }

    public static uint ReadUInt20<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 21 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt21<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 21);
    }

    public static uint ReadUInt21<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 22 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt22<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 22);
    }

    public static uint ReadUInt22<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 23 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt23<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 23);
    }

    public static uint ReadUInt23<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 24 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt24<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 24);
    }

    public static uint ReadUInt24<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 25 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt25<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 25);
    }

    public static uint ReadUInt25<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 26 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt26<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 26);
    }

    public static uint ReadUInt26<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 27 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt27<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 27);
    }

    public static uint ReadUInt27<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 28 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt28<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 28);
    }

    public static uint ReadUInt28<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 29 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt29<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 29);
    }

    public static uint ReadUInt29<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 30 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt30<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 30);
    }

    public static uint ReadUInt30<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 31 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt31<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 31);
    }

    public static uint ReadUInt31<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 32 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt32<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 32);
    }

    public static uint ReadUInt32<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010u : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001u : 0)
             ;
    }

	/// <summary>
    /// Write an int with 33 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt33<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 33);
    }

    public static ulong ReadUInt33<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 34 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt34<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 34);
    }

    public static ulong ReadUInt34<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 35 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt35<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 35);
    }

    public static ulong ReadUInt35<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 36 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt36<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 36);
    }

    public static ulong ReadUInt36<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 37 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt37<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 37);
    }

    public static ulong ReadUInt37<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 38 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt38<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 38);
    }

    public static ulong ReadUInt38<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 39 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt39<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 39);
    }

    public static ulong ReadUInt39<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 40 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt40<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 40);
    }

    public static ulong ReadUInt40<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 41 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt41<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 41);
    }

    public static ulong ReadUInt41<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 42 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt42<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 42);
    }

    public static ulong ReadUInt42<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 43 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt43<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 43);
    }

    public static ulong ReadUInt43<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 44 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt44<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 44);
    }

    public static ulong ReadUInt44<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 45 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt45<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 45);
    }

    public static ulong ReadUInt45<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 46 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt46<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 46);
    }

    public static ulong ReadUInt46<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 47 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt47<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 47);
    }

    public static ulong ReadUInt47<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 48 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt48<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 48);
    }

    public static ulong ReadUInt48<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 49 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt49<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 49);
    }

    public static ulong ReadUInt49<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 50 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt50<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 50);
    }

    public static ulong ReadUInt50<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 51 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt51<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 51);
    }

    public static ulong ReadUInt51<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 52 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt52<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 52);
    }

    public static ulong ReadUInt52<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 53 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt53<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 53);
    }

    public static ulong ReadUInt53<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 54 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt54<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 54);
    }

    public static ulong ReadUInt54<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 55 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt55<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 55);
    }

    public static ulong ReadUInt55<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 56 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt56<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 56);
    }

    public static ulong ReadUInt56<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 57 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt57<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 57);
    }

    public static ulong ReadUInt57<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 58 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt58<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 58);
    }

    public static ulong ReadUInt58<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 59 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt59<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 59);
    }

    public static ulong ReadUInt59<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 60 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt60<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 60);
    }

    public static ulong ReadUInt60<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 61 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt61<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 61);
    }

    public static ulong ReadUInt61<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b1000000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0100000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0010000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0001000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000100000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000010000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000001000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b0000000000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 62 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt62<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 62);
    }

    public static ulong ReadUInt62<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b10000000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b01000000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00100000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00010000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00001000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000100000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000010000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000001000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b00000000000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

	/// <summary>
    /// Write an int with 63 bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUInt63<TBytes>(ref this BitWriter writer, ref TBytes bytes, ulong value)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, 63);
    }

    public static ulong ReadUInt63<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        return (reader.Read(ref bytes) ? 0b100000000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b010000000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b001000000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000100000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000010000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000001000000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000100000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000010000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000001000000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000100000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000010000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000001000000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000100000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000010000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000001000000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000100000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000010000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000001000000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000100000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000010000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000001000000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000100000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000010000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000001000000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000100000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000010000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000001000000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000100000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000010000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000001000000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000100000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000010000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000001000000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000100000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000010000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000001000000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000100000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000010000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000001000000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000100000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000010000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000001000000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000100000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000010000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000001000000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000100000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000010000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000001000000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000100000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000010000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000001000000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000100000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000010000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000001000000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000100000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000010000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000001000000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000100000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000010000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000001000ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000000100ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000000010ul : 0)
             | (reader.Read(ref bytes) ? 0b000000000000000000000000000000000000000000000000000000000000001ul : 0)
             ;
    }

    /// <summary>
    /// Write an int with a specific number of bits
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    /// <param name="bits"></param>
    public static void WriteSmallUInt<TBytes>(ref this BitWriter writer, ref TBytes bytes, uint value, uint bits)
        where TBytes : struct, IByteWriter
    {
        writer.Write(ref bytes, value, bits);
    }

    public static uint ReadSmallUInt<TBytes>(ref this BitReader reader, ref TBytes bytes, uint bits)
        where TBytes : struct, IByteReader
    {
        var value = 0u;

        for (var i = 0u; i < bits; i++)
            value |= reader.Read(ref bytes) ? 1u << (int)(bits - i - 1u) : 0u;

        return value;
    }

    /// <summary>
    /// Write a number as N zeroes, followed by a one
    /// </summary>
    /// <typeparam name="TBytes"></typeparam>
    /// <param name="writer"></param>
    /// <param name="bytes"></param>
    /// <param name="value"></param>
    public static void WriteUnaryInt<TBytes>(ref this BitWriter writer, ref TBytes bytes, byte value)
        where TBytes : struct, IByteWriter
    {
        for (var i = 0; i < value; i++)
            writer.Write(ref bytes, false);
        writer.Write(ref bytes, true);
    }

    public static byte ReadUnaryInt<TBytes>(ref this BitReader reader, ref TBytes bytes)
        where TBytes : struct, IByteReader
    {
        var count = 0;
        while (!reader.Read(ref bytes))
            count++;
        return (byte)count;
    }
}

