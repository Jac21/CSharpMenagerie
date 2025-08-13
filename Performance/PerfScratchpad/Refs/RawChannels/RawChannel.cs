using System.Collections.Concurrent;

namespace PerfScratchpad.Refs.RawChannels;

public interface IRawChannel<T>
{
    public void Write(T value);

    public ValueTask<T> ReadAsync(CancellationToken cancellationToken);
}

public class RawChannel<T> : IRawChannel<T>
{
    private readonly ConcurrentQueue<T> _queue = new();
    private readonly SemaphoreSlim _semaphoreSlim = new(0);

    public void Write(T value)
    {
        // storage
        _queue.Enqueue(value);

        // notification
        _semaphoreSlim.Release();
    }

    public async ValueTask<T> ReadAsync(CancellationToken cancellationToken = default)
    {
        // wait
        await _semaphoreSlim
            .WaitAsync(cancellationToken)
            .ConfigureAwait(false);

        // retrieve
        _queue.TryDequeue(out var item);

        return item ?? throw new InvalidOperationException();
    }
}