using System.Diagnostics;
using HandySerialization.Extensions;

namespace HandySerialization.Wrappers;

public struct BitWriter<TBytes>
    where TBytes : struct, IByteWriter
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

    private TBytes _writer;

    private byte _buffer;
    private uint _bits;

    public int TotalWritten { get; private set; }

    public BitWriter(TBytes writer)
    {
        _writer = writer;
    }

    /// <summary>
    /// Write one single bit
    /// </summary>
    /// <param name="bit"></param>
    public void Write(bool bit)
    {
        TotalWritten++;

        _buffer <<= 1;
        _buffer |= (byte)(bit ? 1 : 0);
        _bits++;

        if (_bits == 8)
            Flush();
        Debug.Assert(_bits < 8);
    }

    /// <summary>
    /// Write multiple bits. Equivalent to writing the bits one by one from MSB to LSB
    /// </summary>
    /// <param name="data"></param>
    /// <param name="count"></param>
    public void Write(uint data, uint count)
    {
        Write((ulong)data, count);
    }

    /// <summary>
    /// Write the N least significant bits. MSB first. Equivalent to writing the bits one by one from MSB to LSB
    /// </summary>
    /// <param name="data"></param>
    /// <param name="count"></param>
    public void Write(ulong data, uint count)
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
                Flush();

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
            Flush();
        Debug.Assert(_bits < 8);
    }

    public void Flush()
    {
        if (_bits == 0)
            return;

        if (_bits != 8)
            _buffer <<= (int)(8 - _bits);

        _writer.Write(_buffer);
        _bits = 0;
        _buffer = 0;
    }
}

public struct BitReader<TBytes>
    where TBytes : struct, IByteReader
{
    private TBytes _reader;

    private byte _buffer;
    private int _bits;

    public BitReader(TBytes writer)
    {
        _reader = writer;
    }

    public bool Read()
    {
        if (_bits == 0)
        {
            _buffer = _reader.ReadUInt8();
            _bits = 8;
        }

        var value = (_buffer & 0b1000_0000) != 0;
        _buffer <<= 1;
        _bits--;

        return value;
    }
}