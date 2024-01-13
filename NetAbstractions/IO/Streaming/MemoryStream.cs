namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IMemoryStream : IStream<MemoryStream>
{
    byte[] GetBuffer();
    Result<ArraySegment<byte>> TryGetBuffer();
    int Capacity { get; set; }
    void WriteTo(IStream stream);
    void WriteTo(Stream stream);
}

internal class MemoryStreamWrapper : StreamWrapper<MemoryStream>, IMemoryStream
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

    public Result<ArraySegment<byte>> TryGetBuffer()
    {
        var isSuccess = Unwrapped.TryGetBuffer(out var buffer);
        return isSuccess ? Result<ArraySegment<byte>>.Success(buffer) :Result<ArraySegment<byte>>.Failure();
    }

    public override byte[] ToArray() => Unwrapped.ToArray();

    public void WriteTo(IStream stream) => WriteTo(stream.Unwrapped);

    public void WriteTo(Stream stream) => Unwrapped.WriteTo(stream);
}