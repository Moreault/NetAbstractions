namespace ToolBX.NetAbstractions.IO;

public interface ITextReader : IDisposable, IWrapper<TextReader>
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

internal class TextReaderWrapper : Wrapper<TextReader>, ITextReader
{
    public TextReaderWrapper(TextReader unwrapped) : base(unwrapped)
    {
    }

    public void Dispose() => Unwrapped.Dispose();

    public void Close() => Unwrapped.Close();

    public int Peek() => Unwrapped.Peek();

    public int Read() => Unwrapped.Read();

    public int Read(char[] buffer, int index, int count) => Unwrapped.Read(buffer, index, count);

    public string ReadToEnd() => Unwrapped.ReadToEnd();

    public int ReadBlock(char[] buffer, int index, int count) => Unwrapped.ReadBlock(buffer, index, count);

    public string? ReadLine() => Unwrapped.ReadLine();

    public Task<string?> ReadLineAsync() => Unwrapped.ReadLineAsync();

    public async Task<string?> ReadToEndAsync() => await Unwrapped.ReadToEndAsync();

    public Task<int> ReadAsync(char[] buffer, int index, int count) => Unwrapped.ReadAsync(buffer, index, count);

    public Task<int> ReadBlockAsync(char[] buffer, int index, int count) => Unwrapped.ReadBlockAsync(buffer, index, count);

    public T GetUnwrapped<T>() where T : TextReader => (T)Unwrapped;
}

internal class TextReader<T> : TextReaderWrapper, ITextReader<T> where T : TextReader
{
    public new T Unwrapped => GetUnwrapped<T>();

    public TextReader(TextReader unwrapped) : base(unwrapped)
    {
    }
}