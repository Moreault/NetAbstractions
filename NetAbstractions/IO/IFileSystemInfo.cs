using System.Runtime.Serialization;

namespace ToolBX.NetAbstractions.IO;

public interface IFileSystemInfo : ISerializable
{
    string FullName { get; }
    string Extension { get; }
    string Name { get; }
    bool Exists { get; }
    void Delete();
    DateTime CreationTime { get; set; }
    DateTime CreationTimeUtc { get; set; }
    DateTime LastAccessTime { get; set; }
    DateTime LastAccessTimeUtc { get; set; }
    DateTime LastWriteTime { get; set; }
    DateTime LastWriteTimeUtc { get; set; }
    FileAttributes Attributes { get; set; }
    void Refresh();
}