namespace ToolBX.NetAbstractions.Memory;

public interface IGarbageCollector
{
    /// <summary>Gets garbage collection memory information.</summary>
    /// <returns>An object that contains information about the garbage collector's memory usage.</returns>
    GCMemoryInfo GetMemoryInfo();

    /// <summary>Gets garbage collection memory information.</summary>
    /// <param name="kind">The kind of collection for which to retrieve memory information.</param>
    /// <returns>An object that contains information about the garbage collector's memory usage.</returns>
    GCMemoryInfo GetMemoryInfo(GCKind kind);

    void AddMemoryPressure(long bytesAllocated);
    void RemoveMemoryPressure(long bytesAllocated);
    int GetGeneration(object obj);
    void Collect(int generation);
    void Collect();
    void Collect(int generation, GCCollectionMode mode);
    void Collect(int generation, GCCollectionMode mode, bool blocking);
    void Collect(int generation, GCCollectionMode mode, bool blocking, bool compacting);
    int CollectionCount(int generation);
    void KeepAlive(object obj);
    int GetGeneration(WeakReference wo);
    int MaxGeneration { get; }
    void WaitForPendingFinalizers();
    void SuppressFinalize(object obj);
    void ReRegisterForFinalize(object obj);
    long GetTotalMemory(bool forceFullCollection);
    long GetAllocatedBytesForCurrentThread();

    /// <summary>
    /// Get a count of the bytes allocated over the lifetime of the process.
    /// <param name="precise">If true, gather a precise number, otherwise gather a fairly count. Gathering a precise value triggers at a significant performance penalty.</param>
    /// </summary>
    long GetTotalAllocatedBytes(bool precise = false);

    void RegisterForFullNotification(int maxGenerationThreshold, int largeObjectHeapThreshold);
    void CancelFullNotification();
    GCNotificationStatus WaitForFullApproach();
    GCNotificationStatus WaitForFullApproach(int millisecondsTimeout);
    GCNotificationStatus WaitForFullComplete();
    GCNotificationStatus WaitForFullComplete(int millisecondsTimeout);
    bool TryStartNoRegion(long totalSize);
    bool TryStartNoRegion(long totalSize, long largeObjectHeapSize);
    bool TryStartNoRegion(long totalSize, bool disallowFullBlockingGC);
    bool TryStartNoRegion(long totalSize, long largeObjectHeapSize, bool disallowFullBlockingGC);
    void EndNoRegion();

    /// <summary>
    /// Allocate an array while skipping zero-initialization if possible.
    /// </summary>
    /// <typeparam name="T">Specifies the type of the array element.</typeparam>
    /// <param name="length">Specifies the length of the array.</param>
    /// <param name="pinned">Specifies whether the allocated array must be pinned.</param>
    /// <remarks>
    /// If pinned is set to true, <typeparamref name="T"/> must not be a reference type or a type that contains object references.
    /// </remarks>
    IReadOnlyList<T> AllocateUninitializedArray<T>(int length, bool pinned = false);

    /// <summary>
    /// Allocate an array.
    /// </summary>
    /// <typeparam name="T">Specifies the type of the array element.</typeparam>
    /// <param name="length">Specifies the length of the array.</param>
    /// <param name="pinned">Specifies whether the allocated array must be pinned.</param>
    /// <remarks>
    /// If pinned is set to true, <typeparamref name="T"/> must not be a reference type or a type that contains object references.
    /// </remarks>
    IReadOnlyList<T> AllocateArray<T>(int length, bool pinned = false);
}

[AutoInject(ServiceLifetime.Singleton)]
public class GarbageCollector : IGarbageCollector
{
    public int MaxGeneration => GC.MaxGeneration;

    public GCMemoryInfo GetMemoryInfo() => GC.GetGCMemoryInfo();

    public GCMemoryInfo GetMemoryInfo(GCKind kind) => GC.GetGCMemoryInfo(kind);

    public void AddMemoryPressure(long bytesAllocated) => GC.AddMemoryPressure(bytesAllocated);

    public void RemoveMemoryPressure(long bytesAllocated) => GC.RemoveMemoryPressure(bytesAllocated);

    public int GetGeneration(object obj) => GC.GetGeneration(obj);

    public void Collect(int generation) => GC.Collect(generation);

    public void Collect() => GC.Collect();

    public void Collect(int generation, GCCollectionMode mode) => GC.Collect(generation, mode);

    public void Collect(int generation, GCCollectionMode mode, bool blocking) => GC.Collect(generation, mode, blocking);

    public void Collect(int generation, GCCollectionMode mode, bool blocking, bool compacting) => GC.Collect(generation, mode, blocking, compacting);

    public int CollectionCount(int generation) => GC.CollectionCount(generation);

    public void KeepAlive(object obj) => GC.KeepAlive(obj);

    public int GetGeneration(WeakReference wo) => GC.GetGeneration(wo);

    public void WaitForPendingFinalizers() => GC.WaitForPendingFinalizers();

    public void SuppressFinalize(object obj) => GC.SuppressFinalize(obj);

    public void ReRegisterForFinalize(object obj) => GC.ReRegisterForFinalize(obj);

    public long GetTotalMemory(bool forceFullCollection) => GC.GetTotalMemory(forceFullCollection);

    public long GetAllocatedBytesForCurrentThread() => GC.GetAllocatedBytesForCurrentThread();

    public long GetTotalAllocatedBytes(bool precise = false) => GC.GetTotalAllocatedBytes(precise);

    public void RegisterForFullNotification(int maxGenerationThreshold, int largeObjectHeapThreshold) => GC.RegisterForFullGCNotification(maxGenerationThreshold, largeObjectHeapThreshold);

    public void CancelFullNotification() => GC.CancelFullGCNotification();

    public GCNotificationStatus WaitForFullApproach() => GC.WaitForFullGCApproach();

    public GCNotificationStatus WaitForFullApproach(int millisecondsTimeout) => GC.WaitForFullGCApproach(millisecondsTimeout);

    public GCNotificationStatus WaitForFullComplete() => GC.WaitForFullGCComplete();

    public GCNotificationStatus WaitForFullComplete(int millisecondsTimeout) => GC.WaitForFullGCComplete(millisecondsTimeout);

    public bool TryStartNoRegion(long totalSize) => GC.TryStartNoGCRegion(totalSize);

    public bool TryStartNoRegion(long totalSize, long largeObjectHeapSize) => GC.TryStartNoGCRegion(totalSize, largeObjectHeapSize);

    public bool TryStartNoRegion(long totalSize, bool disallowFullBlockingGC) => GC.TryStartNoGCRegion(totalSize, disallowFullBlockingGC);

    public bool TryStartNoRegion(long totalSize, long largeObjectHeapSize, bool disallowFullBlockingGC) => GC.TryStartNoGCRegion(totalSize, largeObjectHeapSize, disallowFullBlockingGC);

    public void EndNoRegion() => GC.EndNoGCRegion();

    public IReadOnlyList<T> AllocateUninitializedArray<T>(int length, bool pinned = false) => GC.AllocateUninitializedArray<T>(length, pinned);

    public IReadOnlyList<T> AllocateArray<T>(int length, bool pinned = false) => GC.AllocateArray<T>(length, pinned);
}