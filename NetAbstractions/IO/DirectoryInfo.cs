namespace ToolBX.NetAbstractions.IO;

public interface IDirectoryInfo : IFileSystemInfo, IWrapper<DirectoryInfo>
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

internal class DirectoryInfoWrapper : Wrapper<DirectoryInfo>, IDirectoryInfo
{
    public DirectoryInfoWrapper(DirectoryInfo unwrapped) : base(unwrapped)
    {
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context) => Unwrapped.GetObjectData(info, context);

    public string FullName => Unwrapped.FullName;
    public string Extension => Unwrapped.Extension;
    public string Name => Unwrapped.Name;
    public bool Exists => Unwrapped.Exists;
    public void Delete() => DeleteNonRecursively();

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

    public IDirectoryInfo? Parent => Unwrapped.Parent == null ? null : new DirectoryInfoWrapper(Unwrapped.Parent);
    public IDirectoryInfo CreateSubdirectory(string path) => new DirectoryInfoWrapper(Unwrapped.CreateSubdirectory(path));

    public void Create() => Unwrapped.Create();

    public IEnumerable<IFileInfo> GetFiles() => Unwrapped.GetFiles().Select(x => new FileInfoWrapper(x));

    public IEnumerable<IFileInfo> GetFiles(string searchPattern) => Unwrapped.GetFiles(searchPattern).Select(x => new FileInfoWrapper(x)).Cast<IFileInfo>().ToArray();

    public IEnumerable<IFileInfo> GetFiles(string searchPattern, SearchOption searchOption) => Unwrapped.GetFiles(searchPattern, searchOption).Select(x => new FileInfoWrapper(x)).Cast<IFileInfo>().ToArray();

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

    public IEnumerable<IDirectoryInfo> GetDirectories() => Unwrapped.GetDirectories().Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern) => Unwrapped.GetDirectories(searchPattern).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern, SearchOption searchOption) => Unwrapped.GetDirectories(searchPattern, searchOption).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> EnumerateDirectories() => Unwrapped.EnumerateDirectories().Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern) => Unwrapped.EnumerateDirectories(searchPattern).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption) => Unwrapped.EnumerateDirectories(searchPattern, searchOption).Select(x => new DirectoryInfoWrapper(x));

    public IEnumerable<IFileInfo> EnumerateFiles() => Unwrapped.EnumerateFiles().Select(x => new FileInfoWrapper(x));

    public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern) => Unwrapped.EnumerateFiles(searchPattern).Select(x => new FileInfoWrapper(x));

    public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption) => Unwrapped.EnumerateFiles(searchPattern, searchOption).Select(x => new FileInfoWrapper(x));

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

    public IDirectoryInfo Root => new DirectoryInfoWrapper(Unwrapped.Root);

    public void MoveTo(string destDirName) => Unwrapped.MoveTo(destDirName);

    public void DeleteNonRecursively() => Unwrapped.Delete(false);

    public void DeleteRecursively() => Unwrapped.Delete(true);

}