using HandySerialization.Extensions;

namespace HandySerialization.Tests
{
    [TestClass]
    public class ZigZagTests
    {
        [TestMethod]
        public void RoundTripInt16()
        {
            for (int i = short.MinValue; i <= short.MaxValue; i++)
            {
                var s = checked((short)i);
                Assert.AreEqual(s, s.ZigZag().DecodeZigZag());
            }
        }

        [TestMethod]
        public void RoundTripUInt16()
        {
            for (int i = ushort.MinValue; i <= ushort.MaxValue; i++)
            {
                var s = checked((ushort)i);
                Assert.AreEqual(s, s.UnsignedZigZagInterleave().DecodeUnsignedZigZagInterleave());
            }
        }

        [TestMethod]
        public void RoundTripInt32()
        {
            var rng = new Random(36345345);

            for (var i = 0; i < 5_000_000; i++)
            {
                var l = (int)(rng.NextInt64() & 0xFFFF_FFFF);
                Assert.AreEqual(l, l.ZigZag().DecodeZigZag());
            }
        }

        [TestMethod]
        public void RoundTripInt64()
        {
            var rng = new Random(36345345);

            for (var i = 0; i < 5_000_000; i++)
            {
                var l = rng.NextInt64();
                Assert.AreEqual(l, l.ZigZag().DecodeZigZag());
            }
        }
    }
}