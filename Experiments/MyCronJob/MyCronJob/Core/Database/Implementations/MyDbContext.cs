using MyCronJob.Core.Database.Interfaces;

namespace MyCronJob.Core.Database.Implementations;

public class MyDbContext : IMyDbContext
{
    private readonly ILogger<MyDbContext> _logger;

    public MyDbContext(ILogger<MyDbContext> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Log(string message)
    {
        _logger.LogInformation(message);
    }
}