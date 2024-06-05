using HandySerialization.Extensions;
using HandySerialization.Wrappers;

namespace HandySerialization.Tests;

[TestClass]
public class StreamWrapperTests
{
    [TestMethod]
    public void RoundTripStream()
    {
        const long input = 3656726482446544664;

        var stream = new MemoryStream();

        var writer = new StreamByteWriter(stream);
        writer.WriteVariableInt64(input);

        stream.Seek(0, SeekOrigin.Begin);
        var reader = new StreamByteReader(stream);
        Assert.IsTrue(reader.UnreadBytes is > 0 and < 10);
        var output = reader.ReadVariableInt64();
        Assert.AreEqual(0, reader.UnreadBytes);

        Assert.AreEqual(input, output);
    }
}