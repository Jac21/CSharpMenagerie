using Microsoft.Extensions.DependencyInjection.Extensions;
using MyCronJob.Core.Entries;
using MyCronJob.Core.Interfaces;
using MyCronJob.Scheduler;
using NCrontab;

namespace MyCronJob.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCronJob<T>(this IServiceCollection services, string cronExpression) where T : class, ICronJob
    {
        var cron = CrontabSchedule.TryParse(cronExpression)
                   ?? throw new ArgumentException("Invalid cron expression", nameof(cronExpression));

        var entry = new CronRegistryEntry(typeof(T), cron);

        services.AddHostedService<CronScheduler>();
        services.TryAddSingleton<T>();
        services.AddSingleton(entry);

        return services;
    }
}