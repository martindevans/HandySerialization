using System.Numerics;
using System.Runtime.InteropServices;
using HandySerialization.Extensions.Lossy;

namespace HandySerialization.Extensions;

public static class Vectors
{
    /// <summary>
    /// Write a quaternion using 128 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="q"></param>
    public static void Write<T>(this ref T writer, Quaternion q)
        where T : struct, IByteWriter
    {
        writer.Write(q.X);
        writer.Write(q.Y);
        writer.Write(q.Z);
        writer.Write(q.W);
    }

    public static Quaternion ReadQuaternion<T>(this ref T reader)
        where T : struct, IByteReader
    {
        return new Quaternion(
            reader.ReadFloat32(),
            reader.ReadFloat32(),
            reader.ReadFloat32(),
            reader.ReadFloat32()
        );
    }


    /// <summary>
    /// Write a quaternion using 512 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="m"></param>
    public static void Write<T>(this ref T writer, Matrix4x4 m)
        where T : struct, IByteWriter
    {
        var span = MemoryMarshal.CreateSpan(ref m.M11, 16);
        for (var i = 0; i < span.Length; i++)
            writer.Write(span[i]);
    }

    public static Matrix4x4 ReadMatrix4x4<T>(this ref T reader)
        where T : struct, IByteReader
    {
        Span<float> span = stackalloc float[16];
        for (var i = 0; i < span.Length; i++)
            span[i] = reader.ReadFloat32();

        var output = new Matrix4x4();
        var outputSpan = MemoryMarshal.CreateSpan(ref output.M11, 16);
        span.CopyTo(outputSpan);
        return output;
    }
}