
namespace HandySerialization;

internal static class BitTwiddle
{
    public static uint LeadingZeros(uint x)
    {
//#if NET5_0_OR_GREATER
//        return (uint)BitOperations.LeadingZeroCount(x);
//#endif

        const uint numIntBits = sizeof(uint) * 8; //compile time constant
        
        //do the smearing
        x |= x >> 1;
        x |= x >> 2;
        x |= x >> 4;
        x |= x >> 8;
        x |= x >> 16;

        //count the ones
        x -= x >> 1 & 0x55555555;
        x = (x >> 2 & 0x33333333) + (x & 0x33333333);
        x = (x >> 4) + x & 0x0f0f0f0f;
        x += x >> 8;
        x += x >> 16;
        return numIntBits - (x & 0x0000003F); //subtract # of 1s from 32
    }

    public static byte BitsNeeded32(uint value)
    {
        return (byte)(32 - LeadingZeros(value));
    }

    public static uint Exponent(double value)
    {
        var bits = BitConverter.DoubleToInt64Bits(value);
        var exponent = (uint)((bits >> 52) & 0b_111_11111111);
        return exponent;
    }

    public static ulong Mantissa(double value)
    {
        var bits = BitConverter.DoubleToInt64Bits(value);
        var mantissa = (ulong)(bits & 0x_F_FFFF_FFFF_FFFF);
        return mantissa;
    }

    public static uint Mask(int bits)
    {
        return (1u << bits) - 1u;
    }
}