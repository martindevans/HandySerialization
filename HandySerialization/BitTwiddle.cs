
namespace HandySerialization;

internal static class BitTwiddle
{
    public static uint LeadingZeros(uint x)
    {
#if NET5_0_OR_GREATER
        return (uint)System.Numerics.BitOperations.LeadingZeroCount(x);
#else
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
#endif
    }
}