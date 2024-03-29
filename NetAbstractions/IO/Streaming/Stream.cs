﻿namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IStream : IDisposable, IWrapper<Stream>, IAsyncDisposable
{
    bool CanRead { get; }
    bool CanSeek { get; }
    bool CanTimeout { get; }
    bool CanWrite { get; }
    long Length { get; }
    long Position { get; set; }
    int ReadTimeout { get; set; }
    int WriteTimeout { get; set; }
    Task CopyToAsync(IStream destination);
    Task CopyToAsync(IStream destination, int bufferSize);
    Task CopyToAsync(IStream destination, int bufferSize, CancellationToken cancellationToken);
    void CopyTo(IStream destination);
    void CopyTo(IStream destination, int bufferSize);
    void Close();
    void Flush();
    Task FlushAsync();
    Task FlushAsync(CancellationToken cancellationToken);
    IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state);
    int EndRead(IAsyncResult asyncResult);
    Task<int> ReadAsync(byte[] buffer, int offset, int count);
    Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
    IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state);
    void EndWrite(IAsyncResult asyncResult);
    Task WriteAsync(byte[] buffer, int offset, int count);
    Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken);
    long Seek(long offset, SeekOrigin origin);
    void SetLength(long value);
    int Read([In, Out] byte[] buffer, int offset, int count);
    ReadResult Read(int offset, int count);
    int ReadByte();
    void Write(byte[] buffer, int offset, int count);
    void WriteByte(byte value);
    IMemoryStream ToMemoryStream();
    IFileStream ToFileStream(string path);
    byte[] ToArray();
}

public interface IStream<out T> : IStream where T : Stream
{
    new T Unwrapped { get; }
}

internal class StreamWrapper : Wrapper<Stream>, IStream
{
    public StreamWrapper(Stream unwrapped) : base(unwrapped)
    {
    }

    public bool CanRead => Unwrapped.CanRead;

    public bool CanSeek => Unwrapped.CanSeek;

    public bool CanTimeout => Unwrapped.CanTimeout;

    public bool CanWrite => Unwrapped.CanWrite;

    public long Length => Unwrapped.Length;

    public long Position
    {
        get => Unwrapped.Position;
        set => Unwrapped.Position = value;
    }

    public int ReadTimeout
    {
        get => Unwrapped.ReadTimeout;
        set => Unwrapped.ReadTimeout = value;
    }

    public int WriteTimeout
    {
        get => Unwrapped.WriteTimeout;
        set => Unwrapped.WriteTimeout = value;
    }

    public IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
    {
        return Unwrapped.BeginRead(buffer, offset, count, callback, state);
    }

    public IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
    {
        return Unwrapped.BeginWrite(buffer, offset, count, callback, state);
    }

    public void Close() => Unwrapped.Close();

    public void CopyTo(IStream destination) => Unwrapped.CopyTo(destination.Unwrapped);

    public void CopyTo(IStream destination, int bufferSize) => Unwrapped.CopyTo(destination.Unwrapped, bufferSize);

    public Task CopyToAsync(IStream destination) => Unwrapped.CopyToAsync(destination.Unwrapped);

    public Task CopyToAsync(IStream destination, int bufferSize) => Unwrapped.CopyToAsync(destination.Unwrapped, bufferSize);

    public Task CopyToAsync(IStream destination, int bufferSize, CancellationToken cancellationToken)
    {
        return Unwrapped.CopyToAsync(destination.Unwrapped, bufferSize, cancellationToken);
    }

    public void Dispose() => Unwrapped.Dispose();

    public int EndRead(IAsyncResult asyncResult) => Unwrapped.EndRead(asyncResult);

    public void EndWrite(IAsyncResult asyncResult) => Unwrapped.EndWrite(asyncResult);

    public void Flush() => Unwrapped.Flush();

    public Task FlushAsync() => Unwrapped.FlushAsync();

    public Task FlushAsync(CancellationToken cancellationToken) => Unwrapped.FlushAsync(cancellationToken);

    public int Read([In, Out] byte[] buffer, int offset, int count) => Unwrapped.Read(buffer, offset, count);

    public ReadResult Read(int offset, int count)
    {
        var value = new byte[count];
        var amount = Unwrapped.Read(value, offset, count);
        return new ReadResult
        {
            Count = amount,
            Value = value
        };
    }

    public Task<int> ReadAsync(byte[] buffer, int offset, int count) => Unwrapped.ReadAsync(buffer, offset, count);

    public Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => Unwrapped.ReadAsync(buffer, offset, count, cancellationToken);

    public int ReadByte() => Unwrapped.ReadByte();

    public long Seek(long offset, SeekOrigin origin) => Unwrapped.Seek(offset, origin);

    public void SetLength(long value) => Unwrapped.SetLength(value);

    public void Write(byte[] buffer, int offset, int count) => Unwrapped.Write(buffer, offset, count);

    public Task WriteAsync(byte[] buffer, int offset, int count) => Unwrapped.WriteAsync(buffer, offset, count);

    public Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) => Unwrapped.WriteAsync(buffer, offset, count, cancellationToken);

    public void WriteByte(byte value) => Unwrapped.WriteByte(value);

    public virtual IMemoryStream ToMemoryStream()
    {
        var memoryStream = new MemoryStreamWrapper(new MemoryStream());
        Seek(0, SeekOrigin.Begin);
        CopyTo(memoryStream);
        return memoryStream;
    }

    public virtual IFileStream ToFileStream(string path)
    {
        var filestream = new FileStreamWrapper(new FileStream(path, FileMode.Create));
        Seek(0, SeekOrigin.Begin);
        CopyTo(filestream);
        return filestream;
    }

    public virtual byte[] ToArray()
    {
        using var outstream = ToMemoryStream();
        return outstream.ToArray();
    }

    public ValueTask DisposeAsync() => Unwrapped.DisposeAsync();

    public T GetUnwrapped<T>() where T : Stream => (T)Unwrapped;
}

internal class StreamWrapper<T> : StreamWrapper, IStream<T> where T : Stream
{
    public new T Unwrapped => GetUnwrapped<T>();

    public StreamWrapper(Stream stream) : base(stream)
    {
    }
}