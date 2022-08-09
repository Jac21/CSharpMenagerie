using Microsoft.Extensions.ObjectPool;

namespace AsynchronousTimeouts;

public class Client
{
    public TimeSpan Timeout { get; }

    // called from IDisposable.Dispose
    private readonly CancellationTokenSource _clientLifetimeTokenSource;

    // zero-alloc for scenarios where class might be called multiple times (i.e., HTTP)
    private readonly ObjectPool<CancellationTokenSource> _timeoutTokenSourcePool;

    public Client(TimeSpan timeout)
    {
        Timeout = timeout;

        _clientLifetimeTokenSource = new CancellationTokenSource();

        _timeoutTokenSourcePool = ObjectPool.Create<CancellationTokenSource>();
    }

    public async Task SendAsync(CancellationToken cancellationToken = default)
    {
        var timeoutTokenSource = _timeoutTokenSourcePool.Get();

        CancellationTokenRegistration externalCancellation = default;

        if (cancellationToken.CanBeCanceled)
        {
            // call Timeout's cancel from argument CancellationToken
            cancellationToken.UnsafeRegister(static state => { ((CancellationTokenSource) state!).Cancel(); },
                timeoutTokenSource);
        }

        // same as Client's lifetime
        var clientLifetimeCancellation =
            _clientLifetimeTokenSource.Token.UnsafeRegister(
                static state => { ((CancellationTokenSource) state!).Cancel(); }, timeoutTokenSource);

        timeoutTokenSource.CancelAfter(Timeout);

        try
        {
            await SendCoreAsync(timeoutTokenSource.Token);
        }
        catch (OperationCanceledException ex) when (ex.CancellationToken == timeoutTokenSource.Token)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                // Error reason is argument CancellationToken, hold token in new OperationCanceledException
                throw new OperationCanceledException(ex.Message, ex, cancellationToken);
            }

            if (_clientLifetimeTokenSource.IsCancellationRequested)
            {
                // Error reason is client's dispose
                throw new OperationCanceledException("Client is disposed.", ex, _clientLifetimeTokenSource.Token);
            }

            // Error reason is timeout, throw TimeoutException(or any custom exception)
            throw new TimeoutException(
                $"The request was canceled due to the configured Timeout of {Timeout.TotalSeconds} seconds elapsing.",
                ex);
        }
        finally
        {
            // Unregisters
            await externalCancellation.DisposeAsync();

            await clientLifetimeCancellation.DisposeAsync();

            if (timeoutTokenSource.TryReset())
            {
                _timeoutTokenSourcePool.Return(timeoutTokenSource);
            }
        }
    }

    private static async Task SendCoreAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(10_000, cancellationToken);
    }

    public void Dispose()
    {
        _clientLifetimeTokenSource.Cancel();
        _clientLifetimeTokenSource.Dispose();
    }
}