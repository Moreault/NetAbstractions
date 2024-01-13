namespace ToolBX.NetAbstractions.IO.Streaming;

public interface IStreamReader : ITextReader<StreamReader>
{
    IStream BaseStream { get; }
    Encoding CurrentEncoding { get; }
    bool EndOfStream { get; }
    void DiscardBufferedData();
}

internal class StreamReaderWrapper : TextReader<StreamReader>, IStreamReader
{
    TextReader IWrapper<TextReader>.Unwrapped => Unwrapped;

    public StreamReaderWrapper(StreamReader streamReader) : base(streamReader)
    {

    }

    public IStream BaseStream => new StreamWrapper(Unwrapped.BaseStream);
    public Encoding CurrentEncoding => Unwrapped.CurrentEncoding;
    public bool EndOfStream => Unwrapped.EndOfStream;
    public void DiscardBufferedData() => Unwrapped.DiscardBufferedData();
}