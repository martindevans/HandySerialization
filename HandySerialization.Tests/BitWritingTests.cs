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
        var bitWriter = byteWriter.AsBitWriter();

        //                __xx xxxx xxxx xxxx xxxx xxxx xxxx xxxx
        bitWriter.Write(0b1111_0101_1010_1100_0000_1111_0011_0000u, 30);
        bitWriter.Flush();

        Assert.AreEqual(4, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);

        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());

        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());

        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());

        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());

        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());

        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());

        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());
        Assert.AreEqual(true, bitReader.Read());

        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
        Assert.AreEqual(false, bitReader.Read());
    }

    [TestMethod]
    public void RoundtripInt2()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);
        bitWriter.WriteUInt2(0);
        bitWriter.WriteUInt2(1);
        bitWriter.WriteUInt2(2);
        bitWriter.WriteUInt2(3);
        bitWriter.Flush();

        Assert.AreEqual(1, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        Assert.AreEqual(0u, bitReader.ReadUInt2());
        Assert.AreEqual(1u, bitReader.ReadUInt2());
        Assert.AreEqual(2u, bitReader.ReadUInt2());
        Assert.AreEqual(3u, bitReader.ReadUInt2());
    }

    [TestMethod]
    public void RoundtripInt3()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);
        bitWriter.WriteUInt3(0);
        bitWriter.WriteUInt3(1);
        bitWriter.WriteUInt3(2);
        bitWriter.WriteUInt3(3);
        bitWriter.WriteUInt3(4);
        bitWriter.WriteUInt3(5);
        bitWriter.WriteUInt3(6);
        bitWriter.WriteUInt3(7);
        bitWriter.Flush();

        Assert.AreEqual(3, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        Assert.AreEqual(0u, bitReader.ReadUInt3());
        Assert.AreEqual(1u, bitReader.ReadUInt3());
        Assert.AreEqual(2u, bitReader.ReadUInt3());
        Assert.AreEqual(3u, bitReader.ReadUInt3());
        Assert.AreEqual(4u, bitReader.ReadUInt3());
        Assert.AreEqual(5u, bitReader.ReadUInt3());
        Assert.AreEqual(6u, bitReader.ReadUInt3());
        Assert.AreEqual(7u, bitReader.ReadUInt3());
    }

    [TestMethod]
    public void RoundtripInt50()
    {
        const int seed = 324892;
        const int count = 100_000;

        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);

        var rng = new Random(seed);
        for (var i = 0; i < count; i++)
        {
            var v = unchecked((ulong)rng.NextInt64()) & BitTwiddle.Mask(50);
            bitWriter.WriteUInt50(v);
        }

        bitWriter.Flush();

        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        rng = new Random(seed);
        for (var i = 0; i < count; i++)
        {
            var v = unchecked((ulong)rng.NextInt64()) & BitTwiddle.Mask(50);
            Assert.AreEqual(v, bitReader.ReadUInt50());
        }
    }

    [TestMethod]
    public void RoundtripSmallInt()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);
        bitWriter.WriteSmallUInt(12, 4);
        bitWriter.WriteSmallUInt(1111, 12);
        bitWriter.WriteSmallUInt(7, 3);
        bitWriter.Flush();

        Assert.AreEqual(3, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        Assert.AreEqual(12u, bitReader.ReadSmallUInt(4));
        Assert.AreEqual(1111u, bitReader.ReadSmallUInt(12));
        Assert.AreEqual(7u, bitReader.ReadSmallUInt(3));
    }

    [TestMethod]
    public void RoundtripUnary()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);
        for (var i = 0; i < byte.MaxValue; i++)
            bitWriter.WriteUnaryInt((byte)i);
        bitWriter.Flush();

        Assert.AreEqual(4080, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        for (var i = 0; i < byte.MaxValue; i++)
            Assert.AreEqual((byte)i, bitReader.ReadUnaryInt());
    }

    [TestMethod]
    public void RoundtripRiceCode32()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);
        bitWriter.WriteRiceCode32(12, 4);
        bitWriter.Flush();

        Assert.AreEqual(1, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        Assert.AreEqual(12u, bitReader.ReadRiceCode32(4));
    }

    [TestMethod]
    public void RoundtripEliasGamma()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);

        const int seed = 234235;
        const int count = 100_000;

        var rng = new Random(seed);
        for (long i = 0; i < count; i++)
            bitWriter.WriteEliasGamma32((uint)rng.NextInt64(0, uint.MaxValue));
        bitWriter.Flush();

        Console.WriteLine(mem.Length);
        mem.Position = 0;

        rng = new Random(seed);
        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);

        for (long i = 0; i < count; i++)
            Assert.AreEqual((uint)rng.NextInt64(0, uint.MaxValue), bitReader.ReadEliasGamma32());
    }

    [TestMethod]
    public void RoundtripEliasDeltaGamma()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);

        const int seed = 234235;
        const int count = 100_000;

        var rng = new Random(seed);
        for (long i = 0; i < count; i++)
            bitWriter.WriteEliasDeltaGamma32((uint)rng.NextInt64(0, uint.MaxValue));
        bitWriter.Flush();

        Console.WriteLine(mem.Length);
        mem.Position = 0;

        rng = new Random(seed);
        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);

        for (long i = 0; i < count; i++)
            Assert.AreEqual((uint)rng.NextInt64(0, uint.MaxValue), bitReader.ReadEliasDeltaGamma32());
    }
}