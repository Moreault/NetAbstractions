namespace ToolBX.NetAbstractions.IO;

public interface IDirectoryInfo : IFileSystemInfo
{
    IDirectoryInfo? Parent { get; }
    IDirectoryInfo CreateSubdirectory(string path);
    void Create();
    IEnumerable<IFileInfo> GetFiles();
    IEnumerable<IFileInfo> GetFiles(string searchPattern);
    IEnumerable<IFileInfo> GetFiles(string searchPattern, SearchOption searchOption);
    IEnumerable<IFileSystemInfo> GetFileSystemInfos();
    IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern);
    IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern, SearchOption searchOption);
    IEnumerable<IDirectoryInfo> GetDirectories();
    IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern);
    IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern, SearchOption searchOption);
    IEnumerable<IDirectoryInfo> EnumerateDirectories();
    IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern);
    IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption);
    IEnumerable<IFileInfo> EnumerateFiles();
    IEnumerable<IFileInfo> EnumerateFiles(string searchPattern);
    IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption);
    IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos();
    IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern);
    IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption);
    IDirectoryInfo Root { get; }
    void MoveTo(string destDirName);
    void DeleteNonRecursively();
    void DeleteRecursively();
}

internal class DirectoryInfoWrapper : IDirectoryInfo
{
    private readonly DirectoryInfo _directory;

    public DirectoryInfoWrapper(DirectoryInfo directory)
    {
        _directory = directory ?? throw new ArgumentNullException(nameof(directory));
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context) => _directory.GetObjectData(info, context);

    public string FullName => _directory.FullName;
    public string Extension => _directory.Extension;
    public string Name => _directory.Name;
    public bool Exists => _directory.Exists;
    public void Delete() => DeleteNonRecursively();

    public DateTime CreationTime
    {
        get => _directory.CreationTime;
        set => _directory.CreationTime = value;
    }
    public DateTime CreationTimeUtc
    {
        get => _directory.CreationTimeUtc;
        set => _directory.CreationTimeUtc = value;
    }
    public DateTime LastAccessTime
    {
        get => _directory.LastAccessTime;
        set => _directory.LastAccessTime = value;
    }
    public DateTime LastAccessTimeUtc
    {
        get => _directory.LastAccessTimeUtc;
        set => _directory.LastAccessTimeUtc = value;
    }
    public DateTime LastWriteTime
    {
        get => _directory.LastWriteTime;
        set => _directory.LastWriteTime = value;
    }
    public DateTime LastWriteTimeUtc
    {
        get => _directory.LastWriteTimeUtc;
        set => _directory.LastWriteTimeUtc = value;
    }
    public FileAttributes Attributes
    {
        get => _directory.Attributes;
        set => _directory.Attributes = value;
    }

    public void Refresh() => _directory.Refresh();

    public IDirectoryInfo? Parent => _directory.Parent == null ? null : new DirectoryInfoWrapper(_directory.Parent);
    public IDirectoryInfo CreateSubdirectory(string path) => new DirectoryInfoWrapper(_directory.CreateSubdirectory(path));

    public void Create() => _directory.Create();

    public IEnumerable<IFileInfo> GetFiles() => _directory.GetFiles().Select(x => new FileInfoWrapper(x));

    public IEnumerable<IFileInfo> GetFiles(string searchPattern) => _directory.GetFiles(searchPattern).Select(x => new FileInfoWrapper(x)).Cast<IFileInfo>().ToArray();

    public IEnumerable<IFileInfo> GetFiles(string searchPattern, SearchOption searchOption) => _directory.GetFiles(searchPattern, searchOption).Select(x => new FileInfoWrapper(x)).Cast<IFileInfo>().ToArray();

    public IEnumerable<IFileSystemInfo> GetFileSystemInfos()
    {
        var output = new List<IFileSystemInfo>();
        output.AddRange(GetFiles());
        output.AddRange(GetDirectories());
        return output;
    }

    public IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern)
    {
        var output = new List<IFileSystemInfo>();
        output.AddRange(GetFiles(searchPattern));
        output.AddRange(GetDirectories(searchPattern));
        return output;
    }

    public IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern, SearchOption searchOption)
    {
        var output = new List<IFileSystemInfo>();
        output.AddRange(GetFiles(searchPattern, searchOption));
        output.AddRange(GetDirectories(searchPattern, searchOption));
        return output;
    }

    public IEnumerable<IDirectoryInfo> GetDirectories() => _directory.GetDirectories().Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern) => _directory.GetDirectories(searchPattern).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern, SearchOption searchOption) => _directory.GetDirectories(searchPattern, searchOption).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> EnumerateDirectories() => _directory.EnumerateDirectories().Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern) => _directory.EnumerateDirectories(searchPattern).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption) => _directory.EnumerateDirectories(searchPattern, searchOption).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IFileInfo> EnumerateFiles() => _directory.EnumerateFiles().Select(x => new FileInfoWrapper(x));

    public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern) => _directory.EnumerateFiles(searchPattern).Select(x => new FileInfoWrapper(x));

    public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption) => _directory.EnumerateFiles(searchPattern, searchOption).Select(x => new FileInfoWrapper(x));

    public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos()
    {
        var output = new List<IFileSystemInfo>();
        output.AddRange(EnumerateFiles());
        output.AddRange(EnumerateDirectories());
        return output;
    }

    public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern)
    {
        var output = new List<IFileSystemInfo>();
        output.AddRange(EnumerateFiles(searchPattern));
        output.AddRange(EnumerateDirectories(searchPattern));
        return output;
    }

    public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
    {
        var output = new List<IFileSystemInfo>();
        output.AddRange(EnumerateFiles(searchPattern, searchOption));
        output.AddRange(EnumerateDirectories(searchPattern, searchOption));
        return output;
    }

    public IDirectoryInfo Root => new DirectoryInfoWrapper(_directory.Root);

    public void MoveTo(string destDirName) => _directory.MoveTo(destDirName);

    public void DeleteNonRecursively() => _directory.Delete(false);

    public void DeleteRecursively() => _directory.Delete(true);

    public override string ToString() => _directory.ToString();

    public override bool Equals(object? obj) => _directory.Equals(obj);

    protected bool Equals(DirectoryInfoWrapper? other) => Equals(other as object);

    public static bool operator ==(DirectoryInfoWrapper? a, DirectoryInfoWrapper? b) => a?.Equals(b) ?? b is null;

    public static bool operator !=(DirectoryInfoWrapper? a, DirectoryInfoWrapper? b) => !(a == b);

    public override int GetHashCode() => _directory.GetHashCode();

    public static implicit operator DirectoryInfo(DirectoryInfoWrapper directoryInfo) => directoryInfo._directory;
}