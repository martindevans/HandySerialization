using HandySerialization.Extensions;

namespace HandySerialization.Tests;

[TestClass]
public class FloatTests
{
    [TestMethod]
    public void Float8ChecksRange()
    {
        var serializer = new TestWriterReader();

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => serializer.WriteNormalizedFloat8(-1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => serializer.WriteNormalizedFloat8(1.1f));
    }

    [TestMethod]
    public void RoundTripFloat8()
    {
        const int count = 100_000;
        for (var i = 0; i < count; i++)
        {
            var serializer = new TestWriterReader();

            var x = i / (float)count;
            serializer.WriteNormalizedFloat8(x);
            var y = serializer.ReadNormalizedFloat8();

            Assert.AreEqual(x, y, 2 / (float)byte.MaxValue);
        }
    }

    [TestMethod]
    public void Float16ChecksRange()
    {
        var serializer = new TestWriterReader();

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => serializer.WriteNormalizedFloat16(-1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => serializer.WriteNormalizedFloat16(1.1f));
    }

    [TestMethod]
    public void RoundTripFloat16()
    {
        const int count = 100_000;
        for (var i = 0; i < count; i++)
        {
            var serializer = new TestWriterReader();

            var x = i / (float)count;
            serializer.WriteNormalizedFloat16(x);
            var y = serializer.ReadNormalizedFloat16();

            Assert.AreEqual(x, y, 2 / (float)ushort.MaxValue);
        }
    }

    [TestMethod]
    public void RoundTripRangeFloat8()
    {
        var rng = new Random(347245);

        const int count = 1_000_000;
        for (var i = 0; i < count; i++)
        {
            var serializer = new TestWriterReader();

            var min = rng.NextSingle() * rng.Next(-100000, 100000);
            var max = min + rng.NextSingle() * rng.Next(0, 100000);
            var range = max - min;

            var input = min + rng.NextSingle() * range;

            serializer.WriteRangeLimitedFloat8(input, min, range);
            var output = serializer.ReadRangeLimitedFloat8(min, range);

            Assert.AreEqual(input, output, (2 * range) / byte.MaxValue);
        }
    }

    [TestMethod]
    public void RoundTripRangeFloat16()
    {
        var rng = new Random(347245);

        const int count = 1_000_000;
        for (var i = 0; i < count; i++)
        {
            var serializer = new TestWriterReader();

            var min = rng.NextSingle() * rng.Next(-100000, 100000);
            var max = min + rng.NextSingle() * rng.Next(0, 100000);
            var range = max - min;

            var input = min + rng.NextSingle() * range;

            serializer.WriteRangeLimitedFloat16(input, min, range);
            var output = serializer.ReadRangeLimitedFloat16(min, range);

            Assert.AreEqual(input, output, (2 * range) / ushort.MaxValue);
        }
    }
}