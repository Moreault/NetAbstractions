namespace ToolBX.NetAbstractions.IO;

public interface ITextWriter : IDisposable, IInstanceWrapper<TextWriter>, IAsyncDisposable
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

internal class TextWriterWrapper : ITextWriter
{
    public TextWriter Unwrapped { get; }

    public TextWriterWrapper(TextWriter textWriter)
    {
        Unwrapped = textWriter ?? throw new ArgumentNullException(nameof(textWriter));
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

    public async Task FlushAsync() => await Unwrapped.FlushAsync();

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

    public async Task WriteAsync(char value) => await Unwrapped.WriteAsync(value);

    public async Task WriteAsync(char[] buffer) => await Unwrapped.WriteAsync(buffer);

    public async Task WriteAsync(char[] buffer, int index, int count) => await Unwrapped.WriteAsync(buffer, index, count);

    public async Task WriteAsync(string value) => await Unwrapped.WriteAsync(value);

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

    public async Task WriteLineAsync() => await Unwrapped.WriteLineAsync();

    public async Task WriteLineAsync(char value) => await Unwrapped.WriteLineAsync(value);

    public async Task WriteLineAsync(char[] buffer) => await Unwrapped.WriteLineAsync(buffer);

    public async Task WriteLineAsync(char[] buffer, int index, int count) => await Unwrapped.WriteLineAsync(buffer, index, count);

    public async Task WriteLineAsync(string value) => await Unwrapped.WriteLineAsync(value);

    public bool Equals(ITextWriter? other) => Equals(other as TextWriterWrapper);

    public bool Equals(TextWriterWrapper? other) => other is not null && Unwrapped.Equals(other.Unwrapped);

    public bool Equals(TextWriter? other) => Unwrapped.Equals(other);

    public override bool Equals(object? obj)
    {
        if (obj is TextWriterWrapper wrapper) return Equals(wrapper);
        return Equals(obj as TextWriter);
    }

    public override int GetHashCode() => Unwrapped.GetHashCode();

    public ValueTask DisposeAsync() => Unwrapped.DisposeAsync();

    public static bool operator ==(TextWriterWrapper? a, TextWriterWrapper? b) => a is null && b is null || a is not null && a.Equals(b);

    public static bool operator !=(TextWriterWrapper? a, TextWriterWrapper? b) => !(a == b);

    public T GetUnwrapped<T>() where T : TextWriter => (T)Unwrapped;
}

internal class TextWriterWrapper<T> : TextWriterWrapper, ITextWriter<T> where T : TextWriter
{
    public new T Unwrapped => GetUnwrapped<T>();

    public TextWriterWrapper(TextWriter textWriter) : base(textWriter)
    {
    }
}