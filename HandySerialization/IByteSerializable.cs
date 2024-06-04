namespace HandySerialization;

public interface IByteSerializable<out TSelf>
    where TSelf : IByteSerializable<TSelf>
{
    void Write<TWriter>(ref TWriter writer)
        where TWriter : struct, IByteWriter;

    TSelf Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader;
}