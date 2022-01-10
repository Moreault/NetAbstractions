namespace ToolBX.NetAbstractions.IO;

public interface IDirectory
{
    IDirectoryInfo? GetParent(string path);
    IDirectoryInfo CreateDirectory(string path);
    IDirectoryInfo TryCreateDirectory(string path);
    bool Exists(string path);
    void SetCreationTime(string path, DateTime creationTime);
    void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
    DateTime GetCreationTime(string path);
    DateTime GetCreationTimeUtc(string path);
    void SetLastWriteTime(string path, DateTime lastWriteTime);
    void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    DateTime GetLastWriteTime(string path);
    DateTime GetLastWriteTimeUtc(string path);
    void SetLastAccessTime(string path, DateTime lastAccessTime);
    void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
    DateTime GetLastAccessTime(string path);
    DateTime GetLastAccessTimeUtc(string path);
    IList<string> GetFiles(string path);
    IList<string> GetFiles(string path, string searchPattern);
    IList<string> GetFiles(string path, string searchPattern, SearchOption searchOption);
    IList<string> GetDirectories(string path);
    IList<string> GetDirectories(string path, string searchPattern);
    IList<string> GetDirectories(string path, string searchPattern, SearchOption searchOption);
    IList<string> GetFileSystemEntries(string path);
    IList<string> GetFileSystemEntries(string path, string searchPattern);
    IList<string> GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
    IEnumerable<string> EnumerateDirectories(string path);
    IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
    IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);
    IEnumerable<string> EnumerateFiles(string path);
    IEnumerable<string> EnumerateFiles(string path, string searchPattern);
    IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
    IEnumerable<string> EnumerateFileSystemEntries(string path);
    IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
    IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
    string GetDirectoryRoot(string path);
    string GetCurrentDirectory();
    void SetCurrentDirectory(string path);
    void Move(string sourceDirName, string destDirName);
    void DeleteNonRecursively(string path);
    void DeleteRecursively(string path);
    IList<string> GetLogicalDrives();
}

[AutoInject]
public class DirectoryWrapper : IDirectory
{
    public IDirectoryInfo? GetParent(string path)
    {
        var parent = Directory.GetParent(path);
        return parent == null ? null : new DirectoryInfoWrapper(parent);
    }

    public IDirectoryInfo CreateDirectory(string path) => new DirectoryInfoWrapper(Directory.CreateDirectory(path));

    public IDirectoryInfo TryCreateDirectory(string path) => Exists(path) ? new DirectoryInfoWrapper(new DirectoryInfo(path)) : CreateDirectory(path);

    public bool Exists(string path) => Directory.Exists(path);

    public void SetCreationTime(string path, DateTime creationTime) => Directory.SetCreationTime(path, creationTime);

    public void SetCreationTimeUtc(string path, DateTime creationTimeUtc) => Directory.SetCreationTimeUtc(path, creationTimeUtc);

    public DateTime GetCreationTime(string path) => Directory.GetCreationTime(path);

    public DateTime GetCreationTimeUtc(string path) => Directory.GetCreationTimeUtc(path);

    public void SetLastWriteTime(string path, DateTime lastWriteTime) => Directory.SetLastWriteTime(path, lastWriteTime);

    public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) => Directory.SetLastAccessTimeUtc(path, lastWriteTimeUtc);

    public DateTime GetLastWriteTime(string path) => Directory.GetLastWriteTime(path);

    public DateTime GetLastWriteTimeUtc(string path) => Directory.GetLastWriteTimeUtc(path);

    public void SetLastAccessTime(string path, DateTime lastAccessTime) => Directory.SetLastAccessTime(path, lastAccessTime);

    public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) => Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc);

    public DateTime GetLastAccessTime(string path) => Directory.GetLastAccessTime(path);

    public DateTime GetLastAccessTimeUtc(string path) => Directory.GetLastAccessTimeUtc(path);

    public IList<string> GetFiles(string path) => Directory.GetFiles(path);

    public IList<string> GetFiles(string path, string searchPattern) => Directory.GetFiles(path, searchPattern);

    public IList<string> GetFiles(string path, string searchPattern, SearchOption searchOption) => Directory.GetFiles(path, searchPattern, searchOption);

    public IList<string> GetDirectories(string path) => Directory.GetDirectories(path);

    public IList<string> GetDirectories(string path, string searchPattern) => Directory.GetDirectories(path, searchPattern);

    public IList<string> GetDirectories(string path, string searchPattern, SearchOption searchOption) => Directory.GetDirectories(path, searchPattern, searchOption);

    public IList<string> GetFileSystemEntries(string path) => Directory.GetFileSystemEntries(path);

    public IList<string> GetFileSystemEntries(string path, string searchPattern) => Directory.GetFileSystemEntries(path, searchPattern);

    public IList<string> GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption) => Directory.GetFileSystemEntries(path, searchPattern, searchOption);

    public IEnumerable<string> EnumerateDirectories(string path) => Directory.EnumerateDirectories(path);

    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern) => Directory.EnumerateDirectories(path, searchPattern);

    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption) => Directory.EnumerateDirectories(path, searchPattern, searchOption);

    public IEnumerable<string> EnumerateFiles(string path) => Directory.EnumerateFiles(path);

    public IEnumerable<string> EnumerateFiles(string path, string searchPattern) => Directory.EnumerateFiles(path, searchPattern);

    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption) => Directory.EnumerateFiles(path, searchPattern, searchOption);

    public IEnumerable<string> EnumerateFileSystemEntries(string path) => Directory.EnumerateFileSystemEntries(path);

    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern) => Directory.EnumerateFileSystemEntries(path, searchPattern);

    public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption) => Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption);

    public string GetDirectoryRoot(string path) => Directory.GetDirectoryRoot(path);

    public string GetCurrentDirectory() => Directory.GetCurrentDirectory();

    public void SetCurrentDirectory(string path) => Directory.SetCurrentDirectory(path);

    public void Move(string sourceDirName, string destDirName) => Directory.Move(sourceDirName, destDirName);

    public void DeleteNonRecursively(string path) => Directory.Delete(path, false);

    public void DeleteRecursively(string path) => Directory.Delete(path, true);

    public IList<string> GetLogicalDrives() => Directory.GetLogicalDrives();
}