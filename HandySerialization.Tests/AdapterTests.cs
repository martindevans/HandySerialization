using HandySerialization.Adapters;
using HandySerialization.Extensions;
using HandySerialization.Extensions.Lossy;

namespace HandySerialization.Tests;

[TestClass]
public class AdapterTests
{
    private static byte[] DrainBytes(TestWriterReader writer)
    {
        var bytes = new byte[writer.UnreadBytes];
        writer.ReadBytes(bytes);
        return bytes;
    }

    // ── Integer adapters ────────────────────────────────────────────────────

    [TestMethod]
    public void Int8Adapter_MatchesUnderlying()
    {
        sbyte v1 = -42, v2 = 99;

        var adapter = new TestWriterReader();
        adapter.Write(new Int8Adapter(), in v1);
        adapter.Write(new Int8Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void Int8Adapter_RoundTrip()
    {
        sbyte v1 = -42, v2 = 99;
        var s = new TestWriterReader();
        s.Write(new Int8Adapter(), in v1);
        s.Write(new Int8Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, Int8Adapter, sbyte>(new Int8Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, Int8Adapter, sbyte>(new Int8Adapter()));
    }

    [TestMethod]
    public void Int16Adapter_MatchesUnderlying()
    {
        short v1 = -1000, v2 = 32000;

        var adapter = new TestWriterReader();
        adapter.Write(new Int16Adapter(), in v1);
        adapter.Write(new Int16Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void Int16Adapter_RoundTrip()
    {
        short v1 = -1000, v2 = 32000;
        var s = new TestWriterReader();
        s.Write(new Int16Adapter(), in v1);
        s.Write(new Int16Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, Int16Adapter, short>(new Int16Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, Int16Adapter, short>(new Int16Adapter()));
    }

    [TestMethod]
    public void Int32Adapter_MatchesUnderlying()
    {
        int v1 = -123456, v2 = 789012;

        var adapter = new TestWriterReader();
        adapter.Write(new Int32Adapter(), in v1);
        adapter.Write(new Int32Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void Int32Adapter_RoundTrip()
    {
        int v1 = -123456, v2 = 789012;
        var s = new TestWriterReader();
        s.Write(new Int32Adapter(), in v1);
        s.Write(new Int32Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, Int32Adapter, int>(new Int32Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, Int32Adapter, int>(new Int32Adapter()));
    }

    [TestMethod]
    public void Int64Adapter_MatchesUnderlying()
    {
        long v1 = long.MinValue / 2, v2 = long.MaxValue / 2;

        var adapter = new TestWriterReader();
        adapter.Write(new Int64Adapter(), in v1);
        adapter.Write(new Int64Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void Int64Adapter_RoundTrip()
    {
        long v1 = long.MinValue / 2, v2 = long.MaxValue / 2;
        var s = new TestWriterReader();
        s.Write(new Int64Adapter(), in v1);
        s.Write(new Int64Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, Int64Adapter, long>(new Int64Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, Int64Adapter, long>(new Int64Adapter()));
    }

    [TestMethod]
    public void UInt8Adapter_MatchesUnderlying()
    {
        byte v1 = 0, v2 = 255;

        var adapter = new TestWriterReader();
        adapter.Write(new UInt8Adapter(), in v1);
        adapter.Write(new UInt8Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void UInt8Adapter_RoundTrip()
    {
        byte v1 = 0, v2 = 255;
        var s = new TestWriterReader();
        s.Write(new UInt8Adapter(), in v1);
        s.Write(new UInt8Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, UInt8Adapter, byte>(new UInt8Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, UInt8Adapter, byte>(new UInt8Adapter()));
    }

    [TestMethod]
    public void UInt16Adapter_MatchesUnderlying()
    {
        ushort v1 = 0, v2 = 65535;

        var adapter = new TestWriterReader();
        adapter.Write(new UInt16Adapter(), in v1);
        adapter.Write(new UInt16Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void UInt16Adapter_RoundTrip()
    {
        ushort v1 = 0, v2 = 65535;
        var s = new TestWriterReader();
        s.Write(new UInt16Adapter(), in v1);
        s.Write(new UInt16Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, UInt16Adapter, ushort>(new UInt16Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, UInt16Adapter, ushort>(new UInt16Adapter()));
    }

    [TestMethod]
    public void UInt32Adapter_MatchesUnderlying()
    {
        uint v1 = 0, v2 = uint.MaxValue;

        var adapter = new TestWriterReader();
        adapter.Write(new UInt32Adapter(), in v1);
        adapter.Write(new UInt32Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void UInt32Adapter_RoundTrip()
    {
        uint v1 = 0, v2 = uint.MaxValue;
        var s = new TestWriterReader();
        s.Write(new UInt32Adapter(), in v1);
        s.Write(new UInt32Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, UInt32Adapter, uint>(new UInt32Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, UInt32Adapter, uint>(new UInt32Adapter()));
    }

    [TestMethod]
    public void UInt64Adapter_MatchesUnderlying()
    {
        ulong v1 = 0, v2 = ulong.MaxValue;

        var adapter = new TestWriterReader();
        adapter.Write(new UInt64Adapter(), in v1);
        adapter.Write(new UInt64Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void UInt64Adapter_RoundTrip()
    {
        ulong v1 = 0, v2 = ulong.MaxValue;
        var s = new TestWriterReader();
        s.Write(new UInt64Adapter(), in v1);
        s.Write(new UInt64Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, UInt64Adapter, ulong>(new UInt64Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, UInt64Adapter, ulong>(new UInt64Adapter()));
    }

    // ── Variable-length signed integer adapters ─────────────────────────────

    [TestMethod]
    public void VarInt16Adapter_MatchesUnderlying()
    {
        short v1 = -300, v2 = 300;

        var adapter = new TestWriterReader();
        adapter.Write(new VarInt16Adapter(), in v1);
        adapter.Write(new VarInt16Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteVariableInt64(v1);
        direct.WriteVariableInt64(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void VarInt16Adapter_RoundTrip()
    {
        short v1 = -300, v2 = 300;
        var s = new TestWriterReader();
        s.Write(new VarInt16Adapter(), in v1);
        s.Write(new VarInt16Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, VarInt16Adapter, short>(new VarInt16Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, VarInt16Adapter, short>(new VarInt16Adapter()));
    }

    [TestMethod]
    public void VarInt32Adapter_MatchesUnderlying()
    {
        int v1 = -100000, v2 = 100000;

        var adapter = new TestWriterReader();
        adapter.Write(new VarInt32Adapter(), in v1);
        adapter.Write(new VarInt32Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteVariableInt64(v1);
        direct.WriteVariableInt64(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void VarInt32Adapter_RoundTrip()
    {
        int v1 = -100000, v2 = 100000;
        var s = new TestWriterReader();
        s.Write(new VarInt32Adapter(), in v1);
        s.Write(new VarInt32Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, VarInt32Adapter, int>(new VarInt32Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, VarInt32Adapter, int>(new VarInt32Adapter()));
    }

    [TestMethod]
    public void VarInt64Adapter_MatchesUnderlying()
    {
        long v1 = long.MinValue / 3, v2 = long.MaxValue / 3;

        var adapter = new TestWriterReader();
        adapter.Write(new VarInt64Adapter(), in v1);
        adapter.Write(new VarInt64Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteVariableInt64(v1);
        direct.WriteVariableInt64(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void VarInt64Adapter_RoundTrip()
    {
        long v1 = long.MinValue / 3, v2 = long.MaxValue / 3;
        var s = new TestWriterReader();
        s.Write(new VarInt64Adapter(), in v1);
        s.Write(new VarInt64Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, VarInt64Adapter, long>(new VarInt64Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, VarInt64Adapter, long>(new VarInt64Adapter()));
    }

    // ── Variable-length unsigned integer adapters ───────────────────────────

    [TestMethod]
    public void VarUInt16Adapter_MatchesUnderlying()
    {
        ushort v1 = 0, v2 = 50000;

        var adapter = new TestWriterReader();
        adapter.Write(new VarUInt16Adapter(), in v1);
        adapter.Write(new VarUInt16Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteVariableUInt64(v1);
        direct.WriteVariableUInt64(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void VarUInt16Adapter_RoundTrip()
    {
        ushort v1 = 0, v2 = 50000;
        var s = new TestWriterReader();
        s.Write(new VarUInt16Adapter(), in v1);
        s.Write(new VarUInt16Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, VarUInt16Adapter, ushort>(new VarUInt16Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, VarUInt16Adapter, ushort>(new VarUInt16Adapter()));
    }

    [TestMethod]
    public void VarUInt32Adapter_MatchesUnderlying()
    {
        uint v1 = 0, v2 = 3_000_000;

        var adapter = new TestWriterReader();
        adapter.Write(new VarUInt32Adapter(), in v1);
        adapter.Write(new VarUInt32Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteVariableUInt64(v1);
        direct.WriteVariableUInt64(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void VarUInt32Adapter_RoundTrip()
    {
        uint v1 = 0, v2 = 3_000_000;
        var s = new TestWriterReader();
        s.Write(new VarUInt32Adapter(), in v1);
        s.Write(new VarUInt32Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, VarUInt32Adapter, uint>(new VarUInt32Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, VarUInt32Adapter, uint>(new VarUInt32Adapter()));
    }

    [TestMethod]
    public void VarUInt64Adapter_MatchesUnderlying()
    {
        ulong v1 = 0, v2 = ulong.MaxValue / 3;

        var adapter = new TestWriterReader();
        adapter.Write(new VarUInt64Adapter(), in v1);
        adapter.Write(new VarUInt64Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteVariableUInt64(v1);
        direct.WriteVariableUInt64(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void VarUInt64Adapter_RoundTrip()
    {
        ulong v1 = 0, v2 = ulong.MaxValue / 3;
        var s = new TestWriterReader();
        s.Write(new VarUInt64Adapter(), in v1);
        s.Write(new VarUInt64Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, VarUInt64Adapter, ulong>(new VarUInt64Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, VarUInt64Adapter, ulong>(new VarUInt64Adapter()));
    }

    // ── Float adapters ──────────────────────────────────────────────────────

    [TestMethod]
    public void Float32Adapter_MatchesUnderlying()
    {
        float v1 = 1.5f, v2 = -3.14f;

        var adapter = new TestWriterReader();
        adapter.Write(new Float32Adapter(), in v1);
        adapter.Write(new Float32Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void Float32Adapter_RoundTrip()
    {
        float v1 = 1.5f, v2 = -3.14f;
        var s = new TestWriterReader();
        s.Write(new Float32Adapter(), in v1);
        s.Write(new Float32Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, Float32Adapter, float>(new Float32Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, Float32Adapter, float>(new Float32Adapter()));
    }

    [TestMethod]
    public void Float64Adapter_MatchesUnderlying()
    {
        double v1 = 1.5, v2 = -3.14;

        var adapter = new TestWriterReader();
        adapter.Write(new Float64Adapter(), in v1);
        adapter.Write(new Float64Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.Write(v1);
        direct.Write(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void Float64Adapter_RoundTrip()
    {
        double v1 = 1.5, v2 = -3.14;
        var s = new TestWriterReader();
        s.Write(new Float64Adapter(), in v1);
        s.Write(new Float64Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, Float64Adapter, double>(new Float64Adapter()));
        Assert.AreEqual(v2, s.Read<TestWriterReader, Float64Adapter, double>(new Float64Adapter()));
    }

    [TestMethod]
    public void NormalizedFloat8Adapter_MatchesUnderlying()
    {
        float v1 = 0.25f, v2 = 0.75f;

        var adapter = new TestWriterReader();
        adapter.Write(new NormalizedFloat8Adapter(), in v1);
        adapter.Write(new NormalizedFloat8Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteNormalizedFloat8(v1);
        direct.WriteNormalizedFloat8(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void NormalizedFloat8Adapter_RoundTrip()
    {
        float v1 = 0.25f, v2 = 0.75f;
        var s = new TestWriterReader();
        s.Write(new NormalizedFloat8Adapter(), in v1);
        s.Write(new NormalizedFloat8Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, NormalizedFloat8Adapter, float>(new NormalizedFloat8Adapter()), 2f / byte.MaxValue);
        Assert.AreEqual(v2, s.Read<TestWriterReader, NormalizedFloat8Adapter, float>(new NormalizedFloat8Adapter()), 2f / byte.MaxValue);
    }

    [TestMethod]
    public void NormalizedFloat16Adapter_MatchesUnderlying()
    {
        float v1 = 0.1f, v2 = 0.9f;

        var adapter = new TestWriterReader();
        adapter.Write(new NormalizedFloat16Adapter(), in v1);
        adapter.Write(new NormalizedFloat16Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteNormalizedFloat16(v1);
        direct.WriteNormalizedFloat16(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void NormalizedFloat16Adapter_RoundTrip()
    {
        float v1 = 0.1f, v2 = 0.9f;
        var s = new TestWriterReader();
        s.Write(new NormalizedFloat16Adapter(), in v1);
        s.Write(new NormalizedFloat16Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, NormalizedFloat16Adapter, float>(new NormalizedFloat16Adapter()), 2f / ushort.MaxValue);
        Assert.AreEqual(v2, s.Read<TestWriterReader, NormalizedFloat16Adapter, float>(new NormalizedFloat16Adapter()), 2f / ushort.MaxValue);
    }

    [TestMethod]
    public void NormalizedFloat24Adapter_MatchesUnderlying()
    {
        float v1 = 0.3f, v2 = 0.6f;

        var adapter = new TestWriterReader();
        adapter.Write(new NormalizedFloat24Adapter(), in v1);
        adapter.Write(new NormalizedFloat24Adapter(), in v2);

        var direct = new TestWriterReader();
        direct.WriteNormalizedFloat24(v1);
        direct.WriteNormalizedFloat24(v2);

        CollectionAssert.AreEqual(DrainBytes(direct), DrainBytes(adapter));
    }

    [TestMethod]
    public void NormalizedFloat24Adapter_RoundTrip()
    {
        float v1 = 0.3f, v2 = 0.6f;
        var s = new TestWriterReader();
        s.Write(new NormalizedFloat24Adapter(), in v1);
        s.Write(new NormalizedFloat24Adapter(), in v2);
        Assert.AreEqual(v1, s.Read<TestWriterReader, NormalizedFloat24Adapter, float>(new NormalizedFloat24Adapter()), 2f / 16777215);
        Assert.AreEqual(v2, s.Read<TestWriterReader, NormalizedFloat24Adapter, float>(new NormalizedFloat24Adapter()), 2f / 16777215);
    }
}
