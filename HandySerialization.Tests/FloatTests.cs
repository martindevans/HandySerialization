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

    [TestMethod]
    public void RoundTripFloatSequenceFloat32()
    {
        var rng = new Random(347245);

        const int count = 2500;
        for (var i = 0; i < count; i++)
        {
            var sequence = new float[count];
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextSingle() - 0.5f) * 1_000_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextSingle() - 0.5f) * 1_000f;
            }

            var serializer = new TestWriterReader();

            serializer.WriteSequenceFloat32(sequence);

            var expected = sequence.Length * 4 + 4;
            var actual = serializer.UnreadBytes;
            var saved = expected - actual;
            var factor = actual / (float)expected;
            Console.WriteLine($"Saved: {saved} ({factor}x)");
            Assert.IsTrue(expected >= actual - 100);

            var length = serializer.ReadSequenceLengthFloat32();
            var output = new float[length];
            serializer.ReadSequenceValuesFloat32(output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceFloat32_Incremental()
    {
        var rng = new Random(347245);

        const int count = 2500;
        for (var i = 0; i < count; i++)
        {
            var sequence = new float[count];
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextSingle() - 0.5f) * 1_000_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextSingle() - 0.5f) * 1_000f;
            }

            var serializer = new TestWriterReader();

            serializer.WriteSequenceFloat32(sequence);

            var expected = sequence.Length * 4 + 4;
            var actual = serializer.UnreadBytes;
            var saved = expected - actual;
            var factor = actual / (float)expected;
            Console.WriteLine($"Saved: {saved} ({factor}x)");
            Assert.IsTrue(expected >= actual - 100);

            var seq = serializer.ReadSequenceFloat32();
            var output = new float[seq.Count];
            var idx = 0;
            while (seq.TryReadNext(ref serializer, out var value))
                output[idx++] = value;

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceFloat64()
    {
        var rng = new Random(347245);

        const int count = 2500;
        for (var i = 0; i < count; i++)
        {
            var sequence = new double[count];
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextDouble() - 0.5) * 1_000_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextDouble() - 0.5) * 1_000;
            }

            var serializer = new TestWriterReader();

            serializer.WriteSequenceFloat64(sequence);

            var expected = sequence.Length * 8 + 4;
            var actual = serializer.UnreadBytes;
            var saved = expected - actual;
            var factor = actual / (float)expected;
            Console.WriteLine($"Saved: {saved} ({factor}x)");
            Assert.IsTrue(expected >= actual - 200);

            var length = serializer.ReadSequenceLengthFloat64();
            var output = new double[length];
            serializer.ReadSequenceValuesFloat64(output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceFloat64_Incremental()
    {
        var rng = new Random(347245);

        const int count = 2500;
        for (var i = 0; i < count; i++)
        {
            var sequence = new double[count];
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextDouble() - 0.5) * 1_000_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextDouble() - 0.5) * 1_000;
            }

            var serializer = new TestWriterReader();

            serializer.WriteSequenceFloat64(sequence);

            var expected = sequence.Length * 8 + 4;
            var actual = serializer.UnreadBytes;
            var saved = expected - actual;
            var factor = actual / (float)expected;
            Console.WriteLine($"Saved: {saved} ({factor}x)");
            Assert.IsTrue(expected >= actual - 200);

            var seq = serializer.ReadSequenceFloat64();
            var output = new double[seq.Count];
            var idx = 0;
            while (seq.TryReadNext(ref serializer, out var value))
                output[idx++] = value;

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }
}