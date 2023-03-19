using BackgroundServicesMetrics.Models;

namespace BackgroundServicesMetrics.Core.Interfaces;

public interface IRepo
{
    ValueTask InsertRedirect(Redirect redirect);
}