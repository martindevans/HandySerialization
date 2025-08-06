using System.Diagnostics;

namespace HandySerialization.Extensions;

public static class Vectors
{
    /// <summary>
    /// Write a vector2 using 64 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="v"></param>
    public static void Write<T>(ref this T writer, Vector2 v)
        where T : struct, IByteWriter
    {
        writer.Write(v.X);
        writer.Write(v.Y);
    }

    public static Vector2 ReadVector2<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new Vector2(
            reader.ReadFloat32(),
            reader.ReadFloat32()
        );
    }


    /// <summary>
    /// Write a vector3 using 96 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="v"></param>
    public static void Write<T>(ref this T writer, Vector3 v)
        where T : struct, IByteWriter
    {
        writer.Write(v.X);
        writer.Write(v.Y);
        writer.Write(v.Z);
    }

    public static Vector3 ReadVector3<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new Vector3(
            reader.ReadFloat32(),
            reader.ReadFloat32(),
            reader.ReadFloat32()
        );
    }


    /// <summary>
    /// Write a vector4 using 128 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="v"></param>
    public static void Write<T>(ref this T writer, Vector4 v)
        where T : struct, IByteWriter
    {
        writer.Write(v.X);
        writer.Write(v.Y);
        writer.Write(v.Z);
        writer.Write(v.W);
    }

    public static Vector4 ReadVector4<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new Vector4(
            reader.ReadFloat32(),
            reader.ReadFloat32(),
            reader.ReadFloat32(),
            reader.ReadFloat32()
        );
    }


    /// <summary>
    /// Write a quaternion using 128 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="q"></param>
    public static void Write<T>(ref this T writer, Quaternion q)
        where T : struct, IByteWriter
    {
        writer.Write(q.X);
        writer.Write(q.Y);
        writer.Write(q.Z);
        writer.Write(q.W);
    }

    public static Quaternion ReadQuaternion<T>(ref this T reader)
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
    /// Write a matrix using 512 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="m"></param>
    public static void Write<T>(ref this T writer, Matrix4x4 m)
        where T : struct, IByteWriter
    {
        writer.Write(m.M11);
        writer.Write(m.M12);
        writer.Write(m.M13);
        writer.Write(m.M14);

        writer.Write(m.M21);
        writer.Write(m.M22);
        writer.Write(m.M23);
        writer.Write(m.M24);

        writer.Write(m.M31);
        writer.Write(m.M32);
        writer.Write(m.M33);
        writer.Write(m.M34);

        writer.Write(m.M41);
        writer.Write(m.M42);
        writer.Write(m.M43);
        writer.Write(m.M44);
    }

    public static Matrix4x4 ReadMatrix4x4<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new Matrix4x4(
            m11: reader.ReadFloat32(),
            m12: reader.ReadFloat32(),
            m13: reader.ReadFloat32(),
            m14: reader.ReadFloat32(),

            m21: reader.ReadFloat32(),
            m22: reader.ReadFloat32(),
            m23: reader.ReadFloat32(),
            m24: reader.ReadFloat32(),

            m31: reader.ReadFloat32(),
            m32: reader.ReadFloat32(),
            m33: reader.ReadFloat32(),
            m34: reader.ReadFloat32(),

            m41: reader.ReadFloat32(),
            m42: reader.ReadFloat32(),
            m43: reader.ReadFloat32(),
            m44: reader.ReadFloat32()
        );
    }

    /// <summary>
    /// Write a matrix using 192 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="m"></param>
    public static void Write<T>(ref this T writer, Matrix3x2 m)
        where T : struct, IByteWriter
    {
        writer.Write(m.M11);
        writer.Write(m.M12);

        writer.Write(m.M21);
        writer.Write(m.M22);

        writer.Write(m.M31);
        writer.Write(m.M32);
    }

    public static Matrix3x2 ReadMatrix3x2<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new Matrix3x2(
            m11: reader.ReadFloat32(),
            m12: reader.ReadFloat32(),

            m21: reader.ReadFloat32(),
            m22: reader.ReadFloat32(),

            m31: reader.ReadFloat32(),
            m32: reader.ReadFloat32()
        );
    }

    /// <summary>
    /// Write a complex using 128 bits (full 64 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="c"></param>
    public static void Write<T>(ref this T writer, Complex c)
        where T : struct, IByteWriter
    {
        writer.Write(c.Real);
        writer.Write(c.Imaginary);
    }

    public static Complex ReadComplex<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new Complex(
            reader.ReadFloat64(),
            reader.ReadFloat64()
        );
    }

    /// <summary>
    /// Write a plane using 128 bits (full 32 bit float per channel)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="p"></param>
    public static void Write<T>(ref this T writer, Plane p)
        where T : struct, IByteWriter
    {
        writer.Write(p.Normal);
        writer.Write(p.D);
    }

    public static Plane ReadPlane<T>(ref this T reader)
        where T : struct, IByteReader
    {
        return new Plane(
            normal: reader.ReadVector3(),
            d: reader.ReadFloat32()
        );
    }

    /// <summary>
    /// Write a big integer using an unknown number of bytes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="b"></param>
    public static void Write<T>(ref this T writer, BigInteger b)
        where T : struct, IByteWriter
    {
        var bytesArr = ArrayPool<byte>.Shared.Rent(b.GetByteCount());
        try
        {
            // Write big int to byte array. This cannot fail, since we got the size above
            Debug.Assert(b.TryWriteBytes(bytesArr, out var bytesWritten));

            // Write length prefixed data
            writer.WriteVariableUInt64(checked((ulong)bytesWritten));
            writer.Write(bytesArr.AsSpan(0, bytesWritten));
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(bytesArr, true);
        }
    }

    public static BigInteger ReadBigInteger<T>(ref this T reader)
        where T : struct, IByteReader
    {
        var length = checked((int)reader.ReadVariableUInt64());

        var bytesArr = ArrayPool<byte>.Shared.Rent(length);
        var bytesSpan = bytesArr.AsSpan(0, length);
        try
        {
            reader.ReadBytes(bytesSpan);
            return new BigInteger(bytesSpan);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(bytesArr, true);
        }
    }
}