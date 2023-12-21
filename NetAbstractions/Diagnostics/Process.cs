namespace ToolBX.NetAbstractions.Diagnostics;

public interface IProcess : IComponent, IWrapper<Process>
{
    event DataReceivedEventHandler OutputDataReceived;
    event DataReceivedEventHandler ErrorDataReceived;

    SafeProcessHandle SafeHandle { get; }
    IntPtr Handle { get; }
    int BasePriority { get; }
    int ExitCode { get; }
    bool HasExited { get; }
    DateTime StartTime { get; }
    DateTime ExitTime { get; }
    int Id { get; }
    string MachineName { get; }
    IntPtr MaxWorkingSet { get; }
    IntPtr MinWorkingSet { get; }
    ProcessModuleCollection Modules { get; }
    long NonpagedSystemMemorySize { get; }
    long PagedMemorySize { get; }
    long PagedSystemMemorySize { get; }
    long PeakPagedMemorySize { get; }
    long PeakWorkingSet { get; }
    long PeakVirtualMemorySize { get; }
    bool PriorityBoostEnabled { get; set; }
    ProcessPriorityClass PriorityClass { get; set; }
    long PrivateMemorySize { get; }
    string ProcessName { get; }

    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    IntPtr ProcessorAffinity { get; set; }
    int SessionId { get; }
    ProcessStartInfo StartInfo { get; set; }
    ProcessThreadCollection Threads { get; }
    int HandleCount { get; }
    long VirtualMemorySize { get; }
    bool EnableRaisingEvents { get; set; }
    IStreamWriter StandardInput { get; }
    IStreamReader StandardOutput { get; }
    IStreamReader StandardError { get; }
    long WorkingSet { get; }
    event EventHandler Exited;
    bool CloseMainWindow();
    bool WaitForInputIdle();
    bool WaitForInputIdle(int milliseconds);
    ISynchronizeInvoke? SynchronizingObject { get; set; }
    void Close();
    void Refresh();
    bool Start();
    void WaitForExit();
    bool WaitForExit(int milliseconds);
    void BeginOutputReadLine();
    void BeginErrorReadLine();
    void CancelOutputRead();
    void CancelErrorRead();
    void Kill();
    ProcessModule? MainModule { get; }
    TimeSpan PrivilegedProcessorTime { get; }
    TimeSpan TotalProcessorTime { get; }
    TimeSpan UserProcessorTime { get; }
    IntPtr MainWindowHandle { get; }
    string MainWindowTitle { get; }
    bool Responding { get; }
}

internal class ProcessWrapper : Wrapper<Process>, IProcess
{
    public ProcessWrapper(Process unwrapped) : base(unwrapped)
    {
    }

    public void Dispose()
    {
        Unwrapped.Dispose();
    }

    public ISite? Site
    {
        get => Unwrapped.Site;
        set => Unwrapped.Site = value;
    }

    public event EventHandler? Disposed
    {
        add => Unwrapped.Disposed += value;
        remove => Unwrapped.Disposed -= value;
    }

    public event DataReceivedEventHandler OutputDataReceived
    {
        add => Unwrapped.OutputDataReceived += value;
        remove => Unwrapped.OutputDataReceived -= value;
    }

    public event DataReceivedEventHandler ErrorDataReceived
    {
        add => Unwrapped.ErrorDataReceived += value;
        remove => Unwrapped.ErrorDataReceived -= value;
    }

    public SafeProcessHandle SafeHandle => Unwrapped.SafeHandle;
    public IntPtr Handle => Unwrapped.Handle;
    public int BasePriority => Unwrapped.BasePriority;
    public int ExitCode => Unwrapped.ExitCode;
    public bool HasExited => Unwrapped.HasExited;
    public DateTime StartTime => Unwrapped.StartTime;
    public DateTime ExitTime => Unwrapped.ExitTime;
    public int Id => Unwrapped.Id;
    public string MachineName => Unwrapped.MachineName;
    public IntPtr MaxWorkingSet => Unwrapped.MaxWorkingSet;

    public IntPtr MinWorkingSet => Unwrapped.MinWorkingSet;

    public ProcessModuleCollection Modules => Unwrapped.Modules;
    public long NonpagedSystemMemorySize => Unwrapped.NonpagedSystemMemorySize64;
    public long PagedMemorySize => Unwrapped.PagedMemorySize64;
    public long PagedSystemMemorySize => Unwrapped.PagedSystemMemorySize64;
    public long PeakPagedMemorySize => Unwrapped.PeakPagedMemorySize64;
    public long PeakWorkingSet => Unwrapped.PeakWorkingSet64;
    public long PeakVirtualMemorySize => Unwrapped.PeakVirtualMemorySize64;
    public bool PriorityBoostEnabled
    {
        get => Unwrapped.PriorityBoostEnabled;
        set => Unwrapped.PriorityBoostEnabled = value;
    }
    public ProcessPriorityClass PriorityClass
    {
        get => Unwrapped.PriorityClass;
        set => Unwrapped.PriorityClass = value;
    }
    public long PrivateMemorySize => Unwrapped.PrivateMemorySize64;
    public string ProcessName => Unwrapped.ProcessName;

    [SupportedOSPlatform("windows")]
    [SupportedOSPlatform("linux")]
    public IntPtr ProcessorAffinity
    {
        get => Unwrapped.ProcessorAffinity;
        set => Unwrapped.ProcessorAffinity = value;
    }
    public int SessionId => Unwrapped.SessionId;
    public ProcessStartInfo StartInfo
    {
        get => Unwrapped.StartInfo;
        set => Unwrapped.StartInfo = value;
    }
    public ProcessThreadCollection Threads => Unwrapped.Threads;
    public int HandleCount => Unwrapped.HandleCount;
    public long VirtualMemorySize => Unwrapped.VirtualMemorySize64;
    public bool EnableRaisingEvents
    {
        get => Unwrapped.EnableRaisingEvents;
        set => Unwrapped.EnableRaisingEvents = value;
    }
    public IStreamWriter StandardInput => new StreamWriterWrapper(Unwrapped.StandardInput);
    public IStreamReader StandardOutput => new StreamReaderWrapper(Unwrapped.StandardOutput);
    public IStreamReader StandardError => new StreamReaderWrapper(Unwrapped.StandardError);
    public long WorkingSet => Unwrapped.WorkingSet64;

    public event EventHandler Exited
    {
        add => Unwrapped.Exited += value;
        remove => Unwrapped.Exited -= value;
    }

    public bool CloseMainWindow() => Unwrapped.CloseMainWindow();

    public bool WaitForInputIdle() => Unwrapped.WaitForInputIdle();

    public bool WaitForInputIdle(int milliseconds) => Unwrapped.WaitForInputIdle(milliseconds);

    public ISynchronizeInvoke? SynchronizingObject
    {
        get => Unwrapped.SynchronizingObject;
        set => Unwrapped.SynchronizingObject = value;
    }

    public void Close() => Unwrapped.Close();

    public void Refresh() => Unwrapped.Refresh();

    public bool Start() => Unwrapped.Start();

    public void WaitForExit() => Unwrapped.WaitForExit();

    public bool WaitForExit(int milliseconds) => Unwrapped.WaitForExit(milliseconds);

    public void BeginOutputReadLine() => Unwrapped.BeginOutputReadLine();

    public void BeginErrorReadLine() => Unwrapped.BeginErrorReadLine();

    public void CancelOutputRead() => Unwrapped.CancelOutputRead();

    public void CancelErrorRead() => Unwrapped.CancelErrorRead();

    public void Kill() => Unwrapped.Kill();

    public ProcessModule? MainModule => Unwrapped.MainModule;
    public TimeSpan PrivilegedProcessorTime => Unwrapped.PrivilegedProcessorTime;
    public TimeSpan TotalProcessorTime => Unwrapped.TotalProcessorTime;
    public TimeSpan UserProcessorTime => Unwrapped.UserProcessorTime;
    public IntPtr MainWindowHandle => Unwrapped.MainWindowHandle;
    public string MainWindowTitle => Unwrapped.MainWindowTitle;
    public bool Responding => Unwrapped.Responding;

    [Obsolete("Use explicit operator instead : Will be removed in 3.0.0")]
    public static implicit operator Process(ProcessWrapper process) => process.Unwrapped;
}