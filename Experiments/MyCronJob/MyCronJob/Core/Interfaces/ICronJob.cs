namespace MyCronJob.Core.Interfaces;

public interface ICronJob
{
    Task Run(CancellationToken token = default);
}