namespace ToolBX.NetAbstractions.Diagnostics;

public interface IConsole
{
    /// <summary>
    /// Color behind the text.
    /// </summary>
    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    ConsoleColor BackgroundColor { get; set; }

    /// <summary>
    /// Area of the buffer in columns.
    /// </summary>
    Size<int> Buffer
    {
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("browser")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        get;
        [SupportedOSPlatform("windows")]
        set;
    }

    [SupportedOSPlatform("windows")]
    bool IsCapsLockActive { get; }

    /// <summary>
    /// Position of the cursor within the buffer area.
    /// </summary>
    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    Vector2<int> CursorPosition { get; set; }

    int CursorSize
    {
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("browser")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        get;
        [SupportedOSPlatform("windows")]
        set;
    }

    bool IsCursorVisible
    {
        [SupportedOSPlatform("windows")]
        get;
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("browser")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        set;
    }

    ITextWriter Error { get; set; }

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    ConsoleColor ForegroundColor { get; set; }

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    ITextReader In { get; set; }

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    Encoding InputEncoding { get; set; }

    bool IsErrorRedirected { get; }
    bool IsInputRedirected { get; }
    bool IsOutputRedirected { get; }
    bool IsKeyAvailable { get; }

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    Size<int> LargestWindowSize { get; }

    [SupportedOSPlatform("windows")]
    bool IsNumberLockActive { get; }

    ITextWriter Out { get; set; }

    Encoding OutputEncoding
    {
        get;
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        set;
    }

    string Title
    {
        [SupportedOSPlatform("windows")]
        get;
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("browser")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        set;
    }

    /// <summary>
    /// Whether or not CTRL+C counts as input.
    /// </summary>
    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    bool IsControlCTreatedAsInput { get; set; }

    Rectangle<int> Window
    {
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("browser")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        get;
        [SupportedOSPlatform("windows")]
        set;
    }

    Vector2<int> WindowPosition
    {
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("browser")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        get;
        [SupportedOSPlatform("windows")]
        set;
    }

    Size<int> WindowSize
    {
        [UnsupportedOSPlatform("android")]
        [UnsupportedOSPlatform("browser")]
        [UnsupportedOSPlatform("ios")]
        [UnsupportedOSPlatform("tvos")]
        get;
        [SupportedOSPlatform("windows")]
        set;
    }

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    event ConsoleCancelEventHandler? CancelKeyPress;

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    void Beep();

    [SupportedOSPlatform("windows")]
    void Beep(int frequency, int duration);

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    void Clear();

    [SupportedOSPlatform("windows")]
    void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop);

    [SupportedOSPlatform("windows")]
    void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor);

    IStream OpenStandardError();
    IStream OpenStandardError(int bufferSize);

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    IStream OpenStandardInput();

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    IStream OpenStandardInput(int bufferSize);

    IStream OpenStandardOutput();

    IStream OpenStandardOutput(int bufferSize);

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    int Read();

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    ConsoleKeyInfo ReadKey();

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    ConsoleKeyInfo ReadAndInterceptKey();

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    string? ReadLine();

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    void ResetColor();

    void SetError(TextWriter newError);

    [UnsupportedOSPlatform("android")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [UnsupportedOSPlatform("tvos")]
    void SetIn(TextReader newIn);

    void SetOut(TextWriter newOut);

    void Write(bool value);
    void Write(char value);
    void Write(char[]? buffer);
    void Write(char[] buffer, int index, int count);
    void Write(decimal value);
    void Write(double value);
    void Write(int value);
    void Write(long value);
    void Write(object? value);
    void Write(float value);
    void Write(string? value);
    void Write(string format, params object?[]? arg);
    void Write(uint value);
    void Write(ulong value);
    void WriteLine();
    void WriteLine(bool value);
    void WriteLine(char value);
    void WriteLine(char[]? buffer);
    void WriteLine(char[] buffer, int index, int count);
    void WriteLine(decimal value);
    void WriteLine(double value);
    void WriteLine(int value);
    void WriteLine(long value);
    void WriteLine(object? value);
    void WriteLine(float value);
    void WriteLine(string? value);
    void WriteLine(string format, params object?[]? arg);
    void WriteLine(uint value);
    void WriteLine(ulong value);
}

[AutoInject]
public class ConsoleWrapper : IConsole
{
    public ConsoleColor BackgroundColor
    {
        get => Console.BackgroundColor;
        set => Console.BackgroundColor = value;
    }

    public Size<int> Buffer
    {
        get => new(Console.BufferWidth, Console.BufferHeight);
        set
        {
            Console.BufferWidth = value.Width;
            Console.BufferHeight = value.Height;
        }
    }

    public bool IsCapsLockActive => Console.CapsLock;

    public Vector2<int> CursorPosition
    {
        get => new(Console.CursorLeft, Console.CursorTop);
        set
        {
            Console.CursorLeft = value.X;
            Console.CursorTop = value.Y;
        }
    }

    public int CursorSize
    {
        get => Console.CursorSize;
        set => Console.CursorSize = value;
    }

    public bool IsCursorVisible
    {
        get => Console.CursorVisible;
        set => Console.CursorVisible = value;
    }

    public ITextWriter Error
    {
        get => _error.Value;
        set
        {
            Console.SetError(value.Unwrapped);
            _error = new Lazy<ITextWriter>(() => value);
        }
    }
    private Lazy<ITextWriter> _error = new(() => new TextWriterWrapper(Console.Error));

    public ConsoleColor ForegroundColor
    {
        get => Console.ForegroundColor;
        set => Console.ForegroundColor = value;
    }

    public ITextReader In
    {
        get => _in.Value;
        set
        {
            Console.SetIn(value.Unwrapped);
            _in = new Lazy<ITextReader>(() => value);
        }
    }
    private Lazy<ITextReader> _in = new(() => new TextReaderWrapper(Console.In));
    
    public Encoding InputEncoding
    {
        get => Console.InputEncoding;
        set => Console.InputEncoding = value;
    }

    public bool IsErrorRedirected => Console.IsErrorRedirected;
    public bool IsInputRedirected => Console.IsInputRedirected;
    public bool IsOutputRedirected => Console.IsOutputRedirected;
    public bool IsKeyAvailable => Console.KeyAvailable;
    public Size<int> LargestWindowSize => new(Console.LargestWindowWidth, Console.LargestWindowHeight);
    public bool IsNumberLockActive => Console.NumberLock;

    public ITextWriter Out
    {
        get => _out.Value;
        set
        {
            Console.SetOut(value.Unwrapped);
            _out = new Lazy<ITextWriter>(() => value);
        }
    }
    private Lazy<ITextWriter> _out = new(() => new TextWriterWrapper(Console.Out));

    public Encoding OutputEncoding
    {
        get => Console.OutputEncoding;
        set => Console.OutputEncoding = value;
    }
    public string Title
    {
        get => Console.Title;
        set => Console.Title = value;
    }

    public bool IsControlCTreatedAsInput
    {
        get => Console.TreatControlCAsInput;
        set => Console.TreatControlCAsInput = value;
    }

    public Rectangle<int> Window
    {
        get => new(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
        set
        {
            Console.WindowLeft = value.Left;
            Console.WindowTop = value.Top;
            Console.WindowWidth = value.Width;
            Console.WindowHeight = value.Height;
        }
    }

    public Vector2<int> WindowPosition
    {
        get => Window.Position;
        set => Window = Window with { Position = value };
    }

    public Size<int> WindowSize
    {
        get => Window.Size;
        set => Window = Window with { Size = value };
    }

    public event ConsoleCancelEventHandler? CancelKeyPress
    {
        add => Console.CancelKeyPress += value;
        remove => Console.CancelKeyPress -= value;
    }

    public void Beep() => Console.Beep();

    public void Beep(int frequency, int duration) => Console.Beep(frequency, duration);

    public void Clear() => Console.Clear();

    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop)
    {
        Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
    }

    public void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop,
        char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
    {
        Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);
    }

    public IStream OpenStandardError() => new StreamWrapper(Console.OpenStandardError());

    public IStream OpenStandardError(int bufferSize) => new StreamWrapper(Console.OpenStandardError(bufferSize));

    public IStream OpenStandardInput() => new StreamWrapper(Console.OpenStandardInput());

    public IStream OpenStandardInput(int bufferSize) => new StreamWrapper(Console.OpenStandardInput(bufferSize));

    public IStream OpenStandardOutput() => new StreamWrapper(Console.OpenStandardOutput());

    public IStream OpenStandardOutput(int bufferSize) => new StreamWrapper(Console.OpenStandardOutput(bufferSize));

    public int Read() => Console.Read();

    public ConsoleKeyInfo ReadKey() => Console.ReadKey(false);

    public ConsoleKeyInfo ReadAndInterceptKey() => Console.ReadKey(true);

    public string? ReadLine() => Console.ReadLine();

    public void ResetColor() => Console.ResetColor();

    public void SetError(TextWriter newError) => Error = new TextWriterWrapper(newError);

    public void SetIn(TextReader newIn) => In = new TextReaderWrapper(newIn);

    public void SetOut(TextWriter newOut) => Out = new TextWriterWrapper(newOut);

    public void Write(bool value) => Console.Write(value);

    public void Write(char value) => Console.Write(value);

    public void Write(char[]? buffer) => Console.Write(buffer);

    public void Write(char[] buffer, int index, int count) => Console.Write(buffer, index, count);

    public void Write(decimal value) => Console.Write(value);

    public void Write(double value) => Console.Write(value);

    public void Write(int value) => Console.Write(value);

    public void Write(long value) => Console.Write(value);

    public void Write(object? value) => Console.Write(value);

    public void Write(float value) => Console.Write(value);

    public void Write(string? value) => Console.Write(value);

    public void Write(string format, params object?[]? arg) => Console.Write(format, arg);

    public void Write(uint value) => Console.Write(value);

    public void Write(ulong value) => Console.Write(value);

    public void WriteLine() => Console.WriteLine();

    public void WriteLine(bool value) => Console.WriteLine(value);

    public void WriteLine(char value) => Console.WriteLine(value);

    public void WriteLine(char[]? buffer) => Console.WriteLine(buffer);

    public void WriteLine(char[] buffer, int index, int count) => Console.WriteLine(buffer, index, count);

    public void WriteLine(decimal value) => Console.WriteLine(value);

    public void WriteLine(double value) => Console.WriteLine(value);

    public void WriteLine(int value) => Console.WriteLine(value);

    public void WriteLine(long value) => Console.WriteLine(value);

    public void WriteLine(object? value) => Console.WriteLine(value);

    public void WriteLine(float value) => Console.WriteLine(value);

    public void WriteLine(string? value) => Console.WriteLine(value);

    public void WriteLine(string format, params object?[]? arg) => Console.WriteLine(format, arg);

    public void WriteLine(uint value) => Console.WriteLine(value);

    public void WriteLine(ulong value) => Console.WriteLine(value);
}