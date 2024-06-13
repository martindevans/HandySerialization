
namespace HandySerialization.Extensions;


public static class Sequences
{
    /// <summary>
    /// Write a sequence of floats with a fixed length (length must be known by reader) using variable length encoding. For
    /// totally uncorrelated data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="floats"></param>
    public static void WriteCompressedSequenceFloat32<T>(this ref T writer, ReadOnlySpan<float> floats)
        where T : struct, IByteWriter
    {
        int prev = 0;
        for (var i = 0; i < floats.Length; i++)
        {
            int fint = BitConverter.SingleToInt32Bits(floats[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    public static void ReadCompressedSequenceFloat32<T>(this ref T reader, Span<float> output)
        where T : struct, IByteReader
    {
        var r = new SequenceFloat32Reader<T>(output.Length);
        r.Read(ref reader, output);
    }

    /// <summary>
    /// Write a sequence of floats, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="floats"></param>
    public static void WriteCompressedLengthPrefixedSequenceFloat32<T>(this ref T writer, ReadOnlySpan<float> floats)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)floats.Length);
        writer.WriteCompressedSequenceFloat32(floats);
    }

    public static SequenceFloat32Reader<T> ReadCompressedLengthPrefixedSequenceFloat32<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new SequenceFloat32Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceFloat32Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private int _prev = 0;

        internal SequenceFloat32Reader(int count)
        {
            Remaining = count;
        }

        /// <summary>
        /// Read as many values as possible into the given span. Span must be less than or equal to Remaining values count
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dest"></param>
        public void Read(ref T reader, Span<float> dest)
        {
            if (dest.Length > Remaining)
                throw new InvalidOperationException($"Cannot read {dest.Length} values, only {Remaining} values are left to read");

            Remaining -= dest.Length;
            for (var i = 0; i < dest.Length; i++)
            {
                var xor = (int)reader.ReadVariableInt64();

                var fint = xor ^ _prev;
                _prev = fint;

                dest[i] = BitConverter.Int32BitsToSingle(fint);
            }
        }
    }

    /// <summary>
    /// Write a sequence of doubles with a fixed length (length must be known by reader) using variable length encoding. For
    /// totally uncorrelated data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="doubles"></param>
    public static void WriteCompressedSequenceFloat64<T>(this ref T writer, ReadOnlySpan<double> doubles)
        where T : struct, IByteWriter
    {
        long prev = 0;
        for (var i = 0; i < doubles.Length; i++)
        {
            long fint = BitConverter.DoubleToInt64Bits(doubles[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    public static void ReadCompressedSequenceFloat64<T>(this ref T reader, Span<double> output)
        where T : struct, IByteReader
    {
        var r = new SequenceFloat64Reader<T>(output.Length);
        r.Read(ref reader, output);
    }

    /// <summary>
    /// Write a sequence of doubles, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="doubles"></param>
    public static void WriteCompressedLengthPrefixedSequenceFloat64<T>(this ref T writer, ReadOnlySpan<double> doubles)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)doubles.Length);
        writer.WriteCompressedSequenceFloat64(doubles);
    }

    public static SequenceFloat64Reader<T> ReadCompressedLengthPrefixedSequenceFloat64<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new SequenceFloat64Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceFloat64Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private long _prev = 0;

        internal SequenceFloat64Reader(int count)
        {
            Remaining = count;
        }

        /// <summary>
        /// Read as many values as possible into the given span. Span must be less than or equal to Remaining values count
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dest"></param>
        public void Read(ref T reader, Span<double> dest)
        {
            if (dest.Length > Remaining)
                throw new InvalidOperationException($"Cannot read {dest.Length} values, only {Remaining} values are left to read");

            Remaining -= dest.Length;
            for (var i = 0; i < dest.Length; i++)
            {
                var xor = (long)reader.ReadVariableInt64();

                var fint = xor ^ _prev;
                _prev = fint;

                dest[i] = BitConverter.Int64BitsToDouble(fint);
            }
        }
    }

    /// <summary>
    /// Write a sequence of ints with a fixed length (length must be known by reader) using variable length encoding. For
    /// totally uncorrelated data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="ints"></param>
    public static void WriteCompressedSequenceInt32<T>(this ref T writer, ReadOnlySpan<int> ints)
        where T : struct, IByteWriter
    {
        int prev = 0;
        for (var i = 0; i < ints.Length; i++)
        {
            int fint = (ints[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    public static void ReadCompressedSequenceInt32<T>(this ref T reader, Span<int> output)
        where T : struct, IByteReader
    {
        var r = new SequenceInt32Reader<T>(output.Length);
        r.Read(ref reader, output);
    }

    /// <summary>
    /// Write a sequence of ints, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="ints"></param>
    public static void WriteCompressedLengthPrefixedSequenceInt32<T>(this ref T writer, ReadOnlySpan<int> ints)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)ints.Length);
        writer.WriteCompressedSequenceInt32(ints);
    }

    public static SequenceInt32Reader<T> ReadCompressedLengthPrefixedSequenceInt32<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new SequenceInt32Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceInt32Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private int _prev = 0;

        internal SequenceInt32Reader(int count)
        {
            Remaining = count;
        }

        /// <summary>
        /// Read as many values as possible into the given span. Span must be less than or equal to Remaining values count
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dest"></param>
        public void Read(ref T reader, Span<int> dest)
        {
            if (dest.Length > Remaining)
                throw new InvalidOperationException($"Cannot read {dest.Length} values, only {Remaining} values are left to read");

            Remaining -= dest.Length;
            for (var i = 0; i < dest.Length; i++)
            {
                var xor = (int)reader.ReadVariableInt64();

                var fint = xor ^ _prev;
                _prev = fint;

                dest[i] = (fint);
            }
        }
    }

    /// <summary>
    /// Write a sequence of uints with a fixed length (length must be known by reader) using variable length encoding. For
    /// totally uncorrelated data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="uints"></param>
    public static void WriteCompressedSequenceUInt32<T>(this ref T writer, ReadOnlySpan<uint> uints)
        where T : struct, IByteWriter
    {
        uint prev = 0;
        for (var i = 0; i < uints.Length; i++)
        {
            uint fint = (uints[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableUInt64(xor);
        }
    }

    public static void ReadCompressedSequenceUInt32<T>(this ref T reader, Span<uint> output)
        where T : struct, IByteReader
    {
        var r = new SequenceUInt32Reader<T>(output.Length);
        r.Read(ref reader, output);
    }

    /// <summary>
    /// Write a sequence of uints, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="uints"></param>
    public static void WriteCompressedLengthPrefixedSequenceUInt32<T>(this ref T writer, ReadOnlySpan<uint> uints)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)uints.Length);
        writer.WriteCompressedSequenceUInt32(uints);
    }

    public static SequenceUInt32Reader<T> ReadCompressedLengthPrefixedSequenceUInt32<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new SequenceUInt32Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceUInt32Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private uint _prev = 0;

        internal SequenceUInt32Reader(int count)
        {
            Remaining = count;
        }

        /// <summary>
        /// Read as many values as possible into the given span. Span must be less than or equal to Remaining values count
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dest"></param>
        public void Read(ref T reader, Span<uint> dest)
        {
            if (dest.Length > Remaining)
                throw new InvalidOperationException($"Cannot read {dest.Length} values, only {Remaining} values are left to read");

            Remaining -= dest.Length;
            for (var i = 0; i < dest.Length; i++)
            {
                var xor = (uint)reader.ReadVariableUInt64();

                var fint = xor ^ _prev;
                _prev = fint;

                dest[i] = (fint);
            }
        }
    }

    /// <summary>
    /// Write a sequence of longs with a fixed length (length must be known by reader) using variable length encoding. For
    /// totally uncorrelated data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="longs"></param>
    public static void WriteCompressedSequenceInt64<T>(this ref T writer, ReadOnlySpan<long> longs)
        where T : struct, IByteWriter
    {
        long prev = 0;
        for (var i = 0; i < longs.Length; i++)
        {
            long fint = (longs[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    public static void ReadCompressedSequenceInt64<T>(this ref T reader, Span<long> output)
        where T : struct, IByteReader
    {
        var r = new SequenceInt64Reader<T>(output.Length);
        r.Read(ref reader, output);
    }

    /// <summary>
    /// Write a sequence of longs, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="longs"></param>
    public static void WriteCompressedLengthPrefixedSequenceInt64<T>(this ref T writer, ReadOnlySpan<long> longs)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)longs.Length);
        writer.WriteCompressedSequenceInt64(longs);
    }

    public static SequenceInt64Reader<T> ReadCompressedLengthPrefixedSequenceInt64<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new SequenceInt64Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceInt64Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private long _prev = 0;

        internal SequenceInt64Reader(int count)
        {
            Remaining = count;
        }

        /// <summary>
        /// Read as many values as possible into the given span. Span must be less than or equal to Remaining values count
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dest"></param>
        public void Read(ref T reader, Span<long> dest)
        {
            if (dest.Length > Remaining)
                throw new InvalidOperationException($"Cannot read {dest.Length} values, only {Remaining} values are left to read");

            Remaining -= dest.Length;
            for (var i = 0; i < dest.Length; i++)
            {
                var xor = (long)reader.ReadVariableInt64();

                var fint = xor ^ _prev;
                _prev = fint;

                dest[i] = (fint);
            }
        }
    }

    /// <summary>
    /// Write a sequence of ulongs with a fixed length (length must be known by reader) using variable length encoding. For
    /// totally uncorrelated data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="ulongs"></param>
    public static void WriteCompressedSequenceUInt64<T>(this ref T writer, ReadOnlySpan<ulong> ulongs)
        where T : struct, IByteWriter
    {
        ulong prev = 0;
        for (var i = 0; i < ulongs.Length; i++)
        {
            ulong fint = (ulongs[i]);
            var xor = fint ^ prev;
            prev = fint;
            writer.WriteVariableUInt64(xor);
        }
    }

    public static void ReadCompressedSequenceUInt64<T>(this ref T reader, Span<ulong> output)
        where T : struct, IByteReader
    {
        var r = new SequenceUInt64Reader<T>(output.Length);
        r.Read(ref reader, output);
    }

    /// <summary>
    /// Write a sequence of ulongs, with variable length encoding. For totally uncorrelated data this will make
    /// the output data about 1.2x <b>larger</b>! However if the data are correlated (e.g. with ~1,000,000 of each other)
    /// then this will save be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="ulongs"></param>
    public static void WriteCompressedLengthPrefixedSequenceUInt64<T>(this ref T writer, ReadOnlySpan<ulong> ulongs)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)ulongs.Length);
        writer.WriteCompressedSequenceUInt64(ulongs);
    }

    public static SequenceUInt64Reader<T> ReadCompressedLengthPrefixedSequenceUInt64<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new SequenceUInt64Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceUInt64Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private ulong _prev = 0;

        internal SequenceUInt64Reader(int count)
        {
            Remaining = count;
        }

        /// <summary>
        /// Read as many values as possible into the given span. Span must be less than or equal to Remaining values count
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dest"></param>
        public void Read(ref T reader, Span<ulong> dest)
        {
            if (dest.Length > Remaining)
                throw new InvalidOperationException($"Cannot read {dest.Length} values, only {Remaining} values are left to read");

            Remaining -= dest.Length;
            for (var i = 0; i < dest.Length; i++)
            {
                var xor = (ulong)reader.ReadVariableUInt64();

                var fint = xor ^ _prev;
                _prev = fint;

                dest[i] = (fint);
            }
        }
    }

}

