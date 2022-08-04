namespace ToolBX.NetAbstractions.Web.AspNetCore;

public interface IQueryHelpers
{
    string AddQueryString(string uri, string name, string value);
    string AddQueryString(string uri, IDictionary<string, string> queryString);
    IDictionary<string, StringValues> ParseQuery(string queryString);
    IDictionary<string, StringValues> ParseNullableQuery(string queryString);
}

[AutoInject]
public class QueryHelpersWrapper : IQueryHelpers
{
    public string AddQueryString(string uri, string name, string value) => QueryHelpers.AddQueryString(uri, name, value);

    public string AddQueryString(string uri, IDictionary<string, string> queryString) => QueryHelpers.AddQueryString(uri, queryString);

    public IDictionary<string, StringValues> ParseQuery(string queryString) => QueryHelpers.ParseQuery(queryString);

    public IDictionary<string, StringValues> ParseNullableQuery(string queryString) => QueryHelpers.ParseNullableQuery(queryString);
}