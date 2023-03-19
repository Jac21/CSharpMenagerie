using MyCronJob.Core.Interfaces;

namespace MyCronJob.Core.Implementations;

public class CronJob : ICronJob
{
    private readonly ILogger<CronJob> _logger;

    public CronJob(ILogger<CronJob> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task Run(CancellationToken token = default)
    {
        _logger.LogInformation("Hello from {CronJobName} at {ShortTimeString}", nameof(CronJob),
            DateTime.UtcNow.ToShortTimeString());
        
        return Task.CompletedTask;
    }
}