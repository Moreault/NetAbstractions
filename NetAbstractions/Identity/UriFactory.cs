namespace ToolBX.NetAbstractions.Identity;

public interface IUriFactory
{
    IUri Create(string uriString);
    IUri Create(string uriString, UriKind uriKind);
    IUri Create(string baseUri, string relativeUri);
    IUri Create(Uri baseUri, string relativeUri);
    IUri Create(Uri baseUri, Uri relativeUri);
    IUri Create(Uri uri);
}

[AutoInject]
public class UriFactory : IUriFactory
{
    public IUri Create(string uriString) => new UriWrapper(new Uri(uriString));

    public IUri Create(string uriString, UriKind uriKind) => new UriWrapper(new Uri(uriString, uriKind));

    public IUri Create(string baseUri, string relativeUri) => new UriWrapper(new Uri(new Uri(baseUri), relativeUri));

    public IUri Create(Uri baseUri, string relativeUri) => new UriWrapper(new Uri(baseUri, relativeUri));

    public IUri Create(Uri baseUri, Uri relativeUri) => new UriWrapper(new Uri(baseUri, relativeUri));

    public IUri Create(Uri uri) => new UriWrapper(uri);
}