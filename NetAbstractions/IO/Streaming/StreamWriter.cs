namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IStreamWriter : ITextWriter<StreamWriter>
{
    bool AutoFlush { get; set; }
    IStream BaseStream { get; }

    // prevent WriteSpan from bloating call sites
    void Write(ReadOnlySpan<char> buffer);

    // prevent WriteSpan from bloating call sites
    void WriteLine(ReadOnlySpan<char> value);

    void Write(string format, object arg0);
    void Write(string format, object arg0, object arg1);
    void Write(string format, object arg0, object arg1, object arg2);
    void WriteLine(string format, object arg0);
    void WriteLine(string format, object arg0, object arg1);
    void WriteLine(string format, object arg0, object arg1, object arg2);
    Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default);
    Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default);
    void Write(StringBuilder value);
    Task WriteAsync(StringBuilder value, CancellationToken cancellationToken);
    void WriteLine(StringBuilder value);
    Task WriteLineAsync(StringBuilder value, CancellationToken cancellationToken);
}

public class StreamWriterWrapper : TextWriterWrapper<StreamWriter>, IStreamWriter
{
    public bool AutoFlush
    {
        get => Unwrapped.AutoFlush;
        set => Unwrapped.AutoFlush = value;
    }

    public IStream BaseStream { get; }

    public StreamWriterWrapper(TextWriter textWriter) : base(textWriter)
    {
        BaseStream = new StreamWrapper(Unwrapped.BaseStream);
    }

    public void Write(ReadOnlySpan<char> buffer) => Unwrapped.Write(buffer);

    public void WriteLine(ReadOnlySpan<char> value) => Unwrapped.WriteLine(value);

    public void Write(string format, object arg0) => Unwrapped.Write(format, arg0);

    public void Write(string format, object arg0, object arg1) => Unwrapped.Write(format, arg0, arg1);

    public void Write(string format, object arg0, object arg1, object arg2) => Unwrapped.Write(format, arg0, arg1, arg2);

    public void WriteLine(string format, object arg0) => Unwrapped.WriteLine(format, arg0);

    public void WriteLine(string format, object arg0, object arg1) => Unwrapped.WriteLine(format, arg0, arg1);

    public void WriteLine(string format, object arg0, object arg1, object arg2) => Unwrapped.WriteLine(format, arg0, arg1, arg2);

    public Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default) => Unwrapped.WriteAsync(buffer, cancellationToken);

    public Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default) => Unwrapped.WriteLineAsync(buffer, cancellationToken);

    public void Write(StringBuilder value) => Unwrapped.Write(value);

    public Task WriteAsync(StringBuilder value, CancellationToken cancellationToken) => Unwrapped.WriteAsync(value, cancellationToken);

    public void WriteLine(StringBuilder value) => Unwrapped.WriteLine(value);

    public Task WriteLineAsync(StringBuilder value, CancellationToken cancellationToken) => Unwrapped.WriteLineAsync(value, cancellationToken);

    public override string? ToString() => Unwrapped.ToString();
}