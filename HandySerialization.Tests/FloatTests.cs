using System.Runtime.InteropServices;
using HandySerialization.Extensions;
using HandySerialization.Extensions.Lossy;

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
    public void RoundTripRangeFloat24()
    {
        var rng = new Random(567345);

        const int count = 1_000_000;
        for (var i = 0; i < count; i++)
        {
            var serializer = new TestWriterReader();

            var min = rng.NextSingle() * rng.Next(-100000, 100000);
            var max = min + rng.NextSingle() * rng.Next(0, 100000);
            var range = max - min;

            var input = min + rng.NextSingle() * range;

            serializer.WriteRangeLimitedFloat24(input, min, range);
            var output = serializer.ReadRangeLimitedFloat24(min, range);

            Assert.AreEqual(input, output, (2 * range) / 16777215);
        }
    }

    private static void CheckCompressionStats<T>(Span<T> sequence, TestWriterReader serializer)
    {
        var expected = sequence.Length * Marshal.SizeOf<T>() + 4;
        var actual = serializer.UnreadBytes;
        var saved = expected - actual;
        var factor = actual / (float)expected;
        Console.WriteLine($"Saved: {saved} ({factor}x)");
        Assert.IsTrue(expected >= actual - 100);
    }

    [TestMethod]
    public void RoundTripFloatSequenceFloat32()
    {
        var rng = new Random(347245);

        const int count = 1000;
        var sequence = new float[count];
        var output = new float[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextSingle() - 0.5f) * 1_000_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextSingle() - 0.5f) * 1_000f;
            }

            var serializer = new TestWriterReader();

            serializer.WriteCompressedLengthPrefixedSequenceFloat32(sequence);

            CheckCompressionStats<float>(sequence, serializer);

            var seq = serializer.ReadCompressedLengthPrefixedSequenceFloat32();
            seq.Read(ref serializer, output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceFloat64()
    {
        var rng = new Random(347245);

        const int count = 1000;
        var sequence = new double[count];
        var output = new double[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextDouble() - 0.5) * 1_000_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextDouble() - 0.5) * 1_000;
            }

            var serializer = new TestWriterReader();

            serializer.WriteCompressedLengthPrefixedSequenceFloat64(sequence);

            CheckCompressionStats<double>(sequence, serializer);

            var seq = serializer.ReadCompressedLengthPrefixedSequenceFloat64();
            seq.Read(ref serializer, output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceInt32()
    {
        var rng = new Random(347245);

        const int count = 1000;
        var sequence = new int[count];
        var output = new int[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = rng.Next();
                else
                    sequence[j] = sequence[j - 1] + rng.Next(-1048576, 1048576);
            }

            var serializer = new TestWriterReader();

            serializer.WriteCompressedLengthPrefixedSequenceInt32(sequence);

            CheckCompressionStats<int>(sequence, serializer);

            var seq = serializer.ReadCompressedLengthPrefixedSequenceInt32();
            seq.Read(ref serializer, output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceUInt32()
    {
        var rng = new Random(347245);

        const int count = 1000;
        var sequence = new uint[count];
        var output = new uint[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = unchecked((uint)rng.Next());
                else
                    sequence[j] = unchecked((uint)sequence[j - 1] + (uint)rng.Next(0, 1048576));
            }

            var serializer = new TestWriterReader();

            serializer.WriteCompressedLengthPrefixedSequenceUInt32(sequence);

            CheckCompressionStats<uint>(sequence, serializer);

            var seq = serializer.ReadCompressedLengthPrefixedSequenceUInt32();
            seq.Read(ref serializer, output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceInt64()
    {
        var rng = new Random(98457);

        const int count = 1000;
        var sequence = new long[count];
        var output = new long[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = rng.Next();
                else
                    sequence[j] = sequence[j - 1] + rng.NextInt64(-4294967296, 4294967296);
            }

            var serializer = new TestWriterReader();

            serializer.WriteCompressedLengthPrefixedSequenceInt64(sequence);

            CheckCompressionStats<long>(sequence, serializer);

            var seq = serializer.ReadCompressedLengthPrefixedSequenceInt64();
            seq.Read(ref serializer, output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceUInt64()
    {
        var rng = new Random(98457);

        const int count = 1000;
        var sequence = new ulong[count];
        var output = new ulong[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = unchecked((ulong)rng.NextInt64());
                else
                    sequence[j] = unchecked(sequence[j - 1] + (ulong)rng.NextInt64(0, 4294967296));
            }

            var serializer = new TestWriterReader();

            serializer.WriteCompressedLengthPrefixedSequenceUInt64(sequence);

            CheckCompressionStats<ulong>(sequence, serializer);

            var seq = serializer.ReadCompressedLengthPrefixedSequenceUInt64();
            seq.Read(ref serializer, output);

            Assert.IsTrue(sequence.SequenceEqual(output));
        }
    }

    [TestMethod]
    public void RoundTripFloatSequenceFloat64_Delta()
    {
        var rng = new Random(5683656);

        const int count = 10000;
        var sequence = new double[count];
        var output = new double[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextDouble() - 0.5) * 1_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextDouble() - 0.5) * 1_000;
            }
        }

        var serializer = new TestWriterReader();

        serializer.WriteDeltaCompressedSequence(3, sequence);
        serializer.ReadDeltaCompressedSequence(3, output);

        Assert.IsTrue(sequence.SequenceEqual(output));
    }

    [TestMethod]
    public void RoundTripFloatSequenceFloat64_Delta_Stride()
    {
        var rng = new Random(5683656);

        const int count = 3000;
        Assert.IsTrue(count % 3 == 0);

        var sequence = new double[count];
        var output = new double[count];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < sequence.Length; j++)
            {
                if (j == 0)
                    sequence[j] = (rng.NextDouble() - 0.5) * 1_000;
                else
                    sequence[j] = sequence[j - 1] + (rng.NextDouble() - 0.5) * 1_000;
            }
        }

        var serializer = new TestWriterReader();

        // Write out data with 3 parts, strided to step over each other. As if it's e.g. double3
        serializer.WriteDeltaCompressedSequence(3, sequence, offset:0, stride:3);
        serializer.WriteDeltaCompressedSequence(3, sequence, offset:1, stride:3);
        serializer.WriteDeltaCompressedSequence(3, sequence, offset:2, stride:3);

        // Read that data, all into the same array
        serializer.ReadDeltaCompressedSequence(3, output, offset: 0, stride: 3);
        serializer.ReadDeltaCompressedSequence(3, output, offset: 1, stride: 3);
        serializer.ReadDeltaCompressedSequence(3, output, offset: 2, stride: 3);

        // Final result should be the same as the input
        Assert.IsTrue(sequence.SequenceEqual(output));
    }
}