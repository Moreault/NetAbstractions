﻿namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IStreamFactory
{
    IFileStream FileStream(SafeFileHandle handle, FileAccess access);
    IFileStream FileStream(SafeFileHandle handle, FileAccess access, int bufferSize);
    IFileStream FileStream(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync);
    IFileStream FileStream(string path, FileMode mode);
    IFileStream FileStream(string path, FileMode mode, FileAccess access);
    IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share);
    IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize);
    IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync);
    IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options);
    IFileStream FileStream(string path, FileStreamOptions options);

    IMemoryStream MemoryStream();
    IMemoryStream MemoryStream(int capacity);
    IMemoryStream MemoryStream(byte[] buffer);
    IMemoryStream MemoryStream(byte[] buffer, bool writable);
    IMemoryStream MemoryStream(byte[] buffer, int index, int count);
    IMemoryStream MemoryStream(byte[] buffer, int index, int count, bool writable);
    IMemoryStream MemoryStream(byte[] buffer, int index, int count, bool writable, bool publiclyVisible);
}

[AutoInject]
public class StreamFactory : IStreamFactory
{
    public IFileStream FileStream(SafeFileHandle handle, FileAccess access) => new FileStreamWrapper(new FileStream(handle, access));

    public IFileStream FileStream(SafeFileHandle handle, FileAccess access, int bufferSize) => new FileStreamWrapper(new FileStream(handle, access, bufferSize));

    public IFileStream FileStream(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync) => new FileStreamWrapper(new FileStream(handle, access, bufferSize, isAsync));

    public IFileStream FileStream(string path, FileMode mode) => new FileStreamWrapper(new FileStream(path, mode));

    public IFileStream FileStream(string path, FileMode mode, FileAccess access) => new FileStreamWrapper(new FileStream(path, mode, access));

    public IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share) => new FileStreamWrapper(new FileStream(path, mode, access, share));

    public IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize) => new FileStreamWrapper(new FileStream(path, mode, access, share, bufferSize));

    public IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync) => new FileStreamWrapper(new FileStream(path, mode, access, share, bufferSize, useAsync));

    public IFileStream FileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options) => new FileStreamWrapper(new FileStream(path, mode, access, share, bufferSize, options));

    public IFileStream FileStream(string path, FileStreamOptions options) => new FileStreamWrapper(new FileStream(path, options));

    public IMemoryStream MemoryStream() => new MemoryStreamWrapper(new MemoryStream());

    public IMemoryStream MemoryStream(int capacity) => new MemoryStreamWrapper(new MemoryStream(capacity));

    public IMemoryStream MemoryStream(byte[] buffer) => new MemoryStreamWrapper(new MemoryStream(buffer));

    public IMemoryStream MemoryStream(byte[] buffer, bool writable) => new MemoryStreamWrapper(new MemoryStream(buffer, writable));

    public IMemoryStream MemoryStream(byte[] buffer, int index, int count) => new MemoryStreamWrapper(new MemoryStream(buffer, index, count));

    public IMemoryStream MemoryStream(byte[] buffer, int index, int count, bool writable) => new MemoryStreamWrapper(new MemoryStream(buffer, index, count, writable));

    public IMemoryStream MemoryStream(byte[] buffer, int index, int count, bool writable, bool publiclyVisible) => new MemoryStreamWrapper(new MemoryStream(buffer, index, count, writable, publiclyVisible));
}