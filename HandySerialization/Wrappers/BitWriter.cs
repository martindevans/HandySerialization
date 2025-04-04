using HandySerialization.Extensions;

namespace HandySerialization.Wrappers;

public struct BitWriter<TBytes>
    where TBytes : struct, IByteWriter
{
    private TBytes _writer;

    private byte _buffer;
    private int _bits;

    public BitWriter(TBytes writer)
    {
        _writer = writer;
    }

    public void Write(bool bit)
    {
        _buffer <<= 1;
        _buffer |= (byte)(bit ? 1 : 0);
        _bits++;

        if (_bits == 8)
            Flush();
    }

    public void Flush()
    {
        if (_bits == 0)
            return;

        if (_bits != 8)
            _buffer <<= (8 - _bits);

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