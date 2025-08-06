using System.Runtime.InteropServices;
using System.Text;
using HandySerialization.Extensions;

namespace HandySerialization.Tests
{
    [TestClass]
    public class PrimitiveTests
    {
        [TestMethod]
        public void RoundTripString()
        {
            var bytes = new byte[1024];
            var rng = new Random(49087);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var slice = bytes.AsSpan(0, rng.Next(0, bytes.Length));

                var str = Encoding.UTF8.GetString(slice);
                var serializer = new TestWriterReader();
                serializer.Write(str);
                var output = serializer.ReadString();

                Assert.AreEqual(str, output);
                Console.WriteLine(str);
            }
        }

        [TestMethod]
        public void RoundTripNullString()
        {
            var serializer = new TestWriterReader();

            serializer.Write((string?)null);
            Assert.AreEqual(null, serializer.ReadString());
        }

        [TestMethod]
        public void RoundTripEmptyString()
        {
            var serializer = new TestWriterReader();

            serializer.Write("");
            Assert.AreEqual("", serializer.ReadString());
        }

        [TestMethod]
        public void RoundTripBool8()
        {
            var rng = new Random(49087);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                var a = rng.NextSingle() > 0.5f;
                var b = rng.NextSingle() > 0.5f;
                var c = rng.NextSingle() > 0.5f;
                var d = rng.NextSingle() > 0.5f;
                var e = rng.NextSingle() > 0.5f;
                var f = rng.NextSingle() > 0.5f;
                var g = rng.NextSingle() > 0.5f;
                var h = rng.NextSingle() > 0.5f;

                var serializer = new TestWriterReader();
                serializer.Write(a, b, c, d, e, f, g, h);
                serializer.ReadBool(
                    out var aa,
                    out var bb,
                    out var cc,
                    out var dd,
                    out var ee,
                    out var ff,
                    out var gg,
                    out var hh
                );

                Assert.AreEqual(a, aa);
                Assert.AreEqual(b, bb);
                Assert.AreEqual(c, cc);
                Assert.AreEqual(d, dd);
                Assert.AreEqual(e, ee);
                Assert.AreEqual(f, ff);
                Assert.AreEqual(g, gg);
                Assert.AreEqual(h, hh);
            }
        }

        [TestMethod]
        public void RoundTripUInt8()
        {
            var bytes = new byte[1];
            var rng = new Random(568345);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);

                var serializer = new TestWriterReader();
                serializer.Write(bytes[0]);
                var output = serializer.ReadUInt8();

                Assert.AreEqual(bytes[0], output);
            }
        }

        [TestMethod]
        public void RoundTripInt8()
        {
            var bytes = new byte[1];
            var rng = new Random(758567);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var input = unchecked((sbyte)bytes[0]);

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadInt8();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripInt16()
        {
            var bytes = new byte[2];
            var rng = new Random(567245);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var input = MemoryMarshal.Cast<byte, short>(bytes)[0];

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadInt16();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripUInt16()
        {
            var bytes = new byte[2];
            var rng = new Random(55345);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var input = MemoryMarshal.Cast<byte, ushort>(bytes)[0];

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadUInt16();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripInt32()
        {
            var bytes = new byte[4];
            var rng = new Random(567546);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var input = MemoryMarshal.Cast<byte, int>(bytes)[0];

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadInt32();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripUInt32()
        {
            var bytes = new byte[4];
            var rng = new Random(745765345);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var input = MemoryMarshal.Cast<byte, uint>(bytes)[0];

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadUInt32();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripInt64()
        {
            var bytes = new byte[8];
            var rng = new Random(678356);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var input = MemoryMarshal.Cast<byte, long>(bytes)[0];

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadInt64();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripUInt64()
        {
            var bytes = new byte[8];
            var rng = new Random(56856);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                rng.NextBytes(bytes);
                var input = MemoryMarshal.Cast<byte, ulong>(bytes)[0];

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadUInt64();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripFloat64()
        {
            var rng = new Random(7568456);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                var input = rng.NextDouble();

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadFloat64();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripFloat32()
        {
            var rng = new Random(567456);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                var input = rng.NextSingle();

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadFloat32();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripTimeSpan()
        {
            var rng = new Random(34576235);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                var input = TimeSpan.FromTicks(rng.NextInt64());

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadTimeSpan();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripDateTime()
        {
            var rng = new Random(34576235);

            const int count = 100_000;
            for (var i = 0; i <= count; i++)
            {
                var dtk = (DateTimeKind)rng.Next(0, 3);
                var input = new DateTime(rng.NextInt64(DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks), dtk);

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadDateTime();

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripChar()
        {
            for (var i = 0; i <= (int)ushort.MaxValue; i++)
            {
                var input = (char)i;

                var serializer = new TestWriterReader();
                serializer.Write(input);
                var output = serializer.ReadChar();

                Assert.AreEqual(input, output);
            }
        }
    }
}