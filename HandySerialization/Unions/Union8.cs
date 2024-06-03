using System.Runtime.InteropServices;

namespace HandySerialization.Unions;

[StructLayout(LayoutKind.Explicit)]
internal struct Union8
{
    [FieldOffset(0)]
    public sbyte SByte;

    [FieldOffset(0)]
    public byte Byte;
}