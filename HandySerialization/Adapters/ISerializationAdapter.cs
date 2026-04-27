namespace HandySerialization.Adapters;

public interface ISerializationAdapter<TType>
{
    void Write<TWriter>(ref TWriter writer, ref readonly TType value)
        where TWriter : struct, IByteWriter;

    TType Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader;
}