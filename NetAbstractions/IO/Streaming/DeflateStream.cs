namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IDeflateStream : IStream<DeflateStream>
{
    IStream BaseStream { get; }
}

internal class DeflateStreamWrapper : StreamWrapper<DeflateStream>, IDeflateStream
{
    public IStream BaseStream => new StreamWrapper(Unwrapped.BaseStream);

    public DeflateStreamWrapper(Stream stream) : base(stream)
    {
    }

    public override IMemoryStream ToMemoryStream()
    {
        var memoryStream = new MemoryStreamWrapper(new MemoryStream());
        CopyTo(memoryStream);
        return memoryStream;
    }

    public override IFileStream ToFileStream(string path)
    {
        var filestream = new FileStreamWrapper(new FileStream(path, FileMode.Create));
        CopyTo(filestream);
        return filestream;
    }
}