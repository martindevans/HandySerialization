namespace HandySerialization;

public interface IByteReader
{
    /// <summary>
    /// Get how many unread bytes there are
    /// </summary>
    public long UnreadBytes { get; }

    /// <summary>
    /// Read some bytes
    /// </summary>
    /// <param name="dest"></param>
    public void ReadBytes(Span<byte> dest);
}