namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IDeflateStream : IStream<DeflateStream>
{
    IStream BaseStream { get; }
}

public class DeflateStreamWrapper : StreamWrapper<DeflateStream>, IDeflateStream
{
    public IStream BaseStream => new StreamWrapper(Unwrapped.BaseStream);

    public DeflateStreamWrapper(Stream stream) : base(stream)
    {
    }
}