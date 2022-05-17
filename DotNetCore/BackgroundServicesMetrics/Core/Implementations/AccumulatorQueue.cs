using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;
using BackgroundServicesMetrics.Core.Interfaces;
using BackgroundServicesMetrics.Models;

namespace BackgroundServicesMetrics.Core.Implementations;

public class AccumulatorQueue : IAccumulatorQueue
{
    private readonly Channel<Redirect> _queue;
    private readonly ILogger<AccumulatorQueue> _logger;

    public AccumulatorQueue(ILogger<AccumulatorQueue> logger)
    {
        _logger = logger ?? throw new ArgumentNullException();

        var opts = new BoundedChannelOptions(100)
        {
            FullMode = BoundedChannelFullMode.Wait
        };

        _queue = Channel.CreateBounded<Redirect>(opts);
    }

    public async ValueTask PushAsync([NotNull] Redirect redirect)
    {
        await _queue.Writer.WriteAsync(redirect);

        _logger.LogInformation($"Added redirect {redirect.Id} to queue");
    }

    public async ValueTask<Redirect> PullAsync(CancellationToken cancellationToken)
    {
        var result = await _queue.Reader.ReadAsync(cancellationToken);

        _logger.LogInformation($"Removed redirect {result.Id} from queue");

        return result;
    }
}