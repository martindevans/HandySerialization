using HandySerialization.Extensions;
using System.Runtime.InteropServices;

namespace HandySerialization.Unions;

[StructLayout(LayoutKind.Explicit)]
internal struct Union32
{
    [FieldOffset(0)] public uint RawUint;
    [FieldOffset(0)] public int  RawInt;

    [FieldOffset(0)] public byte RawByte0;
    [FieldOffset(1)] public byte RawByte1;
    [FieldOffset(2)] public byte RawByte2;
    [FieldOffset(3)] public byte RawByte3;

    public void Write<T>(ref T writer)
        where T : struct, IByteWriter
    {
        if (BitConverter.IsLittleEndian)
        {
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
        }
    }

    public void Read<T>(ref T reader)
        where T : struct, IByteReader
    {
        if (BitConverter.IsLittleEndian)
        {
            Span<byte> bytes = stackalloc byte[4];
            reader.ReadBytes(bytes);

            RawByte3 = bytes[0];
            RawByte2 = bytes[1];
            RawByte1 = bytes[2];
            RawByte0 = bytes[3];
        }
        else
        {
            Span<byte> bytes = stackalloc byte[4];
            reader.ReadBytes(bytes);

            RawByte0 = bytes[0];
            RawByte1 = bytes[1];
            RawByte2 = bytes[2];
            RawByte3 = bytes[3];
        }
    }
}