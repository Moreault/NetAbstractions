namespace ToolBX.NetAbstractions;

public interface IInstanceWrapper<T> : IEquatable<T>
{
    T Unwrapped { get; }
}