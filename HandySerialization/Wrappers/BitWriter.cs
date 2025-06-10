using System.Diagnostics;
using HandySerialization.Extensions;

namespace HandySerialization.Wrappers;

public struct BitWriter
{
    private static readonly uint[] Masks =
    [
        0b0000_0000u,
        0b0000_0001u,
        0b0000_0011u,
        0b0000_0111u,
        0b0000_1111u,
        0b0001_1111u,
        0b0011_1111u,
        0b0111_1111u,
        0b1111_1111u,
    ];

    private byte _buffer;
    private uint _bits;

    public int TotalWritten { get; private set; }

    /// <summary>
    /// Write one single bit
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="bit"></param>
    public void Write<TBytes>(ref TBytes writer, bool bit)
        where TBytes : struct, IByteWriter
    {
        TotalWritten++;

        _buffer <<= 1;
        _buffer |= (byte)(bit ? 1 : 0);
        _bits++;

        if (_bits == 8)
            Flush(ref writer);
        Debug.Assert(_bits < 8);
    }

    /// <summary>
    /// Write multiple bits. Equivalent to writing the bits one by one from MSB to LSB
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="data"></param>
    /// <param name="count"></param>
    public void Write<TBytes>(ref TBytes writer, uint data, uint count)
        where TBytes : struct, IByteWriter
    {
        Write(ref writer, (ulong)data, count);
    }

    /// <summary>
    /// Write the N least significant bits. MSB first. Equivalent to writing the bits one by one from MSB to LSB
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="data"></param>
    /// <param name="count"></param>
    public void Write<TBytes>(ref TBytes writer, ulong data, uint count)
        where TBytes : struct, IByteWriter
    {
        if (count > 64)
            throw new ArgumentOutOfRangeException(nameof(count), "Cannot append more than 64 bits");

        // "pointer" to the first bit
        var start = count;

        // Keep taking bits until they are all gone
        while (count > 0)
        {
            // Make space
            if (_bits == 8)
                Flush(ref writer);

            // How many bits to put into the buffer
            var amount = Math.Min(8, Math.Min(count, 8u - _bits));

            // Get that data from the input
            var bits = (byte)((data >> (int)(start - amount)) & Masks[amount]);
            start -= amount;
            count -= amount;

            // Make space in the buffer
            _buffer <<= (int)amount;
            _bits += amount;
            _buffer |= bits;

            Debug.Assert(_bits <= 8);
        }

        if (_bits == 8)
            Flush(ref writer);
        Debug.Assert(_bits < 8);
    }

    public void Flush<TBytes>(ref TBytes writer)
        where TBytes : struct, IByteWriter
    {
        if (_bits == 0)
            return;

        if (_bits != 8)
            _buffer <<= (int)(8 - _bits);

        writer.Write(_buffer);
        _bits = 0;
        _buffer = 0;
    }
}

public struct BitReader
{
    private byte _buffer;
    private int _bits;

    private void Fill<TBytes>(ref TBytes reader)
        where TBytes : struct, IByteReader
    {
        _buffer = reader.ReadUInt8();
        _bits = 8;
    }

    public bool Read<TBytes>(ref TBytes reader)
        where TBytes : struct, IByteReader
    {
        if (_bits == 0)
            Fill(ref reader);

        var value = (_buffer & 0b1000_0000) != 0;
        _buffer <<= 1;
        _bits--;

        return value;
    }

    public ulong Read<TBytes>(ref TBytes reader, uint count)
        where TBytes : struct, IByteReader
    {
        if (count > 64)
            throw new ArgumentOutOfRangeException(nameof(count), "Cannot read more than 64 bits");

        ulong result = 0;
        while (count > 0)
        {
            if (_bits == 0)
            {
                // Read bytes directly from upstream
                if (count > 32)
                    AccumulateIntoResult(ref result, ref count, reader.ReadUInt32(), 32);
                if (count > 16)
                    AccumulateIntoResult(ref result, ref count, reader.ReadUInt16(), 16);
                if (count > 8)
                    AccumulateIntoResult(ref result, ref count, reader.ReadUInt8(), 8);

                Fill(ref reader);
            }

            if (count > _bits)
            {
                AccumulateIntoResult(ref result, ref count, (uint)_buffer >> (8 - _bits), (byte)_bits);
                _bits = 0;
            }
            else
            {
                var bitsToAdd = count;
                AccumulateIntoResult(ref result, ref count, (uint)_buffer >> (8 - (int)count), (byte)bitsToAdd);
                _buffer <<= (int)bitsToAdd;
                _bits -= (int)bitsToAdd;
            }
        }

        return result;

        void AccumulateIntoResult(ref ulong result, ref uint count, uint input, byte bits)
        {
            // Make space in result buffer
            result <<= bits;

            // Move in bits from buffer
            result |= input;

            // Reduce count of remaining needed bits
            count -= bits;
        }
    }
}