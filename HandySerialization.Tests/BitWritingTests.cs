using HandySerialization.Extensions;
using HandySerialization.Extensions.Bits;
using HandySerialization.Wrappers;

namespace HandySerialization.Tests;

[TestClass]
public class BitWritingTests
{
    [TestMethod]
    public void BasicBulkWrite()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();

        //                __xx xxxx xxxx xxxx xxxx xxxx xxxx xxxx
        bitWriter.Write(ref byteWriter, 0b1111_0101_1010_1100_0000_1111_0011_0000u, 30);
        bitWriter.Flush(ref byteWriter);

        Assert.AreEqual(4, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();

        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));

        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));

        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));

        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));

        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));

        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));

        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));
        Assert.AreEqual(true, bitReader.Read(ref byteReader));

        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
        Assert.AreEqual(false, bitReader.Read(ref byteReader));
    }

    [TestMethod]
    public void RoundtripInt2()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();
        bitWriter.WriteSmallUInt(ref byteWriter, 0, bits:2);
        bitWriter.WriteSmallUInt(ref byteWriter, 1, bits: 2);
        bitWriter.WriteSmallUInt(ref byteWriter, 2, bits: 2);
        bitWriter.WriteSmallUInt(ref byteWriter, 3, bits: 2);
        bitWriter.Flush(ref byteWriter);

        Assert.AreEqual(1, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();
        Assert.AreEqual(0u, bitReader.ReadSmallUInt(ref byteReader, bits: 2));
        Assert.AreEqual(1u, bitReader.ReadSmallUInt(ref byteReader, bits: 2));
        Assert.AreEqual(2u, bitReader.ReadSmallUInt(ref byteReader, bits: 2));
        Assert.AreEqual(3u, bitReader.ReadSmallUInt(ref byteReader, bits: 2));
    }

    [TestMethod]
    public void RoundtripInt3()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();
        bitWriter.WriteSmallUInt(ref byteWriter, 0, bits: 3);
        bitWriter.WriteSmallUInt(ref byteWriter, 1, bits: 3);
        bitWriter.WriteSmallUInt(ref byteWriter, 2, bits: 3);
        bitWriter.WriteSmallUInt(ref byteWriter, 3, bits: 3);
        bitWriter.WriteSmallUInt(ref byteWriter, 4, bits: 3);
        bitWriter.WriteSmallUInt(ref byteWriter, 5, bits: 3);
        bitWriter.WriteSmallUInt(ref byteWriter, 6, bits: 3);
        bitWriter.WriteSmallUInt(ref byteWriter, 7, bits: 3);
        bitWriter.Flush(ref byteWriter);

        Assert.AreEqual(3, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();
        Assert.AreEqual(0u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
        Assert.AreEqual(1u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
        Assert.AreEqual(2u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
        Assert.AreEqual(3u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
        Assert.AreEqual(4u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
        Assert.AreEqual(5u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
        Assert.AreEqual(6u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
        Assert.AreEqual(7u, bitReader.ReadSmallUInt(ref byteReader, bits: 3));
    }

    [TestMethod]
    public void RoundtripInt8()
    {
        for (var i = 0; i < 1024; i++)
        {
            var mem = new MemoryStream();

            {
                var rng = new Random(i);
                var byteWriter = new StreamByteWriter(mem);
                var bitWriter = new BitWriter();
                for (var j = 0; j < 8; j++)
                {
                    var choice = rng.NextDouble() > 0.8;

                    if (choice)
                    {
                        var smallUintValue = (uint)rng.Next();
                        var smallUintBits = (uint)rng.Next(0, 16);
                        bitWriter.WriteSmallUInt(ref byteWriter, smallUintValue, smallUintBits);
                    }

                    var byteValue = checked((byte)rng.Next(0, 256));
                    bitWriter.WriteSmallUInt(ref byteWriter, byteValue, bits: 8);
                }

                bitWriter.Flush(ref byteWriter);
            }

            mem.Position = 0;

            {
                var rng = new Random(i);
                var byteReader = new StreamByteReader(mem);
                var bitReader = new BitReader();

                for (var j = 0; j < 8; j++)
                {
                    var choice = rng.NextDouble() > 0.8;

                    if (choice)
                    {
                        var smallUintValue = (uint)rng.Next();
                        var smallUintBits = (uint)rng.Next(0, 16);
                        bitReader.ReadSmallUInt(ref byteReader, smallUintBits);
                    }

                    var expectedByte = checked((byte)rng.Next(0, 256));
                    var actualByte = bitReader.ReadSmallUInt(ref byteReader, bits: 8);
                    Assert.AreEqual(expectedByte, actualByte);
                }
            }
        }
    }

    [TestMethod]
    public void RoundtripInt50()
    {
        const int seed = 324892;
        const int count = 100_000;

        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();

        var rng = new Random(seed);
        for (var i = 0; i < count; i++)
        {
            var v = unchecked((ulong)rng.NextInt64()) & BitTwiddle.Mask(50);
            bitWriter.WriteSmallUInt(ref byteWriter, v, bits: 50);
        }

        bitWriter.Flush(ref byteWriter);

        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();
        rng = new Random(seed);
        for (var i = 0; i < count; i++)
        {
            var v = unchecked((ulong)rng.NextInt64()) & BitTwiddle.Mask(50);
            Assert.AreEqual(v, bitReader.ReadSmallUInt(ref byteReader, bits: 50));
        }
    }

    [TestMethod]
    public void RoundtripSmallInt()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();
        bitWriter.WriteSmallUInt(ref byteWriter, 12, 4);
        bitWriter.WriteSmallUInt(ref byteWriter, 1111, 12);
        bitWriter.WriteSmallUInt(ref byteWriter, 7, 3);
        bitWriter.Flush(ref byteWriter);

        Assert.AreEqual(3, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();
        Assert.AreEqual(12u, bitReader.ReadSmallUInt(ref byteReader, 4));
        Assert.AreEqual(1111u, bitReader.ReadSmallUInt(ref byteReader, 12));
        Assert.AreEqual(7u, bitReader.ReadSmallUInt(ref byteReader, 3));
    }

    [TestMethod]
    public void RoundtripUnary()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();
        for (var i = 0; i < byte.MaxValue; i++)
            bitWriter.WriteUnaryInt(ref byteWriter, (byte)i);
        bitWriter.Flush(ref byteWriter);

        Assert.AreEqual(4080, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();
        for (var i = 0; i < byte.MaxValue; i++)
            Assert.AreEqual((byte)i, bitReader.ReadUnaryInt(ref byteReader));
    }

    [TestMethod]
    public void RoundtripRiceCode32()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();
        bitWriter.WriteRiceCode32(ref byteWriter, 12, 4);
        bitWriter.Flush(ref byteWriter);

        Assert.AreEqual(1, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();
        Assert.AreEqual(12u, bitReader.ReadRiceCode32(ref byteReader, 4));
    }

    [TestMethod]
    public void RoundtripEliasGamma()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();

        const int seed = 234235;
        const int count = 100_000;

        var rng = new Random(seed);
        for (long i = 0; i < count; i++)
            bitWriter.WriteEliasGamma32(ref byteWriter, (uint)rng.NextInt64(0, uint.MaxValue));
        bitWriter.Flush(ref byteWriter);

        Console.WriteLine(mem.Length);
        mem.Position = 0;

        rng = new Random(seed);
        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();

        for (long i = 0; i < count; i++)
            Assert.AreEqual((uint)rng.NextInt64(0, uint.MaxValue), bitReader.ReadEliasGamma32(ref byteReader));
    }

    [TestMethod]
    public void RoundtripEliasDeltaGamma()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter();

        const int seed = 234235;
        const int count = 100_000;

        var rng = new Random(seed);
        for (long i = 0; i < count; i++)
            bitWriter.WriteEliasDeltaGamma32(ref byteWriter, (uint)rng.NextInt64(0, uint.MaxValue));
        bitWriter.Flush(ref byteWriter);

        Console.WriteLine(mem.Length);
        mem.Position = 0;

        rng = new Random(seed);
        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader();

        for (long i = 0; i < count; i++)
            Assert.AreEqual((uint)rng.NextInt64(0, uint.MaxValue), bitReader.ReadEliasDeltaGamma32(ref byteReader));
    }
}