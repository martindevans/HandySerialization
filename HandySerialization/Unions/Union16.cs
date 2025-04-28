using System.Runtime.InteropServices;

namespace HandySerialization.Unions;

[StructLayout(LayoutKind.Explicit)]
internal struct Union16
{
    [FieldOffset(0)] public ushort RawUshort;
    [FieldOffset(0)] public short  RawShort;

    [FieldOffset(0)] public byte RawByte0;
    [FieldOffset(1)] public byte RawByte1;

    public byte NetworkByte0
    {
        get => BitConverter.IsLittleEndian ? RawByte1 : RawByte0;
        set
        {
            if (BitConverter.IsLittleEndian)
                RawByte1 = value;
            else
                RawByte0 = value;
        }
    }

    public byte NetworkByte1
    {
        get => BitConverter.IsLittleEndian ? RawByte0 : RawByte1;
        set
        {
            if (BitConverter.IsLittleEndian)
                RawByte0 = value;
            else
                RawByte1 = value;
        }
    }
}