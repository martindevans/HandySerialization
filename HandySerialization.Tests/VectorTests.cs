using HandySerialization.Extensions;
using System.Numerics;
using HandySerialization.Extensions.Lossy;

namespace HandySerialization.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void NormalizedVector3RoundTrip()
        {
            var rng = new Random(3572456);

            var worst = 100f;

            for (var i = 0; i < 10000; i++)
            {
                var serializer = new TestWriterReader();

                var vin = Vector3.Normalize(new Vector3(rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1));
                serializer.WriteNormalizedVector3(vin.X, vin.Y, vin.Z);
                serializer.ReadNormalizedVector3(out var ox, out var oy, out var oz);
                var vout = new Vector3(ox, oy, oz);

                var dot = Vector3.Dot(vin, vout);
                worst = Math.Min(worst, dot);

                if (float.IsNaN(dot))
                    Assert.Fail();
            }

            var angle = float.RadiansToDegrees(MathF.Acos(worst));
            Console.WriteLine($"Worst case = {worst} ({angle} degrees)");

            Assert.IsTrue(angle < 0.05f);
        }

        [TestMethod]
        public void NormalizedVector2RoundTrip()
        {
            var rng = new Random(3572456);

            var worst = 100f;

            for (var i = 0; i < 10000; i++)
            {
                var serializer = new TestWriterReader();

                var vin = Vector2.Normalize(new Vector2(rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1));
                serializer.WriteNormalizedVector2(vin.X, vin.Y);
                serializer.ReadNormalizedVector2(out var ox, out var oy);
                var vout = new Vector2(ox, oy);

                var dot = Vector2.Dot(vin, vout);
                worst = Math.Min(worst, dot);

                if (float.IsNaN(dot))
                    Assert.Fail();

                if (dot < 0.95)
                    Assert.Fail();
            }

            var angle = float.RadiansToDegrees(MathF.Acos(worst));
            Console.WriteLine($"Worst case = {worst} ({angle} degrees)");

            Assert.IsTrue(angle < 0.03f);
        }

        [TestMethod]
        public void CompressedQuaternionRoundTripIdentity()
        {
            // Check that the identity quaternion is perfectly round tripped.

            var qin = Quaternion.Identity;
            var serializer = new TestWriterReader();
            serializer.WriteCompressedQuaternion(qin);
            var qout = serializer.ReadCompressedQuaternion();

            Assert.AreEqual(qin, qout);
        }

        [TestMethod]
        public void CompressedQuaternionRoundTrip()
        {
            var rng = new Random(3572456);

            var count = 1_000_000;
            var worst = 100f;
            var accumulator = 0.0;
            for (var i = 0; i < count; i++)
            {
                var serializer = new TestWriterReader();

                var axis = Vector3.Normalize(new Vector3(rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1));
                var angle = rng.NextSingle() * (float)Math.PI * 2;
                var qin = Quaternion.CreateFromAxisAngle(axis, angle);

                serializer.WriteCompressedQuaternion(qin);
                var qout = serializer.ReadCompressedQuaternion();
                Assert.AreEqual(0, serializer.UnreadBytes);

                var dot = Quaternion.Dot(qin, qout);
                worst = Math.Min(worst, dot);
                accumulator += Math.Abs(dot);

                if (float.IsNaN(dot))
                    Assert.Fail();
            }

            var errAngle = float.RadiansToDegrees(MathF.Acos(worst));
            Console.WriteLine($"Worst case = {worst} ({errAngle} degrees)");

            var avgDot = Math.Clamp(accumulator / count, 0, 1);
            var avgAngle = double.RadiansToDegrees(Math.Acos(avgDot));
            Console.WriteLine($"Average case case = {avgAngle} degrees");

            Assert.IsTrue(errAngle < 0.05f);
        }

        [TestMethod]
        public void QuaternionRoundTrip()
        {
            var rng = new Random(3572456);

            const int count = 1_000_000;
            for (var i = 0; i < count; i++)
            {
                var serializer = new TestWriterReader();

                var axis = Vector3.Normalize(new Vector3(rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1));
                var angle = rng.NextSingle() * (float)Math.PI * 2;
                var qin = Quaternion.CreateFromAxisAngle(axis, angle);

                serializer.Write(qin);
                Console.WriteLine(serializer.UnreadBytes);
                var qout = serializer.ReadQuaternion();
                Assert.AreEqual(0, serializer.UnreadBytes);

                Assert.AreEqual(qin, qout);
            }
        }

        [TestMethod]
        public void MatrixRoundTrip()
        {
            var rng = new Random(5683456);

            const int count = 1_000_000;
            for (var i = 0; i < count; i++)
            {
                var serializer = new TestWriterReader();

                var axis = Vector3.Normalize(new Vector3(rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1, rng.NextSingle() * 2 - 1));
                var angle = rng.NextSingle() * (float)Math.PI * 2;
                var min = Matrix4x4.CreateFromQuaternion(Quaternion.CreateFromAxisAngle(axis, angle))
                    * Matrix4x4.CreateTranslation(rng.NextSingle() * 1, rng.NextSingle() * 1, rng.NextSingle() * 1);

                serializer.Write(min);
                Console.WriteLine(serializer.UnreadBytes);
                var mout = serializer.ReadMatrix4x4();
                Assert.AreEqual(0, serializer.UnreadBytes);

                Assert.AreEqual(min, mout);
            }
        }
    }
}