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
        public void RoundTripByte8()
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
    }
}