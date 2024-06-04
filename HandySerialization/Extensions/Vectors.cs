using System.Numerics;

namespace HandySerialization.Extensions;

public static class Vectors
{
    public static void WriteNormalizedVector3<T>(this ref T writer, float x, float y, float z)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedVector3(new Vector3(x, y, z));
    }

    public static void ReadNormalizedVector3<T>(this ref T reader, out float x, out float y, out float z)
        where T : struct, IByteReader
    {
        var v = reader.ReadNormalizedVector3();
        x = v.X;
        y = v.Y;
        z = v.Z;
    }


    public static void WriteNormalizedVector3<T>(this ref T writer, Vector3 xyz)
        where T : struct, IByteWriter
    {
        // http://aras-p.info/texts/CompactNormalStorage.html
        // Method #4: Spheremap Transform

        var n = Vector3.Normalize(xyz);

        var enc = Vector2.Normalize(new Vector2(n.X, n.Y)) * MathF.Sqrt(-n.Z * 0.5f + 0.5f);
        enc = enc * 0.5f + new Vector2(0.5f);

        writer.Write(enc.X);
        writer.Write(enc.Y);
    }

    public static Vector3 ReadNormalizedVector3<T>(this ref T reader)
        where T : struct, IByteReader
    {
        // http://aras-p.info/texts/CompactNormalStorage.html
        // Method #4: Spheremap Transform

        var x = reader.ReadFloat32();
        var y = reader.ReadFloat32();

        var enc = new Vector4(x, y, 0, 0);
        var nn = enc * new Vector4(2, 2, 0, 0) + new Vector4(-1, -1, 1, -1);

        var l = Math.Max(0, Vector3.Dot(new Vector3(nn.X, nn.Y, nn.Z), -new Vector3(nn.X, nn.Y, nn.W)));
        var sqrtl = MathF.Sqrt(l);

        nn.Z = l;
        nn.X *= sqrtl;
        nn.Y *= sqrtl;

        var output = new Vector3(nn.X, nn.Y, nn.Z) * 2 + new Vector3(0, 0, -1);

        return Vector3.Normalize(output);
    }


    /// <summary>
    /// Write a quaternion using 56bits (7 bytes). One byte is used as a header and then
    /// 2 bytes is used for each of the three smallest channels. The largest channel is
    /// recovered mathematically from the fact a quaternion is unit length. Signs for all
    /// channels are preserved.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="q"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void Write<T>(this ref T writer, Quaternion q)
        where T : struct, IByteWriter
    {
        const float oneOverSqrt2 = 0.7071067f;

        // 8 bits of flags
        // [8, 7]: Indicates which component has largest magnitude
        //           00: W
        //           01: X
        //           10: Y
        //           11: Z
        // 6:      Sign of W (1 = negative)
        // 5:      Sign of X (1 = negative)
        // 4:      Sign of Y (1 = negative)
        // 3:      Sign of Z (1 = negative)
        // 2:      Unused
        // 1:      Unused
        var flags = 0;

        var max = MaxMagnitude(q.W, q.X, q.Y, q.Z);

        // Output indicator for max magnitude value
        // ReSharper disable CompareOfFloatsByEqualityOperator
        // ReSharper disable once ShiftExpressionZeroLeftOperand
        if (max == Math.Abs(q.W))
            flags |= 0b00 << 6;
        else if (max == Math.Abs(q.X))
            flags |= 0b01 << 6;
        else if (max == Math.Abs(q.Y))
            flags |= 0b10 << 6;
        else if (max == Math.Abs(q.Z))
            flags |= 0b11 << 6;
        // ReSharper restore CompareOfFloatsByEqualityOperator
        
        // Output sign bits
        flags |= q.W < 0 ? 0b100000 : 0;
        flags |= q.X < 0 ? 0b010000 : 0;
        flags |= q.Y < 0 ? 0b001000 : 0;
        flags |= q.Z < 0 ? 0b000100 : 0;

        // Write the flags
        writer.Write(checked((byte)flags));

        // Write each element, skipping the largest
        // ReSharper disable CompareOfFloatsByEqualityOperator
        if (Math.Abs(q.W) != max)
            writer.WriteRangeLimitedFloat16(MathF.Abs(q.W), 0, oneOverSqrt2);
        if (Math.Abs(q.X) != max)
            writer.WriteRangeLimitedFloat16(MathF.Abs(q.X), 0, oneOverSqrt2);
        if (Math.Abs(q.Y) != max)
            writer.WriteRangeLimitedFloat16(MathF.Abs(q.Y), 0, oneOverSqrt2);
        if (Math.Abs(q.Z) != max)
            writer.WriteRangeLimitedFloat16(MathF.Abs(q.Z), 0, oneOverSqrt2);
        // ReSharper restore CompareOfFloatsByEqualityOperator

        static float MaxMagnitude(float w, float x, float y, float z)
        {
            return Math.Max(
                Math.Max(
                    Math.Abs(w),
                    Math.Abs(x)
                ),
                Math.Max(
                    Math.Abs(y),
                    Math.Abs(z)
                )
            );
        }
    }

    public static Quaternion ReadQuaternion<T>(this ref T reader)
        where T : struct, IByteReader
    {
        const float oneOverSqrt2 = 0.7071067f;

        var flags = reader.ReadUInt8();

        // Read the three components, we don't know which is which yet
        var a = reader.ReadRangeLimitedFloat16(0, oneOverSqrt2);
        var b = reader.ReadRangeLimitedFloat16(0, oneOverSqrt2);
        var c = reader.ReadRangeLimitedFloat16(0, oneOverSqrt2);

        // Recover all 4 components
        float w = 0, x = 0, y = 0, z = 0;
        var max = (flags & 0b1100_0000) >> 6;
        switch (max)
        {
            case 0:
                x = a;
                y = b;
                z = c;
                w = MathF.Sqrt(1 - x * x - y * y - z * z);
                break;

            case 1:
                w = a;
                y = b;
                z = c;
                x = MathF.Sqrt(1 - w * w - y * y - z * z);
                break;

            case 2:
                w = a;
                x = b;
                z = c;
                y = MathF.Sqrt(1 - w * w - x * x - z * z);
                break;

            case 3:
                w = a;
                x = b;
                y = c;
                z = MathF.Sqrt(1 - w * w - x * x - y * y);
                break;
        }

        // Recover signs
        if ((flags & 0b100000) != 0)
            w = -w;
        if ((flags & 0b010000) != 0)
            x = -x;
        if ((flags & 0b001000) != 0)
            y = -y;
        if ((flags & 0b000100) != 0)
            z = -z;

        return Quaternion.Normalize(new Quaternion(x, y, z, w));
    }
}