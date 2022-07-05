namespace ToolBX.NetAbstractions.Identity;

public interface IUri : ISerializable, IInstanceWrapper<Uri>
{
    string AbsolutePath { get; }
    string AbsoluteUri { get; }
    string LocalPath { get; }
    string Authority { get; }
    UriHostNameType HostNameType { get; }
    bool IsDefaultPort { get; }
    bool IsFile { get; }
    bool IsLoopback { get; }
    string PathAndQuery { get; }
    IReadOnlyList<string> Segments { get; }
    bool IsUnc { get; }
    string Host { get; }
    int Port { get; }
    string Query { get; }
    string Fragment { get; }
    string Scheme { get; }
    string OriginalString { get; }
    string DnsSafeHost { get; }
    string IdnHost { get; }
    bool IsAbsoluteUri { get; }
    bool UserEscaped { get; }
    string UserInfo { get; }
    string GetLeftPart(UriPartial part);
    IUri MakeRelativeUri(IUri uri);
    string GetComponents(UriComponents components, UriFormat format);
    bool IsWellFormedOriginalString();
    IUri Clone();
}

public class UriWrapper : IUri, IEquatable<UriWrapper>
{
    public Uri Unwrapped { get; }

    public UriWrapper(Uri uri)
    {
        Unwrapped = uri;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context) => ((ISerializable)Unwrapped).GetObjectData(info, context);

    public string AbsolutePath => Unwrapped.AbsolutePath;
    public string AbsoluteUri => Unwrapped.AbsoluteUri;
    public string LocalPath => Unwrapped.LocalPath;
    public string Authority => Unwrapped.Authority;
    public UriHostNameType HostNameType => Unwrapped.HostNameType;
    public bool IsDefaultPort => Unwrapped.IsDefaultPort;
    public bool IsFile => Unwrapped.IsFile;
    public bool IsLoopback => Unwrapped.IsLoopback;
    public string PathAndQuery => Unwrapped.PathAndQuery;
    public IReadOnlyList<string> Segments => Unwrapped.Segments;
    public bool IsUnc => Unwrapped.IsUnc;
    public string Host => Unwrapped.Host;
    public int Port => Unwrapped.Port;
    public string Query => Unwrapped.Query;
    public string Fragment => Unwrapped.Fragment;
    public string Scheme => Unwrapped.Scheme;
    public string OriginalString => Unwrapped.OriginalString;
    public string DnsSafeHost => Unwrapped.DnsSafeHost;
    public string IdnHost => Unwrapped.IdnHost;
    public bool IsAbsoluteUri => Unwrapped.IsAbsoluteUri;
    public bool UserEscaped => Unwrapped.UserEscaped;
    public string UserInfo => Unwrapped.UserInfo;

    public string GetLeftPart(UriPartial part) => Unwrapped.GetLeftPart(part);

    public IUri MakeRelativeUri(IUri uri) => new UriWrapper(Unwrapped.MakeRelativeUri(((UriWrapper)uri).Unwrapped));

    public string GetComponents(UriComponents components, UriFormat format) => Unwrapped.GetComponents(components, format);

    public bool IsWellFormedOriginalString() => Unwrapped.IsWellFormedOriginalString();

    public bool Equals(IUri? other) => other is UriWrapper uri && Equals(uri);

    public bool Equals(UriWrapper? other) => other != null && Unwrapped.Equals(other.Unwrapped);

    public bool Equals(Uri? other) => Unwrapped.Equals(other);

    public IUri Clone() => new UriWrapper(new Uri(Unwrapped.OriginalString));

    public override bool Equals(object? obj) => Equals(obj as IUri);

    public static bool operator ==(UriWrapper? a, UriWrapper? b) => a is null && b is null || a is not null && b is not null && a.Unwrapped == b.Unwrapped;

    public static bool operator !=(UriWrapper? a, UriWrapper? b) => !(a == b);

    public override string ToString() => Unwrapped.ToString();

    public override int GetHashCode() => Unwrapped.GetHashCode();
}