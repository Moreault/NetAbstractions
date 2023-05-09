namespace ToolBX.NetAbstractions.IO.Streaming;

public readonly record struct ReadResult
{
    public required int Count { get; init; }

    public required byte[] Value
    {
        get => _value ?? Array.Empty<byte>();
        init => _value = value;
    }
    private readonly byte[] _value;
}