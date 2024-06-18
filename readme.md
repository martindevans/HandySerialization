# HandySerialization

HandySerialization is a simple, byte oriented, binary serialization library.

## `IByteReader` & `IByteWriter`

All serialization is done as extension methods on these two interfaces.

To use the library you should create a wrapper **struct** around your underlying reader/writer which implements the appropriate interface. For example the library already includes a wrapper around `Stream` which looks like this:

```csharp
public readonly struct StreamByteWriter(Stream stream)
    : IByteWriter
{
    public void Write(ReadOnlySpan<byte> value) => stream.Write(value);
}

public readonly struct StreamByteReader(Stream stream)
    : IByteReader
{
    public long UnreadBytes => stream.Length - stream.Position;

    public void ReadBytes(Span<byte> dest) => stream.ReadExactly(dest);
}
```

## `IByteSerializable`

Any type which implements `IByteSerializable` can be read/written directly. Implementing this simply requires writing out whatever fields are necessary and reading them back in the same order. If your type contains other types then you can implement `IByteSerializable` for those nested types.

```csharp
public readonly record struct DemoStruct(int A)
    : IByteSerializable<TestSerializable>
{
    public void Write<TWriter>(ref TWriter writer)
        where TWriter : struct, IByteWriter
    {
        writer.Write(A);
    }

    public TestSerializable Read<TReader>(ref TReader reader)
        where TReader : struct, IByteReader
    {
        return new TestSerializable(
            reader.ReadInt32()
        );
    }
}

void Demo()
{
    writer.Write(new DemoStruct(42));
    var result = reader.Read<ReaderType, DemoStruct>();
}
```

## Extension Methods

If you want to serialize a type from an external library which you cannot modify, then you cannot implement `IByteSerializable` on the type. Instead you should implement extension methods for this type.

```csharp
public static class DemoExtensions
{
    public static void Write<TWriter>(this ref TWriter writer, DemoStruct value)
        where TWriter : struct, IByteWriter
    {
        writer.Write(value.A);
    }

    public static TValue ReadDemoStruct<TReader>(this ref TReader reader)
        where TReader : struct, IByteReader
    {
        return new DemoStruct(reader.ReadInt32());
    }
}

void Demo()
{
    writer.Write(new DemoStruct(42));
    var result = reader.ReadDemoStruct();
}
```

## Primitives

All of the primitive C# types have extension methods implemented for writing and reading them.

```csharp
public static void Write<T>(this ref T writer, byte b);
public static byte ReadUInt8<T>(this ref T reader);

public static void Write<T>(this ref T writer, sbyte b);
public static sbyte ReadInt8<T>(this ref T reader);

public static void Write<T>(this ref T writer, float f);
public static float ReadFloat32<T>(this ref T reader);

// etc...
```

## Variable Length

Integers can be written using variable length encoding, which uses less bytes for values closer to zero. This encoding is lossless.

```csharp
public static void WriteVariableInt64<T>(this ref T writer, long l);
public static long ReadVariableInt64<T>(this ref T reader);

public static void WriteVariableUInt64<T>(this ref T writer, ulong u);
public static ulong ReadVariableUInt64<T>(this ref T reader);
```

## Sequences

Many primitive values can be written as a **Compressed Sequence**, this is a lossless encoding which reduces correlated data to approximately 0.8x full size.

```csharp
public static void WriteCompressedSequenceFloat32<T>(this ref T writer, ReadOnlySpan<float> floats);
public static void ReadCompressedSequenceFloat32<T>(this ref T reader, Span<float> output);
```

If you know the exact length when reading, you can write the data without any length prefix (as above).

```csharp
public static void WriteCompressedLengthPrefixedSequenceFloat32<T>(this ref T writer, ReadOnlySpan<float> floats);
public static SequenceFloat32Reader<T> ReadCompressedLengthPrefixedSequenceFloat32<T>(this ref T reader);
```

If you do not know the length when reading, you can write the data with a length prefix (as above). When reading you can read a sequence reader:

```csharp
public struct SequenceFloat32Reader<T>
    where T : struct, IByteReader
{
    public int Remaining { get; private set; }

    public void Read(ref T reader, Span<float> dest);
}
```

## Lossy Encodings

HandySerialization does include some "lossy" encodings, all of them are contained within the `HandySerialization.Extensions.Lossy` namespace.

### Floats

```csharp
public static void WriteNormalizedFloat8<T>(this ref T writer, float f);
public static float ReadNormalizedFloat8<T>(this ref T reader);
```

Write floating points values `[0, 1]`, using less than the full 32 bits.

```csharp
public static void WriteRangeLimitedFloat8<T>(this ref T writer, float f, float min, float range);
public static void WriteRangeLimitedFloat16<T>(this ref T writer, float f, float min, float range);
```

Write floating points value `[min, min + range]`, using less than the full 32 bits.

### Vectors

```csharp
public static void WriteNormalizedVector2<T>(this ref T writer, Vector2 xy);
public static void WriteNormalizedVector3<T>(this ref T writer, float x, float y, float z);
```

Write vectors with `length=1` using less bits.

### Quaternion

```csharp
public static void WriteCompressedQuaternion<T>(this ref T writer, Quaternion q);
```

Write a quaternion using 56 bits (identity quaternion is a special case and only requires 8 bits).