namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IFileStream : IStream<FileStream>
{
    bool IsAsync { get; }
    string Name { get; }
    SafeFileHandle SafeFileHandle { get; }
    void FlushAllIntermediateBuffers();

    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("macos")]
    [UnsupportedOSPlatform("tvos")]
    void Lock(long position, long length);

    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("macos")]
    [UnsupportedOSPlatform("tvos")]
    void Unlock(long position, long length);
}

public class FileStreamWrapper : StreamWrapper<FileStream>, IFileStream
{
    public bool IsAsync => Unwrapped.IsAsync;
    public string Name => Unwrapped.Name;
    public SafeFileHandle SafeFileHandle => Unwrapped.SafeFileHandle;

    public FileStreamWrapper(FileStream stream) : base(stream)
    {
    }

    public void FlushAllIntermediateBuffers() => Unwrapped.Flush(true);

    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("macos")]
    [UnsupportedOSPlatform("tvos")]
    public void Lock(long position, long length) => Unwrapped.Lock(position, length);

    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("macos")]
    [UnsupportedOSPlatform("tvos")]
    public void Unlock(long position, long length) => Unwrapped.Unlock(position, length);
}