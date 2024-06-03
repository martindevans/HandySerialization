using System.Runtime.InteropServices;

namespace HandySerialization.Unions;

[StructLayout(LayoutKind.Explicit)]
internal struct Union16
{
    [FieldOffset(0)]
    public ushort UShort;

    [FieldOffset(0)]
    public short Short;

    [FieldOffset(0)]
    public byte Byte0;

    [FieldOffset(1)]
    public byte Byte1;
}