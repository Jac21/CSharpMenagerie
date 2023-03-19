using MyCronJob.Core.Entries;
using MyCronJob.Core.Interfaces;

namespace MyCronJob.Scheduler;

public class CronScheduler : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IReadOnlyCollection<CronRegistryEntry> _cronJobs;

    public CronScheduler(
        IServiceProvider serviceProvider,
        IEnumerable<CronRegistryEntry> cronJobs)
    {
        // Use the container
        _serviceProvider = serviceProvider;
        _cronJobs = cronJobs.ToList();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var tickTimer = new PeriodicTimer(TimeSpan.FromSeconds(30));

        // create map of upcoming entries
        var runMap = new Dictionary<DateTime, List<Type>>();

        while (await tickTimer.WaitForNextTickAsync(stoppingToken))
        {
            // to minute precision
            var now = UtcNowMinutePrecision();

            // run jobs that are in the map
            RunActiveJobs(runMap, now, stoppingToken);

            // get next run for next tick
            runMap = GetJobRuns();
        }
    }

    private void RunActiveJobs(IReadOnlyDictionary<DateTime, List<Type>> runMap, DateTime now,
        CancellationToken stoppingToken)
    {
        if (!runMap.TryGetValue(now, out var currentRuns)) return;

        foreach (var run in currentRuns)
        {
            var job = (ICronJob) _serviceProvider.GetRequiredService(run);

            job.Run(stoppingToken);
        }
    }

    private Dictionary<DateTime, List<Type>> GetJobRuns()
    {
        var runMap = new Dictionary<DateTime, List<Type>>();

        foreach (var cronJob in _cronJobs)
        {
            var utcNow = DateTime.UtcNow;
            var runDates = cronJob.CrontabSchedule.GetNextOccurrences(utcNow, utcNow.AddMinutes(1));

            if (runDates is not null)
            {
                AddJobRuns(runMap, runDates, cronJob);
            }
        }

        return runMap;
    }

    private static void AddJobRuns(IDictionary<DateTime, List<Type>> runMap, IEnumerable<DateTime> runDates,
        CronRegistryEntry cron)
    {
        foreach (var runDate in runDates)
        {
            if (runMap.TryGetValue(runDate, out var value))
            {
                value.Add(cron.Type);
            }
            else
            {
                runMap[runDate] = new List<Type>
                {
                    cron.Type
                };
            }
        }
    }

    private static DateTime UtcNowMinutePrecision()
    {
        var now = DateTime.UtcNow;

        return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
    }
}