using HandySerialization.Extensions.Collections;

namespace HandySerialization.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void SerializeAndDeserializeEmptyList()
        {
            var serializer = new TestWriterReader();

            var input = new List<string>();
            serializer.Write(input, new StringAdapter());
            var output = serializer.ReadList<TestWriterReader, string, StringAdapter>(new StringAdapter());

            CollectionAssert.AreEqual(input, output);
        }

        [TestMethod]
        public void SerializeAndDeserializeNonEmptyList()
        {
            var serializer = new TestWriterReader();

            var input = new List<string> { "a", "b", "c" };
            serializer.Write(input, new StringAdapter());
            var output = serializer.ReadList<TestWriterReader, string, StringAdapter>(new StringAdapter());

            CollectionAssert.AreEqual(input, output);
        }

        [TestMethod]
        public void SerializeAndDeserializeIntoExistingList()
        {
            var serializer = new TestWriterReader();

            var input = new List<string> { "x", "y" };
            serializer.Write(input, new StringAdapter());

            var output = new List<string> { "existing" };
            serializer.ReadList(output, new StringAdapter());

            CollectionAssert.AreEqual(new List<string> { "existing", "x", "y" }, output);
        }

        [TestMethod]
        public void SerializeAndDeserializeNewAdapterOverload()
        {
            var serializer = new TestWriterReader();

            var input = new List<string> { "hello", "world" };
            serializer.Write(input, new StringAdapter());
            var output = serializer.ReadList<TestWriterReader, string, StringAdapter>();

            CollectionAssert.AreEqual(input, output);
        }
    }
}
