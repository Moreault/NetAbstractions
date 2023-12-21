namespace ToolBX.NetAbstractions;

public interface IEnvironmentVariables
{
    string? this[string key] { get; set; }
    string? Get(string key, EnvironmentVariableTarget target);
    void Set(string key, string? value, EnvironmentVariableTarget target);
    string Expand(string key);
    IReadOnlyDictionary<string, string?> Get(EnvironmentVariableTarget target = EnvironmentVariableTarget.Process);
    bool Contains(string key);
}

[AutoInject(ServiceLifetime.Singleton)]
public class EnvironmentVariables : IEnvironmentVariables
{
    public string? this[string key]
    {
        get => Environment.GetEnvironmentVariable(key);
        set => Environment.SetEnvironmentVariable(key, value);
    }

    public string? Get(string key, EnvironmentVariableTarget target) => Environment.GetEnvironmentVariable(key, target);

    public void Set(string key, string? value, EnvironmentVariableTarget target) => Environment.SetEnvironmentVariable(key, value, target);

    public string Expand(string key) => Environment.ExpandEnvironmentVariables(key);

    public IReadOnlyDictionary<string, string?> Get(EnvironmentVariableTarget target = EnvironmentVariableTarget.Process)
    {
        var variables = Environment.GetEnvironmentVariables(target);
        var output = new Dictionary<string, string?>();
        foreach (var key in variables.Keys)
            output[(string)key] = variables[key] as string;
        return output;
    }

    public bool Contains(string key) => this[key] != null;
}