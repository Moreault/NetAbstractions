using System.Runtime.Serialization;

namespace ToolBX.NetAbstractions.IO;

public interface IFileInfo : IFileSystemInfo, IInstanceWrapper<FileInfo>
{
    long Length { get; }
    string? DirectoryName { get; }
    IDirectoryInfo? Directory { get; }
    bool IsReadOnly { get; set; }
    IStreamReader OpenText();
    StreamWriter CreateText();
    StreamWriter AppendText();
    IFileInfo CopyToWithoutOverwriting(string destFileName);
    IFileInfo CopyToAndOverwrite(string destFileName);
    IFileStream Create();
    IFileStream Open(FileMode mode);
    IFileStream Open(FileMode mode, FileAccess access);
    IFileStream Open(FileMode mode, FileAccess access, FileShare share);
    IFileStream OpenRead();
    IFileStream OpenWrite();
    void MoveTo(string destFileName);
    IFileInfo Replace(string destinationFileName, string destinationBackupFileName);
    IFileInfo ReplaceAndIgnoreMetadataErrors(string destinationFileName, string destinationBackupFileName);
}

public class FileInfoWrapper : IFileInfo
{
    public FileInfo Unwrapped { get; }

    public FileInfoWrapper(FileInfo file)
    {
        Unwrapped = file ?? throw new ArgumentNullException(nameof(file));
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context) => Unwrapped.GetObjectData(info, context);

    public string FullName => Unwrapped.FullName;
    public string Extension => Unwrapped.Extension;
    public string Name => Unwrapped.Name;
    public bool Exists => Unwrapped.Exists;
    public void Delete() => Unwrapped.Delete();

    public DateTime CreationTime
    {
        get => Unwrapped.CreationTime;
        set => Unwrapped.CreationTime = value;
    }

    public DateTime CreationTimeUtc
    {
        get => Unwrapped.CreationTimeUtc;
        set => Unwrapped.CreationTimeUtc = value;
    }

    public DateTime LastAccessTime
    {
        get => Unwrapped.LastAccessTime;
        set => Unwrapped.LastAccessTime = value;
    }

    public DateTime LastAccessTimeUtc
    {
        get => Unwrapped.LastAccessTimeUtc;
        set => Unwrapped.LastAccessTimeUtc = value;
    }

    public DateTime LastWriteTime
    {
        get => Unwrapped.LastWriteTime;
        set => Unwrapped.LastWriteTime = value;
    }

    public DateTime LastWriteTimeUtc
    {
        get => Unwrapped.LastWriteTimeUtc;
        set => Unwrapped.LastWriteTimeUtc = value;
    }

    public FileAttributes Attributes
    {
        get => Unwrapped.Attributes;
        set => Unwrapped.Attributes = value;
    }

    public void Refresh() => Unwrapped.Refresh();

    public long Length => Unwrapped.Length;
    public string? DirectoryName => Unwrapped.DirectoryName;
    public IDirectoryInfo? Directory
    {
        get
        {
            var directory = Unwrapped.Directory;
            return directory == null ? null : new DirectoryInfoWrapper(directory);
        }
    }

    public bool IsReadOnly
    {
        get => Unwrapped.IsReadOnly;
        set => Unwrapped.IsReadOnly = value;
    }

    public IStreamReader OpenText() => new StreamReaderWrapper(Unwrapped.OpenText());

    public StreamWriter CreateText() => Unwrapped.CreateText();

    public StreamWriter AppendText() => Unwrapped.AppendText();

    public IFileInfo CopyToWithoutOverwriting(string destFileName) => new FileInfoWrapper(Unwrapped.CopyTo(destFileName, false));

    public IFileInfo CopyToAndOverwrite(string destFileName) => new FileInfoWrapper(Unwrapped.CopyTo(destFileName, true));

    public IFileStream Create() => new FileStreamWrapper(Unwrapped.Create());

    public IFileStream Open(FileMode mode) => new FileStreamWrapper(Unwrapped.Open(mode));

    public IFileStream Open(FileMode mode, FileAccess access) => new FileStreamWrapper(Unwrapped.Open(mode, access));

    public IFileStream Open(FileMode mode, FileAccess access, FileShare share) => new FileStreamWrapper(Unwrapped.Open(mode, access, share));

    public IFileStream OpenRead() => new FileStreamWrapper(Unwrapped.OpenRead());

    public IFileStream OpenWrite() => new FileStreamWrapper(Unwrapped.OpenWrite());

    public void MoveTo(string destFileName) => Unwrapped.MoveTo(destFileName);

    public IFileInfo Replace(string destinationFileName, string destinationBackupFileName) => new FileInfoWrapper(Unwrapped.Replace(destinationFileName, destinationBackupFileName, false));

    public IFileInfo ReplaceAndIgnoreMetadataErrors(string destinationFileName, string destinationBackupFileName) => new FileInfoWrapper(Unwrapped.Replace(destinationFileName, destinationBackupFileName, true));

    public override string ToString() => Unwrapped.ToString();

    public bool Equals(FileInfo? other) => Unwrapped.Equals(other);

    public override bool Equals(object? obj) => Unwrapped.Equals(obj);

    protected bool Equals(FileInfoWrapper? other) => Equals(other as object);

    public override int GetHashCode() => Unwrapped.GetHashCode();

    public static bool operator ==(FileInfoWrapper? a, FileInfoWrapper? b) => a?.Equals(b) ?? b is null;

    public static bool operator !=(FileInfoWrapper? a, FileInfoWrapper? b) => !(a == b);
}