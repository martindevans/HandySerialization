using HandySerialization.Extensions;
using HandySerialization.Wrappers;

namespace HandySerialization.Tests;

[TestClass]
public class MemoryWrapperTests
{
    [TestMethod]
    public void RoundTripMemory()
    {
        var bytes = new byte[128];

        var writer = new MemoryByteWriter(bytes);
        writer.WriteVariableInt64(1);
        writer.WriteVariableInt64(22);
        writer.WriteVariableInt64(333);
        writer.WriteVariableInt64(4444);
        writer.WriteVariableInt64(55555);

        var reader = new MemoryByteReader(bytes.AsMemory(0, writer.Written));
        Assert.AreEqual(1, reader.ReadVariableInt64());
        Assert.AreEqual(22, reader.ReadVariableInt64());
        Assert.AreEqual(333, reader.ReadVariableInt64());
        Assert.AreEqual(4444, reader.ReadVariableInt64());
        Assert.AreEqual(55555, reader.ReadVariableInt64());
        Assert.AreEqual(0, reader.UnreadBytes);
    }

    [TestMethod]
    public void ReadSpan()
    {
        var bytes = new byte[128];

        var writer = new MemoryByteWriter(bytes);
        writer.Write([1, 2, 3, 4, 5]);

        var reader = new MemoryByteReader(bytes.AsMemory(0, writer.Written));
        var read = reader.ReadBytes(5);

        Assert.AreEqual(1, read[0]);
        Assert.AreEqual(2, read[1]);
        Assert.AreEqual(3, read[2]);
        Assert.AreEqual(4, read[3]);
        Assert.AreEqual(5, read[4]);
        Assert.AreEqual(5, read.Length);
    }
}