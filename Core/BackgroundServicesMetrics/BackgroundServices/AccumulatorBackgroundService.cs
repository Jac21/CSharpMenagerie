using BackgroundServicesMetrics.Core.Interfaces;

namespace BackgroundServicesMetrics.BackgroundServices;

public class AccumulatorBackgroundService : BackgroundService
{
    private readonly IAccumulatorQueue _queue;
    private readonly ILogger<AccumulatorBackgroundService> _logger;
    private readonly IRepo _repo;

    public AccumulatorBackgroundService(ILogger<AccumulatorBackgroundService> logger, IAccumulatorQueue queue,
        IRepo repo)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _queue = queue ?? throw new ArgumentNullException(nameof(queue));
        _repo = repo;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var redirect = await _queue.PullAsync(stoppingToken);

                await _repo.InsertRedirect(redirect);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failure while processing queue {ex}");
            }
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping Background Service");
        
        await base.StopAsync(cancellationToken);
    }
}