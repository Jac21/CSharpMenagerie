using MyCronJob.Core.Database.Implementations;
using MyCronJob.Core.Interfaces;

namespace MyCronJob.Core.Implementations;

public class JobWithScopedDependency : ICronJob
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<JobWithScopedDependency> _logger;

    public JobWithScopedDependency(IServiceProvider serviceProvider, ILogger<JobWithScopedDependency> logger)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task Run(CancellationToken token = default)
    {
        using var scope = _serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

        return Task.CompletedTask;
    }
}