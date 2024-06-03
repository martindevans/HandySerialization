namespace HandySerialization;

public interface IByteReader
{
    /// <summary>
    /// Get how many unread bytes there are
    /// </summary>
    public int UnreadBytes { get; }

    /// <summary>
    /// Read some bytes
    /// </summary>
    /// <param name="dest"></param>
    public void ReadBytes(Span<byte> dest);
}