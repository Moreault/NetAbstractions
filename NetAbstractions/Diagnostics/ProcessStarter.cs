namespace ToolBX.NetAbstractions.Diagnostics;

public interface IProcessStarter
{
    IProcess GetProcessById(int processId, string machineName);
    IProcess GetProcessById(int processId);
    IReadOnlyList<IProcess> GetProcessesByName(string processName);
    IReadOnlyList<IProcess> GetProcesses();
    IReadOnlyList<IProcess> GetProcesses(string machineName);
    IProcess GetCurrentProcess();
    IProcess Start(string fileName);
    IProcess Start(string fileName, string arguments);
    IProcess Start(ProcessStartInfo startInfo);
    IReadOnlyList<IProcess> GetProcessesByName(string processName, string machineName);
    void EnterDebugMode();
    void LeaveDebugMode();
}

[AutoInject]
public class ProcessStarter : IProcessStarter
{
    public IProcess GetProcessById(int processId, string machineName) => new ProcessWrapper(Process.GetProcessById(processId, machineName));

    public IProcess GetProcessById(int processId) => new ProcessWrapper(Process.GetProcessById(processId));

    public IReadOnlyList<IProcess> GetProcessesByName(string processName) => Process.GetProcessesByName(processName).Select(x => new ProcessWrapper(x) as IProcess).ToList();

    public IReadOnlyList<IProcess> GetProcesses() => Process.GetProcesses().Select(x => new ProcessWrapper(x) as IProcess).ToList();

    public IReadOnlyList<IProcess> GetProcesses(string machineName) => Process.GetProcesses(machineName).Select(x => new ProcessWrapper(x) as IProcess).ToList();

    public IProcess GetCurrentProcess() => new ProcessWrapper(Process.GetCurrentProcess());

    public IProcess Start(string fileName) => new ProcessWrapper(Process.Start(fileName));

    public IProcess Start(string fileName, string arguments) => new ProcessWrapper(Process.Start(fileName, arguments));

    public IProcess Start(ProcessStartInfo startInfo) => new ProcessWrapper(Process.Start(startInfo));

    public IReadOnlyList<IProcess> GetProcessesByName(string processName, string machineName) => Process.GetProcessesByName(processName, machineName).Select(x => new ProcessWrapper(x) as IProcess).ToList();

    public void EnterDebugMode() => Process.EnterDebugMode();

    public void LeaveDebugMode() => Process.LeaveDebugMode();
}