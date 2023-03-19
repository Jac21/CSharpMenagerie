using System.Diagnostics.CodeAnalysis;
using BackgroundServicesMetrics.Models;

namespace BackgroundServicesMetrics.Core.Interfaces;

public interface IAccumulatorQueue
{
    public ValueTask PushAsync([NotNull] Redirect redirect);

    public ValueTask<Redirect> PullAsync(CancellationToken cancellationToken);
}