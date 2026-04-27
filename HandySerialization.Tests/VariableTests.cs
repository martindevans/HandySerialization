using HandySerialization.Extensions;
using HandySerialization.Adapters;

namespace HandySerialization.Tests
{
    [TestClass]
    public class VariableTests
    {
        [TestMethod]
        public void RoundTripVariableUInt64()
        {
            var rng = new Random(285646);

            const int count = 1_000_000;
            for (var i = 0; i < count; i++)
            {
                var serializer = new TestWriterReader();

                var input = unchecked((ulong)rng.NextInt64());    
                serializer.Write(new VarUInt64Adapter(), in input);
                var output = serializer.Read<TestWriterReader, VarUInt64Adapter, ulong>(new VarUInt64Adapter());

                Assert.AreEqual(input, output);
            }
        }

        [TestMethod]
        public void RoundTripVariableInt64()
        {
            var rng = new Random(285646);

            const int count = 1_000_000;
            for (var i = 0; i < count; i++)
            {
                var serializer = new TestWriterReader();

                var input = rng.NextInt64();
                serializer.WriteVariableInt64(input);
                var output = serializer.ReadVariableInt64();

                Assert.AreEqual(input, output);
            }
        }
    }
}