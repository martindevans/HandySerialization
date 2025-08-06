using HandySerialization.Collections;

namespace HandySerialization.Extensions.Lossy;

public static class Vectors
{
    /// <summary>
    /// Write a normalized (i.e. length=1) vector using 16 bits
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public static void WriteNormalizedVector2<T>(ref this T writer, float x, float y)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedVector2(new Vector2(x, y));
    }

    public static void ReadNormalizedVector2<T>(ref this T reader, out float x, out float y)
        where T : struct, IByteReader
    {
        var v = reader.ReadNormalizedVector2();
        x = v.X;
        y = v.Y;
    }


    /// <summary>
    /// Write a normalized (i.e. length=1) vector using 16 bits
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="xy"></param>
    public static void WriteNormalizedVector2<T>(ref this T writer, Vector2 xy)
        where T : struct, IByteWriter
    {
        var atan = MathF.Atan2(xy.Y, xy.X);
        writer.WriteRangeLimitedFloat16(atan, -MathF.PI, MathF.PI * 2);
    }

    public static Vector2 ReadNormalizedVector2<T>(ref this T reader)
        where T : struct, IByteReader
    {
        var atan = reader.ReadRangeLimitedFloat16(-MathF.PI, MathF.PI * 2);
        var x = MathF.Cos(atan);
        var y = MathF.Sin(atan);

        return new Vector2(x, y);
    }


    /// <summary>
    /// Write a normalized (i.e. length=1) vector using 64 bits
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public static void WriteNormalizedVector3<T>(ref this T writer, float x, float y, float z)
        where T : struct, IByteWriter
    {
        writer.WriteNormalizedVector3(new Vector3(x, y, z));
    }

    public static void ReadNormalizedVector3<T>(ref this T reader, out float x, out float y, out float z)
        where T : struct, IByteReader
    {
        var v = reader.ReadNormalizedVector3();
        x = v.X;
        y = v.Y;
        z = v.Z;
    }


    /// <summary>
    /// Write a normalized (i.e. length=1) vector using 64 bits
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="xyz"></param>
    public static void WriteNormalizedVector3<T>(ref this T writer, Vector3 xyz)
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

    public static Vector3 ReadNormalizedVector3<T>(ref this T reader)
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
    /// Write a quaternion using 56bits. One byte is used as a header and then
    /// 2 bytes is used for each of the three smallest channels. The largest channel is
    /// recovered mathematically from the fact a quaternion is unit length. Signs for all
    /// channels are preserved.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="writer"></param>
    /// <param name="q"></param>
    public static void WriteCompressedQuaternion<T>(ref this T writer, Quaternion q)
        where T : struct, IByteWriter
    {
        const float oneOverSqrt2 = 0.70710678118f;

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
        // 2:      Indicates if the output should be an identity quaternion (all other flags ignored if set)
        // 1:      Unused
        var flags = new QuaternionBits();

        // Identity check
        if (q == Quaternion.Identity)
        {
            flags.IsIdentity = true;
            writer.Write((byte)flags.Value);
            return;
        }

        var max = MaxMagnitude(q.W, q.X, q.Y, q.Z);

        // Output indicator for max magnitude value
        // ReSharper disable CompareOfFloatsByEqualityOperator
        // ReSharper disable once ShiftExpressionZeroLeftOperand
        if (max == Math.Abs(q.W))
            flags.LargestMagnitude = QuaternionBits.LargestMagnitudeElement.W;
        else if (max == Math.Abs(q.X))
            flags.LargestMagnitude = QuaternionBits.LargestMagnitudeElement.X;
        else if (max == Math.Abs(q.Y))
            flags.LargestMagnitude = QuaternionBits.LargestMagnitudeElement.Y;
        else if (max == Math.Abs(q.Z))
            flags.LargestMagnitude = QuaternionBits.LargestMagnitudeElement.Z;
        // ReSharper restore CompareOfFloatsByEqualityOperator
        
        // Output sign bits
        flags.IsWNegative = q.W < 0;
        flags.IsXNegative = q.X < 0;
        flags.IsYNegative = q.Y < 0;
        flags.IsZNegative = q.Z < 0;

        // Write the flags
        writer.Write(flags.Value);

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

    public static Quaternion ReadCompressedQuaternion<T>(ref this T reader)
        where T : struct, IByteReader
    {
        const float oneOverSqrt2 = 0.7071067f;

        var flags = new QuaternionBits { Value = reader.ReadUInt8() };

        // Check for the special identity flag
        if (flags.IsIdentity)
            return Quaternion.Identity;

        // Read the three components, we don't know which is which yet
        var a = reader.ReadRangeLimitedFloat16(0, oneOverSqrt2);
        var b = reader.ReadRangeLimitedFloat16(0, oneOverSqrt2);
        var c = reader.ReadRangeLimitedFloat16(0, oneOverSqrt2);

        // Recover all 4 components
        float w = 0, x = 0, y = 0, z = 0;
        var max = flags.LargestMagnitude;
        switch (max)
        {
            case QuaternionBits.LargestMagnitudeElement.W:
                x = a;
                y = b;
                z = c;
                w = MathF.Sqrt(1 - x * x - y * y - z * z);
                break;

            case QuaternionBits.LargestMagnitudeElement.X:
                w = a;
                y = b;
                z = c;
                x = MathF.Sqrt(1 - w * w - y * y - z * z);
                break;

            case QuaternionBits.LargestMagnitudeElement.Y:
                w = a;
                x = b;
                z = c;
                y = MathF.Sqrt(1 - w * w - x * x - z * z);
                break;

            case QuaternionBits.LargestMagnitudeElement.Z:
                w = a;
                x = b;
                y = c;
                z = MathF.Sqrt(1 - w * w - x * x - y * y);
                break;
        }

        // Recover signs
        if (flags.IsWNegative)
            w = -w;
        if (flags.IsXNegative)
            x = -x;
        if (flags.IsYNegative)
            y = -y;
        if (flags.IsZNegative)
            z = -z;

        return Quaternion.Normalize(new Quaternion(x, y, z, w));
    }

    private struct QuaternionBits
    {
        private const byte LargestElementMask = 0b1100_0000;
        private const int LargestElementShift = 6;

        // [7, 6]: Indicates which component has largest magnitude
        //           00: W
        //           01: X
        //           10: Y
        //           11: Z
        // 5:      Sign of W (1 = negative)
        // 4:      Sign of X (1 = negative)
        // 3:      Sign of Y (1 = negative)
        // 2:      Sign of Z (1 = negative)
        // 1:      Indicates if the output should be an identity quaternion (all other flags ignored if set)
        // 0:      Unused
        public Bitfield8 Value;

        public bool IsIdentity
        {
            get => Value.Bit1;
            set => Value.Bit1 = value;
        }

        public LargestMagnitudeElement LargestMagnitude
        {
            get => (LargestMagnitudeElement)((Value & LargestElementMask) >> LargestElementShift);
            set
            {
                // Clear the existing two bits for the largest magnitude
                Value = (byte)(Value & ~LargestElementMask);
                // Set the new value
                Value |= (byte)((int)value << LargestElementShift);
            }
        }

        public bool IsWNegative
        {
            get => Value.Bit5;
            set => Value.Bit5 = value;
        }

        public bool IsXNegative
        {
            get => Value.Bit4;
            set => Value.Bit4 = value;
        }

        public bool IsYNegative
        {
            get => Value.Bit3;
            set => Value.Bit3 = value;
        }

        public bool IsZNegative
        {
            get => Value.Bit2;
            set => Value.Bit2 = value;
        }

        public enum LargestMagnitudeElement
        {
            W = 0b00,
            X = 0b01,
            Y = 0b10,
            Z = 0b11
        }
    }
}