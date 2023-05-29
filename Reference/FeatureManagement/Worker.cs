using FeatureManagement.Flags;
using Microsoft.FeatureManagement;

namespace FeatureManagement;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    private readonly IFeatureManager _featureManager;

    public Worker(ILogger<Worker> logger, IFeatureManager featureManager)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _featureManager = featureManager ?? throw new ArgumentNullException(nameof(featureManager));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // feature toggle usage
            if (await _featureManager.IsEnabledAsync(FeatureFlags.ExperimentalFeature))
            {
                _logger.LogInformation("Worker running with experimental feature turned ON: {Time}",
                    DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
            else
            {
                _logger.LogInformation("Worker running with experimental feature turned OFF: {Time}",
                    DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}