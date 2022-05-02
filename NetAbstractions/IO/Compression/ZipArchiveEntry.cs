namespace ToolBX.NetAbstractions.IO.Compression;

public interface IZipArchiveEntry : IInstanceWrapper<ZipArchiveEntry>
{
    IZipArchive Archive { get; }
    uint Crc32 { get; }
    long CompressedLength { get; }
    int ExternalAttributes { get; set; }
    string FullName { get; }
    DateTimeOffset LastWriteTime { get; set; }
    long Length { get; }
    string Name { get; }
    void Delete();
    IStream Open();
}

public class ZipArchiveEntryWrapper : IZipArchiveEntry
{
    public ZipArchiveEntry Unwrapped { get; }

    public IZipArchive Archive => _archive.Value;
    private readonly Lazy<IZipArchive> _archive;

    public uint Crc32 => Unwrapped.Crc32;
    public long CompressedLength => Unwrapped.CompressedLength;

    public int ExternalAttributes
    {
        get => Unwrapped.ExternalAttributes;
        set => Unwrapped.ExternalAttributes = value;
    }

    public string FullName => Unwrapped.FullName;

    public DateTimeOffset LastWriteTime
    {
        get => Unwrapped.LastWriteTime;
        set => Unwrapped.LastWriteTime = value;
    }
    public long Length => Unwrapped.Length;
    public string Name => Unwrapped.Name;

    public ZipArchiveEntryWrapper(ZipArchiveEntry unwrapped)
    {
        Unwrapped = unwrapped ?? throw new ArgumentNullException(nameof(unwrapped));
        _archive = new Lazy<IZipArchive>(() => new ZipArchiveWrapper(unwrapped.Archive));

    }

    public bool Equals(ZipArchiveEntry? other) => Unwrapped.Equals(other);

    public void Delete() => Unwrapped.Delete();

    public IStream Open() => new StreamWrapper(Unwrapped.Open());
}