namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IStreamReader : ITextReader<StreamReader>
{
    IStream BaseStream { get; }
    Encoding CurrentEncoding { get; }
    bool EndOfStream { get; }
    void DiscardBufferedData();
}

public class StreamReaderWrapper : TextReader<StreamReader>, IStreamReader
{
    TextReader IInstanceWrapper<TextReader>.Unwrapped => Unwrapped;

    public StreamReaderWrapper(StreamReader streamReader) : base(streamReader)
    {

    }

    public IStream BaseStream => new StreamWrapper(Unwrapped.BaseStream);
    public Encoding CurrentEncoding => Unwrapped.CurrentEncoding;
    public bool EndOfStream => Unwrapped.EndOfStream;
    public void DiscardBufferedData() => Unwrapped.DiscardBufferedData();

    public override string? ToString() => Unwrapped.ToString();

    public bool Equals(IStreamReader? other) => Equals(other as StreamReaderWrapper);

    public override bool Equals(object? obj) => Unwrapped.Equals(obj);

    protected bool Equals(FileInfoWrapper? other) => Equals(other as object);

    public override int GetHashCode()
    {
        return Unwrapped.GetHashCode();
    }

    public static bool operator ==(StreamReaderWrapper? a, StreamReaderWrapper? b) => a?.Equals(b) ?? b is null;

    public static bool operator !=(StreamReaderWrapper? a, StreamReaderWrapper? b) => !(a == b);

    protected bool Equals(StreamReaderWrapper? other) => Equals(Unwrapped, other?.Unwrapped);
}