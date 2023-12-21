namespace ToolBX.NetAbstractions.IO.Compression;

public interface IZipFile
{
    IZipArchive OpenRead(string archiveFileName);
    IZipArchive Open(string archiveFileName, ZipArchiveMode mode);
    IZipArchive Open(string archiveFileName, ZipArchiveMode mode, Encoding? entryNameEncoding);

    IZipArchive CreateFromStream(IStream stream);

    void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName);
    void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory);
    void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory, Encoding? entryNameEncoding);
    void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName);
    void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, bool overwriteFiles);
    void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding? entryNameEncoding);
    void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding? entryNameEncoding, bool overwriteFiles);
}

[AutoInject(ServiceLifetime.Singleton)]
public class ZipFileWrapper : IZipFile
{
    public IZipArchive OpenRead(string archiveFileName) => new ZipArchiveWrapper(ZipFile.OpenRead(archiveFileName));

    public IZipArchive Open(string archiveFileName, ZipArchiveMode mode) => new ZipArchiveWrapper(ZipFile.Open(archiveFileName, mode));

    public IZipArchive Open(string archiveFileName, ZipArchiveMode mode, Encoding? entryNameEncoding) => new ZipArchiveWrapper(ZipFile.Open(archiveFileName, mode, entryNameEncoding));
    
    public IZipArchive CreateFromStream(IStream stream) => new ZipArchiveWrapper(new ZipArchive(stream.Unwrapped, ZipArchiveMode.Create, true));

    public void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName) => ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);

    public void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory)
    {
        ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory);
    }

    public void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, CompressionLevel compressionLevel, bool includeBaseDirectory, Encoding? entryNameEncoding)
    {
        ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, compressionLevel, includeBaseDirectory, entryNameEncoding);
    }

    public void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName)
    {
        ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
    }

    public void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, bool overwriteFiles)
    {
        ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName, overwriteFiles);
    }

    public void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding? entryNameEncoding)
    {
        ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName, entryNameEncoding);
    }

    public void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, Encoding? entryNameEncoding, bool overwriteFiles)
    {
        ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName, entryNameEncoding, overwriteFiles);
    }
}