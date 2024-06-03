using System.Runtime.InteropServices;

namespace HandySerialization.Unions;

[StructLayout(LayoutKind.Explicit)]
internal struct Union32
{
    [FieldOffset(0)]
    public uint UInt;

    [FieldOffset(0)]
    public int Int;

    [FieldOffset(0)]
    public float Float;

    [FieldOffset(0)]
    public byte Byte0;

    [FieldOffset(1)]
    public byte Byte1;

    [FieldOffset(2)]
    public byte Byte2;

    [FieldOffset(3)]
    public byte Byte3;
}