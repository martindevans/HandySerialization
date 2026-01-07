
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
    public static void WriteCompressedSequenceFloat32<T>(ref this T writer, ReadOnlySpan<float> floats)
        where T : struct, IByteWriter
    {
        var seqWriter = new SequenceFloat32WriterState<T>();

        for (var i = 0; i < floats.Length; i++)
            seqWriter.Write(ref writer, floats[i]);
    }

    /// <summary>
    /// Create a writer for a sequence of floats using variable length encoding. For totally uncorrelated
    /// data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceFloat32WriterState<T>
        where T : struct, IByteWriter
    {
        private int _prev;

        public void Write(ref T writer, float value)
        {
            var fint = BitConverter.SingleToInt32Bits(value);
            var xor = fint ^ _prev;
            _prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    /// <summary>
    /// Create a reader for a sequence of floats using variable length encoding. This reader
    /// does not validate the length of the sequence!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceFloat32ReaderState<T>
        where T : struct, IByteReader
    {
        private int _prev;

        public float Read(ref T reader)
        {
            var xor = (int)reader.ReadVariableInt64();

            var fint = xor ^ _prev;
            _prev = fint;

            return BitConverter.Int32BitsToSingle(fint);
        }
    }

    public static void ReadCompressedSequenceFloat32<T>(ref this T reader, Span<float> output)
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
    public static void WriteCompressedLengthPrefixedSequenceFloat32<T>(ref this T writer, ReadOnlySpan<float> floats)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)floats.Length);
        writer.WriteCompressedSequenceFloat32(floats);
    }

    public static SequenceFloat32Reader<T> ReadCompressedLengthPrefixedSequenceFloat32<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new SequenceFloat32Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceFloat32Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private SequenceFloat32ReaderState<T> _state;

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
                dest[i] = _state.Read(ref reader);
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
    public static void WriteCompressedSequenceFloat64<T>(ref this T writer, ReadOnlySpan<double> doubles)
        where T : struct, IByteWriter
    {
        var seqWriter = new SequenceFloat64WriterState<T>();

        for (var i = 0; i < doubles.Length; i++)
            seqWriter.Write(ref writer, doubles[i]);
    }

    /// <summary>
    /// Create a writer for a sequence of doubles using variable length encoding. For totally uncorrelated
    /// data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceFloat64WriterState<T>
        where T : struct, IByteWriter
    {
        private long _prev;

        public void Write(ref T writer, double value)
        {
            var fint = BitConverter.DoubleToInt64Bits(value);
            var xor = fint ^ _prev;
            _prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    /// <summary>
    /// Create a reader for a sequence of doubles using variable length encoding. This reader
    /// does not validate the length of the sequence!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceFloat64ReaderState<T>
        where T : struct, IByteReader
    {
        private long _prev;

        public double Read(ref T reader)
        {
            var xor = (long)reader.ReadVariableInt64();

            var fint = xor ^ _prev;
            _prev = fint;

            return BitConverter.Int64BitsToDouble(fint);
        }
    }

    public static void ReadCompressedSequenceFloat64<T>(ref this T reader, Span<double> output)
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
    public static void WriteCompressedLengthPrefixedSequenceFloat64<T>(ref this T writer, ReadOnlySpan<double> doubles)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)doubles.Length);
        writer.WriteCompressedSequenceFloat64(doubles);
    }

    public static SequenceFloat64Reader<T> ReadCompressedLengthPrefixedSequenceFloat64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new SequenceFloat64Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceFloat64Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private SequenceFloat64ReaderState<T> _state;

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
                dest[i] = _state.Read(ref reader);
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
    public static void WriteCompressedSequenceInt32<T>(ref this T writer, ReadOnlySpan<int> ints)
        where T : struct, IByteWriter
    {
        var seqWriter = new SequenceInt32WriterState<T>();

        for (var i = 0; i < ints.Length; i++)
            seqWriter.Write(ref writer, ints[i]);
    }

    /// <summary>
    /// Create a writer for a sequence of ints using variable length encoding. For totally uncorrelated
    /// data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceInt32WriterState<T>
        where T : struct, IByteWriter
    {
        private int _prev;

        public void Write(ref T writer, int value)
        {
            var fint = (value);
            var xor = fint ^ _prev;
            _prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    /// <summary>
    /// Create a reader for a sequence of ints using variable length encoding. This reader
    /// does not validate the length of the sequence!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceInt32ReaderState<T>
        where T : struct, IByteReader
    {
        private int _prev;

        public int Read(ref T reader)
        {
            var xor = (int)reader.ReadVariableInt64();

            var fint = xor ^ _prev;
            _prev = fint;

            return (fint);
        }
    }

    public static void ReadCompressedSequenceInt32<T>(ref this T reader, Span<int> output)
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
    public static void WriteCompressedLengthPrefixedSequenceInt32<T>(ref this T writer, ReadOnlySpan<int> ints)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)ints.Length);
        writer.WriteCompressedSequenceInt32(ints);
    }

    public static SequenceInt32Reader<T> ReadCompressedLengthPrefixedSequenceInt32<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new SequenceInt32Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceInt32Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private SequenceInt32ReaderState<T> _state;

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
                dest[i] = _state.Read(ref reader);
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
    public static void WriteCompressedSequenceUInt32<T>(ref this T writer, ReadOnlySpan<uint> uints)
        where T : struct, IByteWriter
    {
        var seqWriter = new SequenceUInt32WriterState<T>();

        for (var i = 0; i < uints.Length; i++)
            seqWriter.Write(ref writer, uints[i]);
    }

    /// <summary>
    /// Create a writer for a sequence of uints using variable length encoding. For totally uncorrelated
    /// data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceUInt32WriterState<T>
        where T : struct, IByteWriter
    {
        private uint _prev;

        public void Write(ref T writer, uint value)
        {
            var fint = (value);
            var xor = fint ^ _prev;
            _prev = fint;
            writer.WriteVariableUInt64(xor);
        }
    }

    /// <summary>
    /// Create a reader for a sequence of uints using variable length encoding. This reader
    /// does not validate the length of the sequence!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceUInt32ReaderState<T>
        where T : struct, IByteReader
    {
        private uint _prev;

        public uint Read(ref T reader)
        {
            var xor = (uint)reader.ReadVariableUInt64();

            var fint = xor ^ _prev;
            _prev = fint;

            return (fint);
        }
    }

    public static void ReadCompressedSequenceUInt32<T>(ref this T reader, Span<uint> output)
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
    public static void WriteCompressedLengthPrefixedSequenceUInt32<T>(ref this T writer, ReadOnlySpan<uint> uints)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)uints.Length);
        writer.WriteCompressedSequenceUInt32(uints);
    }

    public static SequenceUInt32Reader<T> ReadCompressedLengthPrefixedSequenceUInt32<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new SequenceUInt32Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceUInt32Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private SequenceUInt32ReaderState<T> _state;

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
                dest[i] = _state.Read(ref reader);
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
    public static void WriteCompressedSequenceInt64<T>(ref this T writer, ReadOnlySpan<long> longs)
        where T : struct, IByteWriter
    {
        var seqWriter = new SequenceInt64WriterState<T>();

        for (var i = 0; i < longs.Length; i++)
            seqWriter.Write(ref writer, longs[i]);
    }

    /// <summary>
    /// Create a writer for a sequence of longs using variable length encoding. For totally uncorrelated
    /// data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceInt64WriterState<T>
        where T : struct, IByteWriter
    {
        private long _prev;

        public void Write(ref T writer, long value)
        {
            var fint = (value);
            var xor = fint ^ _prev;
            _prev = fint;
            writer.WriteVariableInt64(xor);
        }
    }

    /// <summary>
    /// Create a reader for a sequence of longs using variable length encoding. This reader
    /// does not validate the length of the sequence!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceInt64ReaderState<T>
        where T : struct, IByteReader
    {
        private long _prev;

        public long Read(ref T reader)
        {
            var xor = (long)reader.ReadVariableInt64();

            var fint = xor ^ _prev;
            _prev = fint;

            return (fint);
        }
    }

    public static void ReadCompressedSequenceInt64<T>(ref this T reader, Span<long> output)
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
    public static void WriteCompressedLengthPrefixedSequenceInt64<T>(ref this T writer, ReadOnlySpan<long> longs)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)longs.Length);
        writer.WriteCompressedSequenceInt64(longs);
    }

    public static SequenceInt64Reader<T> ReadCompressedLengthPrefixedSequenceInt64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new SequenceInt64Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceInt64Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private SequenceInt64ReaderState<T> _state;

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
                dest[i] = _state.Read(ref reader);
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
    public static void WriteCompressedSequenceUInt64<T>(ref this T writer, ReadOnlySpan<ulong> ulongs)
        where T : struct, IByteWriter
    {
        var seqWriter = new SequenceUInt64WriterState<T>();

        for (var i = 0; i < ulongs.Length; i++)
            seqWriter.Write(ref writer, ulongs[i]);
    }

    /// <summary>
    /// Create a writer for a sequence of ulongs using variable length encoding. For totally uncorrelated
    /// data this will make the output data about 1.2x <b>larger</b>! However if the data are correlated
    /// (e.g. with ~1,000,000 of each other) then this will be about 0.85x **smaller**.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceUInt64WriterState<T>
        where T : struct, IByteWriter
    {
        private ulong _prev;

        public void Write(ref T writer, ulong value)
        {
            var fint = (value);
            var xor = fint ^ _prev;
            _prev = fint;
            writer.WriteVariableUInt64(xor);
        }
    }

    /// <summary>
    /// Create a reader for a sequence of ulongs using variable length encoding. This reader
    /// does not validate the length of the sequence!
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SequenceUInt64ReaderState<T>
        where T : struct, IByteReader
    {
        private ulong _prev;

        public ulong Read(ref T reader)
        {
            var xor = (ulong)reader.ReadVariableUInt64();

            var fint = xor ^ _prev;
            _prev = fint;

            return (fint);
        }
    }

    public static void ReadCompressedSequenceUInt64<T>(ref this T reader, Span<ulong> output)
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
    public static void WriteCompressedLengthPrefixedSequenceUInt64<T>(ref this T writer, ReadOnlySpan<ulong> ulongs)
        where T : struct, IByteWriter
    {
        writer.WriteVariableUInt64((ulong)ulongs.Length);
        writer.WriteCompressedSequenceUInt64(ulongs);
    }

    public static SequenceUInt64Reader<T> ReadCompressedLengthPrefixedSequenceUInt64<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new SequenceUInt64Reader<T>((int)reader.ReadVariableUInt64());
    }

    public struct SequenceUInt64Reader<T>
        where T : struct, IByteReader
    {
        public int Remaining { get; private set; }

        private SequenceUInt64ReaderState<T> _state;

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
                dest[i] = _state.Read(ref reader);
        }
    }

}

