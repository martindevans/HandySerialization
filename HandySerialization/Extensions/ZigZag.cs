namespace HandySerialization.Extensions;

public static class ZigZagExtensions
{
    /// <summary>
    /// Interleave the values of a int16 so that small magnitude numbers (negative or positive) become small magnitude numbers (always positive).
    /// i.e. Encoded(0,1,2,3,4,5) -> Decoded(0,-1,1,-2,2,-3)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static ushort ZigZag(this short n)
    {
        return (ushort)((n << 1) ^ (n >> 15));
    }

    /// <summary>
    /// Undo 16 bit ZigZag encoding
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static short DecodeZigZag(this ushort n)
    {
        return (short)((n >> 1) ^ -(n & 1));
    }

    /// <summary>
    /// Interleave the values of a int32 so that small magnitude numbers (negative or positive) become small magnitude numbers (always positive).
    /// i.e. Encoded(0,1,2,3,4,5) -> Decoded(0,-1,1,-2,2,-3)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static uint ZigZag(this int n)
    {
        return (uint)((n << 1) ^ (n >> 31));
    }

    /// <summary>
    /// Undo 32 bit ZigZag encoding
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int DecodeZigZag(this uint n)
    {
        return (int)(n >> 1) ^ -(int)(n & 1);
    }

    /// <summary>
    /// Interleave the values of a int64 so that small magnitude numbers (negative or positive) become small magnitude numbers (always positive).
    /// i.e. Encoded(0,1,2,3,4,5) -> Decoded(0,-1,1,-2,2,-3)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static ulong ZigZag(this long n)
    {
        return (ulong)((n << 1) ^ (n >> 63));
    }

    /// <summary>
    /// Undo 64 bit ZigZag encoding
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static long DecodeZigZag(this ulong n)
    {
        return (long)((n >> 1) - (n & 1) * n);
    }

    /// <summary>
    /// Interleave the values of a uint16 so that values are encoded by their distance from 32767. As if 32767 is interpreted as 0 and this is normal ZigZag encoding
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static ushort UnsignedZigZagInterleave(this ushort s)
    {
        if (s < 32768)
            return (ushort)(s * 2);
        
        return (ushort)((s - 32767) * 2 - 1);
    }

    public static ushort DecodeUnsignedZigZagInterleave(this ushort s)
    {
        if (s % 2 == 1)
            return (ushort)((s + 1) / 2 + 32767);
        
        return (ushort)(s / 2);
    }
}