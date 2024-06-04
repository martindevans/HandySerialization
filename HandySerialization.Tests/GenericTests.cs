using HandySerialization.Extensions;

namespace HandySerialization.Tests;

[TestClass]
public class GenericTests
{
    [TestMethod]
    public void RoundTrip()
    {
        var rng = new Random(347245);

        var serializer = new TestWriterReader();

        var input = new TestSerializable(rng.Next(), rng.NextDouble(), rng.NextInt64());
        serializer.Write(ref input);
        var output = serializer.Read<TestWriterReader, TestSerializable>();

        Assert.AreEqual(input, output);
    }
}

public readonly record struct TestSerializable(int A, double B, long C)
    : IByteSerializable<TestSerializable>
{
    public void Write<TWriter>(ref TWriter writer)
        where TWriter : struct, IByteWriter
    {
        writer.Write(A);
        writer.Write(B);
        writer.WriteVariableInt64(C);
    }

    public TestSerializable Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return new TestSerializable(
            reader.ReadInt32(),
            reader.ReadFloat64(),
            reader.ReadVariableInt64()
        );
    }
}