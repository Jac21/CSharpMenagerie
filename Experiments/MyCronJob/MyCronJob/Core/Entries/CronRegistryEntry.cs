using NCrontab;

namespace MyCronJob.Core.Entries;

public sealed record CronRegistryEntry(Type Type, CrontabSchedule CrontabSchedule);