using HandySerialization.Extensions.Bits;
using HandySerialization.Wrappers;

namespace HandySerialization.Extensions;

public static class DeltaSequences
{
    public static void WriteDeltaCompressedSequence<TByteWriter>(this TByteWriter writer, int predictorOrder, ReadOnlySpan<double> values, int offset = 0, int stride = 1)
        where TByteWriter : struct, IByteWriter
    {
        // Write exponents with sign bit
        {
            var bitWriter = new BitWriter<TByteWriter>(writer);
            {
                uint prevExponent = 0;
                for (var i = offset; i < values.Length; i += stride)
                {
                    var value = values[i];
                    prevExponent = WriteSignedDoubleExponent(ref bitWriter, value, prevExponent);
                }
            }
            bitWriter.Flush();
        }

        // Write out mantissas
        Span<long> mantissaPredictors = stackalloc long[predictorOrder];
        for (var i = offset; i < values.Length; i += stride)
        {
            var value = values[i];
            WriteDoubleMantissa(ref writer, value, mantissaPredictors);
        }

        static uint WriteSignedDoubleExponent(ref BitWriter<TByteWriter> writer, double x, uint prev)
        {
            var exponent = BitTwiddle.Exponent(x);

            // Mix in the sign bit
            exponent <<= 1;
            exponent |= x < 0 ? 1u : 0u;

            // Get the bits changed from the previous value
            var value = exponent ^ prev;

            // Write it out
            writer.WriteEliasDeltaGamma32(value);

            return exponent;
        }

        static void WriteDoubleMantissa(ref TByteWriter writer, double x, Span<long> predictors)
        {
            var mantissa = BitTwiddle.Mantissa(x);

            var state = (long)mantissa;
            for (var i = 0; i < predictors.Length; i++)
            {
                var a = state;
                var b = predictors[i];
                predictors[i] = state;

                state = a - b;
            }

            var zigzag = state.ZigZag();
            writer.WriteVariableUInt64(zigzag);
        }
    }

    public static void ReadDeltaCompressedSequence<TByteReader>(this TByteReader reader, int predictorOrder, Span<double> values, int offset = 0, int stride = 1)
        where TByteReader : struct, IByteReader
    {
        unsafe
        {
            fixed (double* valuesPtr = values)
            {
                var valuesUlongPtr = (ulong*)valuesPtr;

                // Read exponent+sign, store it in slot (reinterpreted as ulong)
                {
                    var bitReader = new BitReader<TByteReader>(reader);
                    uint prevExponent = 0;
                    for (var i = offset; i < values.Length; i += stride)
                    {
                        prevExponent = ReadSignedDoubleExponent(ref bitReader, prevExponent);
                        valuesUlongPtr[i] = prevExponent;
                    }
                }

                // Read mantissas and combine with exponents into final value
                Span<long> mantissaPredictors = stackalloc long[predictorOrder];
                for (var i = offset; i < values.Length; i += stride)
                {
                    var mantissa = ReadDoubleMantissa(ref reader, mantissaPredictors);
                    
                    // Grab decoded exponent and pull out the sign bit
                    var exponent = valuesUlongPtr[i];
                    var sign = (exponent & 1) == 1;
                    exponent >>= 1;

                    // Create the actual value
                    var value = BitConverter.Int64BitsToDouble(unchecked((long)((exponent << 52) | mantissa)));
                    if (sign)
                        value = -value;
                    valuesPtr[i] = value;
                }
            }
        }

        static uint ReadSignedDoubleExponent(ref BitReader<TByteReader> reader, uint prev)
        {
            var value = reader.ReadEliasDeltaGamma32();
            var exponent = value ^ prev;
            return exponent;
        }

        static ulong ReadDoubleMantissa(ref TByteReader reader, Span<long> predictors)
        {
            var zigzag = reader.ReadVariableUInt64();
            var state = zigzag.DecodeZigZag();

            // Reverse the prediction chain
            for (var i = predictors.Length - 1; i >= 0; i--)
            {
                var b = predictors[i];
                predictors[i] = state + b;
                state = predictors[i];
            }

            var mantissa = (ulong)state;
            return mantissa;
        }
    }
}