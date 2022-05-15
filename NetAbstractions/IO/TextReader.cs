namespace ToolBX.NetAbstractions.IO;

public interface ITextReader : IDisposable, IInstanceWrapper<TextReader>
{
    void Close();
    int Peek();
    int Read();
    int Read([In, Out] char[] buffer, int index, int count);
    string? ReadToEnd();

    int ReadBlock([In, Out] char[] buffer, int index, int count);
    string? ReadLine();

    [ComVisible(false)]
    Task<string?> ReadLineAsync();

    [ComVisible(false)]
    Task<string?> ReadToEndAsync();

    [ComVisible(false)]
    Task<int> ReadAsync(char[] buffer, int index, int count);

    [ComVisible(false)]
    Task<int> ReadBlockAsync(char[] buffer, int index, int count);
}

public interface ITextReader<out T> : ITextReader where T : TextReader
{
    new T Unwrapped { get; }
}

internal class TextReaderWrapper : ITextReader
{
    public TextReader Unwrapped { get; }

    public TextReaderWrapper(TextReader textReader)
    {
        Unwrapped = textReader ?? throw new ArgumentNullException(nameof(textReader));
    }

    public void Dispose() => Unwrapped.Dispose();

    public static explicit operator TextReader(TextReaderWrapper wrapper) => wrapper.Unwrapped;

    public static TextReader Unwrap(ITextReader wrapper) => (TextReader)(TextReaderWrapper)wrapper;

    public bool Equals(ITextReader? other) => other is not null && Equals(Unwrap(other));

    public bool Equals(TextReader? other) => Unwrapped.Equals(other);

    public override bool Equals(object? obj)
    {
        if (obj is TextReaderWrapper wrapper) return Equals(wrapper);
        return Equals(obj as TextReader);
    }

    public override int GetHashCode() => Unwrapped.GetHashCode();

    public static bool operator ==(TextReaderWrapper? a, TextReaderWrapper? b) => a is null && b is null || !(a is null) && a.Equals(b);

    public static bool operator !=(TextReaderWrapper? a, TextReaderWrapper? b) => !(a == b);

    public void Close() => Unwrapped.Close();

    public int Peek() => Unwrapped.Peek();

    public int Read() => Unwrapped.Read();

    public int Read(char[] buffer, int index, int count) => Unwrapped.Read(buffer, index, count);

    public string ReadToEnd() => Unwrapped.ReadToEnd();

    public int ReadBlock(char[] buffer, int index, int count) => Unwrapped.ReadBlock(buffer, index, count);

    public string? ReadLine() => Unwrapped.ReadLine();

    public async Task<string?> ReadLineAsync() => await Unwrapped.ReadLineAsync();

    public async Task<string?> ReadToEndAsync() => await Unwrapped.ReadToEndAsync();

    public async Task<int> ReadAsync(char[] buffer, int index, int count) => await Unwrapped.ReadAsync(buffer, index, count);

    public async Task<int> ReadBlockAsync(char[] buffer, int index, int count) => await Unwrapped.ReadBlockAsync(buffer, index, count);

    public T GetUnwrapped<T>() where T : TextReader => (T)Unwrapped;
}

internal class TextReader<T> : TextReaderWrapper, ITextReader<T> where T : TextReader
{
    public new T Unwrapped => GetUnwrapped<T>();

    public TextReader(TextReader unwrapped) : base(unwrapped)
    {
    }
}