using HandySerialization.Extensions;
using HandySerialization.Wrappers;

namespace HandySerialization.Tests;

[TestClass]
public class BitWritingTests
{
    [TestMethod]
    public void RoundtripInt2()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);
        bitWriter.WriteInt2(0);
        bitWriter.WriteInt2(1);
        bitWriter.WriteInt2(2);
        bitWriter.WriteInt2(3);
        bitWriter.Flush();

        Assert.AreEqual(1, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        Assert.AreEqual(0u, bitReader.ReadInt2());
        Assert.AreEqual(1u, bitReader.ReadInt2());
        Assert.AreEqual(2u, bitReader.ReadInt2());
        Assert.AreEqual(3u, bitReader.ReadInt2());
    }

    [TestMethod]
    public void RoundtripSmallInt()
    {
        var mem = new MemoryStream();
        var byteWriter = new StreamByteWriter(mem);
        var bitWriter = new BitWriter<StreamByteWriter>(byteWriter);
        bitWriter.WriteSmallInt(12, 4);
        bitWriter.WriteSmallInt(1111, 12);
        bitWriter.WriteSmallInt(7, 3);
        bitWriter.Flush();

        Assert.AreEqual(3, mem.Length);
        mem.Position = 0;

        var byteReader = new StreamByteReader(mem);
        var bitReader = new BitReader<StreamByteReader>(byteReader);
        Assert.AreEqual(12u, bitReader.ReadSmallInt(4));
        Assert.AreEqual(1111u, bitReader.ReadSmallInt(12));
        Assert.AreEqual(7u, bitReader.ReadSmallInt(3));
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
}