using HandySerialization.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace HandySerialization.Unions;

[StructLayout(LayoutKind.Explicit)]
internal struct Union16
{
    [FieldOffset(0)] public ushort RawUshort;
    [FieldOffset(0)] public short  RawShort;
    [FieldOffset(0)] public char   RawChar;

    [FieldOffset(0)] public byte RawByte0;
    [FieldOffset(1)] public byte RawByte1;

    [ExcludeFromCodeCoverage]
    public void Write<T>(ref T writer)
        where T : struct, IByteWriter
    {
        if (BitConverter.IsLittleEndian)
        {
            writer.Write(RawByte1);
            writer.Write(RawByte0);
        }
        else
        {
            writer.Write(RawByte0);
            writer.Write(RawByte1);
        }
    }

    [ExcludeFromCodeCoverage]
    public void Read<T>(ref T reader)
        where T : struct, IByteReader
    {
        if (BitConverter.IsLittleEndian)
        {
            Span<byte> bytes = stackalloc byte[2];
            reader.ReadBytes(bytes);

            RawByte1 = bytes[0];
            RawByte0 = bytes[1];
        }
        else
        {
            Span<byte> bytes = stackalloc byte[2];
            reader.ReadBytes(bytes);

            RawByte0 = bytes[0];
            RawByte1 = bytes[1];
        }
    }
}