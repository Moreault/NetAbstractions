namespace ToolBX.NetAbstractions.IO;

public interface ITextWriter : IDisposable, IWrapper<TextWriter>, IAsyncDisposable
{
    Encoding Encoding { get; }
    IFormatProvider FormatProvider { get; }
    string NewLine { get; set; }
    void Close();
    void Flush();
    Task FlushAsync();
    void Write(bool value);
    void Write(char value);
    void Write(char[] buffer);
    void Write(char[] buffer, int index, int count);
    void Write(decimal value);
    void Write(double value);
    void Write(int value);
    void Write(long value);
    void Write(object value);
    void Write(float value);
    void Write(string value);
    void Write(string format, params object[] arg);
    void Write(uint value);
    void Write(ulong value);
    Task WriteAsync(char value);
    Task WriteAsync(char[] buffer);
    Task WriteAsync(char[] buffer, int index, int count);
    Task WriteAsync(string value);
    void WriteLine();
    void WriteLine(bool value);
    void WriteLine(char value);
    void WriteLine(char[] buffer);
    void WriteLine(char[] buffer, int index, int count);
    void WriteLine(decimal value);
    void WriteLine(double value);
    void WriteLine(int value);
    void WriteLine(long value);
    void WriteLine(object value);
    void WriteLine(float value);
    void WriteLine(string value);
    void WriteLine(string format, params object[] arg);
    void WriteLine(uint value);
    void WriteLine(ulong value);
    Task WriteLineAsync();
    Task WriteLineAsync(char value);
    Task WriteLineAsync(char[] buffer);
    Task WriteLineAsync(char[] buffer, int index, int count);
    Task WriteLineAsync(string value);
}

public interface ITextWriter<out T> : ITextWriter where T : TextWriter
{
    new T Unwrapped { get; }
}

internal class TextWriterWrapper : Wrapper<TextWriter>, ITextWriter
{
    public TextWriterWrapper(TextWriter unwrapped) : base(unwrapped)
    {
    }

    public void Dispose() => Unwrapped.Dispose();

    public Encoding Encoding => Unwrapped.Encoding;
    public IFormatProvider FormatProvider => Unwrapped.FormatProvider;

    public string NewLine
    {
        get => Unwrapped.NewLine;
        set => Unwrapped.NewLine = value;
    }

    public void Close() => Unwrapped.Close();

    public void Flush() => Unwrapped.Flush();

    public Task FlushAsync() => Unwrapped.FlushAsync();

    public void Write(bool value) => Unwrapped.Write(value);

    public void Write(char value) => Unwrapped.Write(value);

    public void Write(char[] buffer) => Unwrapped.Write(buffer);

    public void Write(char[] buffer, int index, int count) => Unwrapped.Write(buffer, index, count);

    public void Write(decimal value) => Unwrapped.Write(value);

    public void Write(double value) => Unwrapped.Write(value);

    public void Write(int value) => Unwrapped.Write(value);

    public void Write(long value) => Unwrapped.Write(value);

    public void Write(object value) => Unwrapped.Write(value);

    public void Write(float value) => Unwrapped.Write(value);

    public void Write(string value) => Unwrapped.Write(value);

    public void Write(string format, params object[] arg) => Unwrapped.Write(format, arg);

    public void Write(uint value) => Unwrapped.Write(value);

    public void Write(ulong value) => Unwrapped.Write(value);

    public Task WriteAsync(char value) => Unwrapped.WriteAsync(value);

    public Task WriteAsync(char[] buffer) => Unwrapped.WriteAsync(buffer);

    public Task WriteAsync(char[] buffer, int index, int count) => Unwrapped.WriteAsync(buffer, index, count);

    public Task WriteAsync(string value) => Unwrapped.WriteAsync(value);

    public void WriteLine() => Unwrapped.WriteLine();

    public void WriteLine(bool value) => Unwrapped.WriteLine(value);

    public void WriteLine(char value) => Unwrapped.WriteLine(value);

    public void WriteLine(char[] buffer) => Unwrapped.WriteLine(buffer);

    public void WriteLine(char[] buffer, int index, int count) => Unwrapped.WriteLine(buffer, index, count);

    public void WriteLine(decimal value) => Unwrapped.WriteLine(value);

    public void WriteLine(double value) => Unwrapped.WriteLine(value);

    public void WriteLine(int value) => Unwrapped.WriteLine(value);

    public void WriteLine(long value) => Unwrapped.WriteLine(value);

    public void WriteLine(object value) => Unwrapped.WriteLine(value);

    public void WriteLine(float value) => Unwrapped.WriteLine(value);

    public void WriteLine(string value) => Unwrapped.WriteLine(value);

    public void WriteLine(string format, params object[] arg) => Unwrapped.WriteLine(format, arg);

    public void WriteLine(uint value) => Unwrapped.WriteLine(value);

    public void WriteLine(ulong value) => Unwrapped.WriteLine(value);

    public Task WriteLineAsync() => Unwrapped.WriteLineAsync();

    public Task WriteLineAsync(char value) => Unwrapped.WriteLineAsync(value);

    public Task WriteLineAsync(char[] buffer) => Unwrapped.WriteLineAsync(buffer);

    public Task WriteLineAsync(char[] buffer, int index, int count) => Unwrapped.WriteLineAsync(buffer, index, count);

    public Task WriteLineAsync(string value) => Unwrapped.WriteLineAsync(value);

    public ValueTask DisposeAsync() => Unwrapped.DisposeAsync();

    public T GetUnwrapped<T>() where T : TextWriter => (T)Unwrapped;
}

internal class TextWriterWrapper<T> : TextWriterWrapper, ITextWriter<T> where T : TextWriter
{
    public new T Unwrapped => GetUnwrapped<T>();

    public TextWriterWrapper(TextWriter textWriter) : base(textWriter)
    {
    }
}