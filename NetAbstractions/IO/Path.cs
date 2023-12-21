namespace ToolBX.NetAbstractions.IO;

public interface IPath
{
    string? ChangeExtension(string? path, string? extension);

    /// <summary>
    /// Returns the directory portion of a file path. This method effectively
    /// removes the last segment of the given file path, i.e. it returns a
    /// string consisting of all characters up to but not including the last
    /// backslash ("\") in the file path. The returned value is null if the
    /// specified path is null, empty, or a root (such as "\", "C:", or
    /// "\\server\share").
    /// </summary>
    /// <remarks>
    /// Directory separators are normalized in the returned string.
    /// </remarks>
    string? GetDirectoryName(string? path);

    /// <summary>
    /// Returns the directory portion of a file path. The returned value is empty
    /// if the specified path is null, empty, or a root (such as "\", "C:", or
    /// "\\server\share").
    /// </summary>
    /// <remarks>
    /// Unlike the string overload, this method will not normalize directory separators.
    /// </remarks>
    ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path);

    /// <summary>
    /// Returns the extension of the given path. The returned value includes the period (".") character of the
    /// extension except when you have a terminal period when you get string.Empty, such as ".exe" or ".cpp".
    /// The returned value is null if the given path is null or empty if the given path does not include an
    /// extension.
    /// </summary>
    string? GetExtension(string? path);

    /// <summary>
    /// Returns the extension of the given path.
    /// </summary>
    /// <remarks>
    /// The returned value is an empty ReadOnlySpan if the given path does not include an extension.
    /// </remarks>
    ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path);

    /// <summary>
    /// Returns the extension of the given path. The returned value includes the period (".") character of the
    /// extension except when you have a terminal period when you get string.Empty, such as ".exe" or ".cpp".
    /// The returned value is null if the given path is null or empty if the given path does not include an
    /// extension.
    /// </summary>
    string? GetExtensionWithoutDot(string? path);

    /// <summary>
    /// Returns the extension of the given path.
    /// </summary>
    /// <remarks>
    /// The returned value is an empty ReadOnlySpan if the given path does not include an extension.
    /// </remarks>
    ReadOnlySpan<char> GetExtensionWithoutDot(ReadOnlySpan<char> path);

    /// <summary>
    /// Returns the name and extension parts of the given path. The resulting string contains
    /// the characters of path that follow the last separator in path. The resulting string is
    /// null if path is null.
    /// </summary>
    string? GetFileName(string? path);

    /// <summary>
    /// The returned ReadOnlySpan contains the characters of the path that follows the last separator in path.
    /// </summary>
    ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path);

    string? GetFileNameWithoutExtension(string? path);

    /// <summary>
    /// Returns the characters between the last separator and last (.) in the path.
    /// </summary>
    ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path);

    /// <summary>
    /// Returns a cryptographically strong random 8.3 string that can be
    /// used as either a folder name or a file name.
    /// </summary>
    string GetRandomFileName();

    /// <summary>
    /// Returns true if the path is fixed to a specific drive or UNC path. This method does no
    /// validation of the path (URIs will be returned as relative as a result).
    /// Returns false if the path specified is relative to the current drive or working directory.
    /// </summary>
    /// <remarks>
    /// Handles paths that use the alternate directory separator.  It is a frequent mistake to
    /// assume that rooted paths <see cref="Path.IsPathRooted(string)"/> are not relative.  This isn't the case.
    /// "C:a" is drive relative- meaning that it will be resolved against the current directory
    /// for C: (rooted, but relative). "C:\a" is rooted and not relative (the current directory
    /// will not be used to modify the path).
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="path"/> is null.
    /// </exception>
    bool IsPathFullyQualified(string path);

    bool IsPathFullyQualified(ReadOnlySpan<char> path);

    /// <summary>
    /// Tests if a path's file name includes a file extension. A trailing period
    /// is not considered an extension.
    /// </summary>
    bool HasExtension([NotNullWhen(true)] string? path);

    bool HasExtension(ReadOnlySpan<char> path);
    string Combine(IEnumerable<string> paths);
    string Combine(params string[] paths);
    string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);
    string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);
    string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, ReadOnlySpan<char> path4);
    string Join(IEnumerable<string?> paths);
    string Join(params string?[] paths);

    Result<int> TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination);
    Result<int> TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination);

    /// <summary>
    /// Create a relative path from one path to another. Paths will be resolved before calculating the difference.
    /// Default path comparison for the active platform will be used (OrdinalIgnoreCase for Windows or Mac, Ordinal for Unix).
    /// </summary>
    /// <param name="relativeTo">The source path the output should be relative to. This path is always considered to be a directory.</param>
    /// <param name="path">The destination path.</param>
    /// <returns>The relative path or <paramref name="path"/> if the paths don't share the same root.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="relativeTo"/> or <paramref name="path"/> is <c>null</c> or an empty string.</exception>
    string GetRelativePath(string relativeTo, string path);

    /// <summary>
    /// Trims one trailing directory separator beyond the root of the path.
    /// </summary>
    string TrimEndingDirectorySeparator(string path);

    /// <summary>
    /// Trims one trailing directory separator beyond the root of the path.
    /// </summary>
    ReadOnlySpan<char> TrimEndingDirectorySeparator(ReadOnlySpan<char> path);

    /// <summary>
    /// Returns true if the path ends in a directory separator.
    /// </summary>
    bool EndsInDirectorySeparator(ReadOnlySpan<char> path);

    /// <summary>
    /// Returns true if the path ends in a directory separator.
    /// </summary>
    bool EndsInDirectorySeparator(string path);

    IReadOnlyList<char> GetInvalidFileNameChars();

    IReadOnlyList<char> GetInvalidPathChars();
    /// <summary>
    /// Expands the given path to a fully qualified path.
    /// </summary>
    string GetFullPath(string path);
    string GetFullPath(string path, string basePath);

    string GetTempPath();
    /// <summary>
    /// Returns a unique temporary file name, and creates a 0-byte file by that name on disk.
    /// </summary>
    string GetTempFileName();

    /// <summary>
    /// Tests if the given path contains a root. A path is considered rooted if it starts with a backslash ("\") or a valid drive letter and a colon (":").
    /// </summary>
    bool IsPathRooted([NotNullWhen(true)] string? path);

    bool IsPathRooted(ReadOnlySpan<char> path);

    /// <summary>
    /// Returns the root portion of the given path. The resulting string consists of those rightmost characters of the path that constitute the root of the path. Possible patterns for the resulting string are: An empty string (a relative path on the current drive), "\" (an absolute path on the current drive), "X:" (a relative path on a given drive, where X is the drive letter), "X:\" (an absolute path on a given drive), and "\\server\share" (a UNC path for a given server and share name). The resulting string is null if path is null. If the path is empty or only contains whitespace characters an ArgumentException gets thrown.
    /// </summary>
    string? GetPathRoot(string? path);

    /// <summary>
    /// Unlike the string overload, this method will not normalize directory separators.
    /// </summary>
    ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path);
}

[AutoInject(ServiceLifetime.Singleton)]
public class PathWrapper : IPath
{
    public string? ChangeExtension(string? path, string? extension) => Path.ChangeExtension(path, extension);

    public string? GetDirectoryName(string? path) => Path.GetDirectoryName(path);

    public ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path) => Path.GetDirectoryName(path);

    public string? GetExtension(string? path) => Path.GetExtension(path);

    public ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path) => Path.GetFileName(path);

    public string? GetExtensionWithoutDot(string? path) => GetExtension(path)?.TrimStart('.');

    public ReadOnlySpan<char> GetExtensionWithoutDot(ReadOnlySpan<char> path) => GetExtension(path).TrimStart('.');

    public string? GetFileName(string? path) => Path.GetFileName(path);

    public ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path) => Path.GetFileName(path);

    public string? GetFileNameWithoutExtension(string? path) => Path.GetFileNameWithoutExtension(path);

    public ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path) => Path.GetFileNameWithoutExtension(path);

    public string GetRandomFileName() => Path.GetRandomFileName();

    public bool IsPathFullyQualified(string path) => Path.IsPathFullyQualified(path);

    public bool IsPathFullyQualified(ReadOnlySpan<char> path) => Path.IsPathFullyQualified(path);

    public bool HasExtension(string? path) => Path.HasExtension(path);

    public bool HasExtension(ReadOnlySpan<char> path) => Path.HasExtension(path);

    public string Combine(IEnumerable<string> paths) => Path.Combine(paths as string[] ?? paths?.ToArray() ?? throw new ArgumentNullException(nameof(paths)));

    public string Combine(params string[] paths) => Path.Combine(paths);

    public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2) => Path.Join(path1, path2);

    public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3) => Path.Join(path1, path2, path3);

    public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, ReadOnlySpan<char> path4) => Path.Join(path1, path2, path3, path4);

    public string Join(IEnumerable<string?> paths) => Path.Join(paths as string[] ?? paths?.ToArray() ?? throw new ArgumentNullException(nameof(paths)));

    public string Join(params string?[] paths) => Path.Join(paths);

    public Result<int> TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination)
    {
        var result = Path.TryJoin(path1, path2, destination, out var charsWritten);
        return result ? Result<int>.Success(charsWritten) : Result<int>.Failure();
    }

    public Result<int> TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination)
    {
        var result = Path.TryJoin(path1, path2, path3, destination, out var charsWritten);
        return result ? Result<int>.Success(charsWritten) : Result<int>.Failure();
    }

    public string GetRelativePath(string relativeTo, string path) => Path.GetRelativePath(relativeTo, path);

    public string TrimEndingDirectorySeparator(string path) => Path.TrimEndingDirectorySeparator(path);

    public ReadOnlySpan<char> TrimEndingDirectorySeparator(ReadOnlySpan<char> path) => Path.TrimEndingDirectorySeparator(path);

    public bool EndsInDirectorySeparator(ReadOnlySpan<char> path) => Path.EndsInDirectorySeparator(path);

    public bool EndsInDirectorySeparator(string path) => Path.EndsInDirectorySeparator(path);

    public IReadOnlyList<char> GetInvalidFileNameChars() => Path.GetInvalidFileNameChars();

    public IReadOnlyList<char> GetInvalidPathChars() => Path.GetInvalidPathChars();

    public string GetFullPath(string path) => Path.GetFullPath(path);

    public string GetFullPath(string path, string basePath) => Path.GetFullPath(path, basePath);

    public string GetTempPath() => Path.GetTempPath();

    public string GetTempFileName() => Path.GetTempFileName();

    public bool IsPathRooted(string? path) => Path.IsPathRooted(path);

    public bool IsPathRooted(ReadOnlySpan<char> path) => Path.IsPathRooted(path);

    public string? GetPathRoot(string? path) => Path.GetPathRoot(path);

    public ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path) => Path.GetPathRoot(path);
}