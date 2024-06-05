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
}