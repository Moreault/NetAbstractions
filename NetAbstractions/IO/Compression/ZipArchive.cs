namespace ToolBX.NetAbstractions.IO.Compression;

public interface IZipArchive : IInstanceWrapper<ZipArchive>, IDisposable
{
    /// <summary>
    /// The collection of entries that are currently in the ZipArchive. This may not accurately represent the actual entries that are present in the underlying file or stream.
    /// </summary>
    /// <exception cref="NotSupportedException">The ZipArchive does not support reading.</exception>
    /// <exception cref="ObjectDisposedException">The ZipArchive has already been closed.</exception>
    /// <exception cref="InvalidDataException">The Zip archive is corrupt and the entries cannot be retrieved.</exception>
    IReadOnlyCollection<IZipArchiveEntry> Entries { get; }

    /// <summary>
    /// The ZipArchiveMode that the ZipArchive was initialized with.
    /// </summary>
    ZipArchiveMode Mode { get; }

    /// <summary>
    /// Creates an empty entry in the Zip archive with the specified entry name.
    /// There are no restrictions on the names of entries.
    /// The last write time of the entry is set to the current time.
    /// If an entry with the specified name already exists in the archive, a second entry will be created that has an identical name.
    /// Since no <code>CompressionLevel</code> is specified, the default provided by the implementation of the underlying compression
    /// algorithm will be used; the <code>ZipArchive</code> will not impose its own default.
    /// (Currently, the underlying compression algorithm is provided by the <code>System.IO.Compression.DeflateStream</code> class.)
    /// </summary>
    /// <exception cref="ArgumentException">entryName is a zero-length string.</exception>
    /// <exception cref="ArgumentNullException">entryName is null.</exception>
    /// <exception cref="NotSupportedException">The ZipArchive does not support writing.</exception>
    /// <exception cref="ObjectDisposedException">The ZipArchive has already been closed.</exception>
    /// <param name="entryName">A path relative to the root of the archive, indicating the name of the entry to be created.</param>
    /// <returns>A wrapper for the newly created file entry in the archive.</returns>
    IZipArchiveEntry CreateEntry(string entryName);

    /// <summary>
    /// Creates an empty entry in the Zip archive with the specified entry name. There are no restrictions on the names of entries. The last write time of the entry is set to the current time. If an entry with the specified name already exists in the archive, a second entry will be created that has an identical name.
    /// </summary>
    /// <exception cref="ArgumentException">entryName is a zero-length string.</exception>
    /// <exception cref="ArgumentNullException">entryName is null.</exception>
    /// <exception cref="NotSupportedException">The ZipArchive does not support writing.</exception>
    /// <exception cref="ObjectDisposedException">The ZipArchive has already been closed.</exception>
    /// <param name="entryName">A path relative to the root of the archive, indicating the name of the entry to be created.</param>
    /// <param name="compressionLevel">The level of the compression (speed/memory vs. compressed size trade-off).</param>
    /// <returns>A wrapper for the newly created file entry in the archive.</returns>
    IZipArchiveEntry CreateEntry(string entryName, CompressionLevel compressionLevel);

    /// <summary>
    /// Retrieves a wrapper for the file entry in the archive with the specified name. Names are compared using ordinal comparison. If there are multiple entries in the archive with the specified name, the first one found will be returned.
    /// </summary>
    /// <exception cref="ArgumentException">entryName is a zero-length string.</exception>
    /// <exception cref="ArgumentNullException">entryName is null.</exception>
    /// <exception cref="NotSupportedException">The ZipArchive does not support reading.</exception>
    /// <exception cref="ObjectDisposedException">The ZipArchive has already been closed.</exception>
    /// <exception cref="InvalidDataException">The Zip archive is corrupt and the entries cannot be retrieved.</exception>
    /// <param name="entryName">A path relative to the root of the archive, identifying the desired entry.</param>
    /// <returns>A wrapper for the file entry in the archive. If no entry in the archive exists with the specified name, null will be returned.</returns>
    IZipArchiveEntry? GetEntry(string entryName);
}

public class ZipArchiveWrapper : IZipArchive
{
    public ZipArchive Unwrapped { get; }
    public IReadOnlyCollection<IZipArchiveEntry> Entries => _entries.Value;
    private readonly Lazy<IReadOnlyCollection<IZipArchiveEntry>> _entries;
    public ZipArchiveMode Mode => Unwrapped.Mode;

    public ZipArchiveWrapper(ZipArchive unwrapped)
    {
        Unwrapped = unwrapped ?? throw new ArgumentNullException(nameof(unwrapped));
        _entries = new Lazy<IReadOnlyCollection<IZipArchiveEntry>>(() => Unwrapped.Entries.Select(x => new ZipArchiveEntryWrapper(x)).ToList());
    }

    public bool Equals(ZipArchive? other) => Unwrapped.Equals(other);

    public bool Equals(ZipArchiveWrapper? other) => Unwrapped.Equals(other?.Unwrapped);

    public static bool operator ==(ZipArchiveWrapper? a, ZipArchiveWrapper? b) => a is null && b is null || a is not null && a.Equals(b);

    public static bool operator !=(ZipArchiveWrapper? a, ZipArchiveWrapper? b) => !(a == b);

    public override string? ToString() => Unwrapped.ToString();

    public IZipArchiveEntry CreateEntry(string entryName)
    {
        var entry = Unwrapped.CreateEntry(entryName);
        return new ZipArchiveEntryWrapper(entry);
    }

    public IZipArchiveEntry CreateEntry(string entryName, CompressionLevel compressionLevel)
    {
        var entry = Unwrapped.CreateEntry(entryName, compressionLevel);
        return new ZipArchiveEntryWrapper(entry);
    }

    public void Dispose() => Unwrapped.Dispose();

    public override bool Equals(object? obj) => Unwrapped.Equals(obj);

    public override int GetHashCode() => Unwrapped.GetHashCode();

    public IZipArchiveEntry? GetEntry(string entryName)
    {
        var entry = Unwrapped.GetEntry(entryName);
        return entry == null ? null : new ZipArchiveEntryWrapper(entry);
    }
}