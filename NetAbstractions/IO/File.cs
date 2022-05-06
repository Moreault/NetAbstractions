namespace ToolBX.NetAbstractions.IO;

public interface IFile
{
    IStreamReader OpenText(string path);
    IStreamWriter CreateText(string path);
    IStreamWriter AppendText(string path);
    void CopyWithoutOverwriting(string sourceFileName, string destFileName);
    void CopyAndOverwrite(string sourceFileName, string destFileName);
    IFileStream Create(string path);
    IFileStream Create(string path, int bufferSize);
    IFileStream Create(string path, int bufferSize, FileOptions options);
    void Delete(string path);
    bool Exists(string path);
    IFileStream Open(string path, FileMode mode);
    IFileStream Open(string path, FileMode mode, FileAccess access);
    IFileStream Open(string path, FileMode mode, FileAccess access, FileShare share);
    void SetCreationTime(string path, DateTime creationTime);
    void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
    DateTime GetCreationTime(string path);
    DateTime GetCreationTimeUtc(string path);
    void SetLastAccessTime(string path, DateTime lastAccessTime);
    void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
    DateTime GetLastAccessTime(string path);
    DateTime GetLastAccessTimeUtc(string path);
    void SetLastWriteTime(string path, DateTime lastWriteTime);
    void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    DateTime GetLastWriteTime(string path);
    DateTime GetLastWriteTimeUtc(string path);
    FileAttributes GetAttributes(string path);
    void SetAttributes(string path, FileAttributes fileAttributes);
    IFileStream OpenRead(string path);
    IFileStream OpenWrite(string path);
    string ReadAllText(string path);
    string ReadAllText(string path, Encoding encoding);
    void WriteAllText(string path, string contents);
    void WriteAllText(string path, string contents, Encoding encoding);
    byte[] ReadAllBytes(string path);
    void WriteAllBytes(string path, byte[] bytes);
    IReadOnlyList<string> ReadAllLines(string path);
    IReadOnlyList<string> ReadAllLines(string path, Encoding encoding);
    IEnumerable<string> ReadLines(string path);
    IEnumerable<string> ReadLines(string path, Encoding encoding);
    void WriteAllLines(string path, IList<string> contents);
    void WriteAllLines(string path, IEnumerable<string> contents);
    void WriteAllLines(string path, IList<string> contents, Encoding encoding);
    void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
    void AppendAllText(string path, string contents);
    void AppendAllText(string path, string contents, Encoding encoding);
    void AppendAllLines(string path, IEnumerable<string> contents);
    void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
    void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName);
    void ReplaceAndIgnoreMetadataErrors(string sourceFileName, string destinationFileName, string destinationBackupFileName);
    void Move(string sourceFileName, string destFileName);
}

[AutoInject]
public class FileWrapper : IFile
{
    public IStreamReader OpenText(string path) => new StreamReaderWrapper(File.OpenText(path));

    public IStreamWriter CreateText(string path) => new StreamWriterWrapper(File.CreateText(path));

    public IStreamWriter AppendText(string path) => new StreamWriterWrapper(File.AppendText(path));

    public void CopyWithoutOverwriting(string sourceFileName, string destFileName) => File.Copy(sourceFileName, destFileName, false);

    public void CopyAndOverwrite(string sourceFileName, string destFileName) => File.Copy(sourceFileName, destFileName, true);

    public IFileStream Create(string path) => new FileStreamWrapper(File.Create(path));

    public IFileStream Create(string path, int bufferSize) => new FileStreamWrapper(File.Create(path, bufferSize));

    public IFileStream Create(string path, int bufferSize, FileOptions options) => new FileStreamWrapper(File.Create(path, bufferSize, options));

    public void Delete(string path) => File.Delete(path);

    public bool Exists(string path) => File.Exists(path);

    public IFileStream Open(string path, FileMode mode) => new FileStreamWrapper(File.Open(path, mode));

    public IFileStream Open(string path, FileMode mode, FileAccess access) => new FileStreamWrapper(File.Open(path, mode, access));

    public IFileStream Open(string path, FileMode mode, FileAccess access, FileShare share) => new FileStreamWrapper(File.Open(path, mode, access, share));

    public void SetCreationTime(string path, DateTime creationTime) => File.SetCreationTime(path, creationTime);

    public void SetCreationTimeUtc(string path, DateTime creationTimeUtc) => File.SetCreationTimeUtc(path, creationTimeUtc);

    public DateTime GetCreationTime(string path) => File.GetCreationTime(path);

    public DateTime GetCreationTimeUtc(string path) => File.GetCreationTimeUtc(path);

    public void SetLastAccessTime(string path, DateTime lastAccessTime) => File.SetLastAccessTime(path, lastAccessTime);

    public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) => File.SetLastAccessTimeUtc(path, lastAccessTimeUtc);

    public DateTime GetLastAccessTime(string path) => File.GetLastAccessTime(path);

    public DateTime GetLastAccessTimeUtc(string path) => File.GetLastAccessTimeUtc(path);

    public void SetLastWriteTime(string path, DateTime lastWriteTime) => File.SetLastWriteTime(path, lastWriteTime);

    public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) => File.SetLastWriteTimeUtc(path, lastWriteTimeUtc);

    public DateTime GetLastWriteTime(string path) => File.GetLastWriteTime(path);

    public DateTime GetLastWriteTimeUtc(string path) => File.GetLastWriteTimeUtc(path);

    public FileAttributes GetAttributes(string path) => File.GetAttributes(path);

    public void SetAttributes(string path, FileAttributes fileAttributes) => File.SetAttributes(path, fileAttributes);

    public IFileStream OpenRead(string path) => new FileStreamWrapper(File.OpenRead(path));

    public IFileStream OpenWrite(string path) => new FileStreamWrapper(File.OpenWrite(path));

    public string ReadAllText(string path) => File.ReadAllText(path);

    public string ReadAllText(string path, Encoding encoding) => File.ReadAllText(path, encoding);

    public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);

    public void WriteAllText(string path, string contents, Encoding encoding) => File.WriteAllText(path, contents, encoding);

    public byte[] ReadAllBytes(string path) => File.ReadAllBytes(path);

    public void WriteAllBytes(string path, byte[] bytes) => File.WriteAllBytes(path, bytes);

    public IReadOnlyList<string> ReadAllLines(string path) => File.ReadAllLines(path);

    public IReadOnlyList<string> ReadAllLines(string path, Encoding encoding) => File.ReadAllLines(path, encoding);

    public IEnumerable<string> ReadLines(string path) => File.ReadLines(path);

    public IEnumerable<string> ReadLines(string path, Encoding encoding) => File.ReadLines(path, encoding);

    public void WriteAllLines(string path, IList<string> contents) => File.WriteAllLines(path, contents);

    public void WriteAllLines(string path, IEnumerable<string> contents) => File.WriteAllLines(path, contents);

    public void WriteAllLines(string path, IList<string> contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);

    public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);

    public void AppendAllText(string path, string contents) => File.AppendAllText(path, contents);

    public void AppendAllText(string path, string contents, Encoding encoding) => File.AppendAllText(path, contents, encoding);

    public void AppendAllLines(string path, IEnumerable<string> contents) => File.AppendAllLines(path, contents);

    public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.AppendAllLines(path, contents, encoding);

    public void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName) => File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);

    public void ReplaceAndIgnoreMetadataErrors(string sourceFileName, string destinationFileName, string destinationBackupFileName) => File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, true);

    public void Move(string sourceFileName, string destFileName) => File.Move(sourceFileName, destFileName);
}