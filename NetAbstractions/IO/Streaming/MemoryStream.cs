namespace ToolBX.NetAbstractions.IO.Streaming;

//TODO Implement
public interface IMemoryStream : IStream<MemoryStream>
{
    byte[] GetBuffer();
    TryGetResult<ArraySegment<byte>> TryGetBuffer();
    int Capacity { get; set; }
    byte[] ToArray();
    void WriteTo(IStream stream);
    void WriteTo(Stream stream);
}

public class MemoryStreamWrapper : StreamWrapper<MemoryStream>, IMemoryStream
{
    public int Capacity
    {
        get => Unwrapped.Capacity;
        set => Unwrapped.Capacity = value;
    }

    public MemoryStreamWrapper(MemoryStream stream) : base(stream)
    {
    }

    public byte[] GetBuffer() => Unwrapped.GetBuffer();

    public TryGetResult<ArraySegment<byte>> TryGetBuffer()
    {
        var isSuccess = Unwrapped.TryGetBuffer(out var buffer);
        return new TryGetResult<ArraySegment<byte>>(isSuccess, buffer);
    }

    public byte[] ToArray() => Unwrapped.ToArray();

    public void WriteTo(IStream stream) => WriteTo(stream.Unwrapped);

    public void WriteTo(Stream stream) => Unwrapped.WriteTo(stream);
}