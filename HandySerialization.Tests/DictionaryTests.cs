using HandySerialization.Adapters;
using HandySerialization.Extensions.Collections;

namespace HandySerialization.Tests
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void SerializeAndDeserializeEmptyDictionary()
        {
            var serializer = new TestWriterReader();

            // ReSharper disable once CollectionNeverUpdated.Local
            var input = new Dictionary<string, string>();
            serializer.Write(input, new StringAdapter(), new StringAdapter());
            var output = serializer.ReadDictionary<TestWriterReader, string, StringAdapter, string, StringAdapter>();

            CollectionAssert.AreEqual(
                input.OrderBy(a => a.Key).ToArray(),
                output.OrderBy(a => a.Key).ToArray()
            );
        }

        [TestMethod]
        public void SerializeAndDeserializeDictionary()
        {
            var serializer = new TestWriterReader();

            var input = new Dictionary<string, string>()
            {
                { "a", "b" },
                { "c", "d" },
            };
            serializer.Write(input, new StringAdapter(), new StringAdapter());
            var output = serializer.ReadDictionary<TestWriterReader, string, StringAdapter, string, StringAdapter>();

            CollectionAssert.AreEqual(
                input.OrderBy(a => a.Key).ToArray(),
                output.OrderBy(a => a.Key).ToArray()
            );
        }
    }
}
