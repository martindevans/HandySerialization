using System.Diagnostics.CodeAnalysis;
using HandySerialization.Extensions;
using System.Runtime.InteropServices;

namespace HandySerialization.Unions;

[StructLayout(LayoutKind.Explicit)]
internal struct Union64
{
    [FieldOffset(0)] public ulong RawUlong;
    [FieldOffset(0)] public long  RawLong;

    [FieldOffset(0)] public byte RawByte0;
    [FieldOffset(1)] public byte RawByte1;
    [FieldOffset(2)] public byte RawByte2;
    [FieldOffset(3)] public byte RawByte3;
    [FieldOffset(4)] public byte RawByte4;
    [FieldOffset(5)] public byte RawByte5;
    [FieldOffset(6)] public byte RawByte6;
    [FieldOffset(7)] public byte RawByte7;

    [ExcludeFromCodeCoverage]
    public void Write<T>(ref T writer)
        where T : struct, IByteWriter
    {
        if (BitConverter.IsLittleEndian)
        {
            writer.Write(RawByte7);
            writer.Write(RawByte6);
            writer.Write(RawByte5);
            writer.Write(RawByte4);
            writer.Write(RawByte3);
            writer.Write(RawByte2);
            writer.Write(RawByte1);
            writer.Write(RawByte0);
        }
        else
        {
            writer.Write(RawByte0);
            writer.Write(RawByte1);
            writer.Write(RawByte2);
            writer.Write(RawByte3);
            writer.Write(RawByte4);
            writer.Write(RawByte5);
            writer.Write(RawByte6);
            writer.Write(RawByte7);
        }
    }

    [ExcludeFromCodeCoverage]
    public void Read<T>(ref T reader)
        where T : struct, IByteReader
    {
        if (BitConverter.IsLittleEndian)
        {
            Span<byte> bytes = stackalloc byte[8];
            reader.ReadBytes(bytes);

            RawByte7 = bytes[0];
            RawByte6 = bytes[1];
            RawByte5 = bytes[2];
            RawByte4 = bytes[3];
            RawByte3 = bytes[4];
            RawByte2 = bytes[5];
            RawByte1 = bytes[6];
            RawByte0 = bytes[7];
        }
        else
        {
            Span<byte> bytes = stackalloc byte[8];
            reader.ReadBytes(bytes);

            RawByte0 = bytes[0];
            RawByte1 = bytes[1];
            RawByte2 = bytes[2];
            RawByte3 = bytes[3];
            RawByte4 = bytes[4];
            RawByte5 = bytes[5];
            RawByte6 = bytes[6];
            RawByte7 = bytes[7];
        }
    }
}