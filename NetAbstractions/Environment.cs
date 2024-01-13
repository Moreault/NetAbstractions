namespace ToolBX.NetAbstractions;

public interface IEnvironment
{
    int CurrentManagedThreadId { get; }
    void Exit(int exitCode);
    int ExitCode { get; set; }
    void FailFast(string? message);
    void FailFast(string? message, Exception? exception);
    IReadOnlyList<string> GetCommandLineArgs();
    int TickCount { get; }
    long TickCount64 { get; }
    int ProcessorCount { get; }
    bool HasShutdownStarted { get; }
    string? GetEnvironmentVariable(string variable);
    string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target);
    IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target);
    void SetEnvironmentVariable(string variable, string? value);
    void SetEnvironmentVariable(string variable, string? value, EnvironmentVariableTarget target);
    string CommandLine { get; }
    string CurrentDirectory { get; set; }
    string ExpandEnvironmentVariables(string name);
    string GetFolderPath(Environment.SpecialFolder folder);
    string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option);
    int ProcessId { get; }
    string? ProcessPath { get; }
    bool Is64BitProcess { get; }
    bool Is64BitOperatingSystem { get; }
    string NewLine { get; }
    OperatingSystem OsVersion { get; }
    Version Version { get; }
    string StackTrace { get; }
    string UserName { get; }
    string UserDomainName { get; }
    IReadOnlyList<string> GetLogicalDrives();
    int SystemPageSize { get; }
    string MachineName { get; }
    string SystemDirectory { get; }
    bool UserInteractive { get; }
    long WorkingSet { get; }
    IDictionary GetEnvironmentVariables();
}

[AutoInject(ServiceLifetime.Singleton)]
public class EnvironmentWrapper : IEnvironment
{
    public int CurrentManagedThreadId => Environment.CurrentManagedThreadId;

    public void Exit(int exitCode) => Environment.Exit(exitCode);

    public int ExitCode
    {
        get => Environment.ExitCode;
        set => Environment.ExitCode = value;
    }
    public void FailFast(string? message) => Environment.FailFast(message);

    public void FailFast(string? message, Exception? exception) => Environment.FailFast(message, exception);

    public IReadOnlyList<string> GetCommandLineArgs() => Environment.GetCommandLineArgs();

    public int TickCount => Environment.TickCount;
    public long TickCount64 => Environment.TickCount64;
    public int ProcessorCount => Environment.ProcessorCount;
    public bool HasShutdownStarted => Environment.HasShutdownStarted;
    public string? GetEnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable);

    public string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target) => Environment.GetEnvironmentVariable(variable, target);

    public IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target) => Environment.GetEnvironmentVariables(target);

    public void SetEnvironmentVariable(string variable, string? value) => Environment.SetEnvironmentVariable(variable, value);

    public void SetEnvironmentVariable(string variable, string? value, EnvironmentVariableTarget target) => Environment.SetEnvironmentVariable(variable, value, target);

    public string CommandLine => Environment.CommandLine;
    public string CurrentDirectory
    {
        get => Environment.CurrentDirectory;
        set => Environment.CurrentDirectory = value;
    }
    public string ExpandEnvironmentVariables(string name) => Environment.ExpandEnvironmentVariables(name);

    public string GetFolderPath(Environment.SpecialFolder folder) => Environment.GetFolderPath(folder);

    public string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option) => Environment.GetFolderPath(folder, option);

    public int ProcessId => Environment.ProcessId;
    public string? ProcessPath => Environment.ProcessPath;
    public bool Is64BitProcess => Environment.Is64BitProcess;
    public bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;
    public string NewLine => Environment.NewLine;
    public OperatingSystem OsVersion => Environment.OSVersion;
    public Version Version => Environment.Version;
    public string StackTrace => Environment.StackTrace;
    public string UserName => Environment.UserName;
    public string UserDomainName => Environment.UserDomainName;

    public IReadOnlyList<string> GetLogicalDrives() => Environment.GetLogicalDrives();

    public int SystemPageSize => Environment.SystemPageSize;
    public string MachineName => Environment.MachineName;
    public string SystemDirectory => Environment.SystemDirectory;
    public bool UserInteractive => Environment.UserInteractive;
    public long WorkingSet => Environment.WorkingSet;

    public IDictionary GetEnvironmentVariables() => Environment.GetEnvironmentVariables();
}