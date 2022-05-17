using BackgroundServicesMetrics.Core.Interfaces;
using BackgroundServicesMetrics.Models;

namespace BackgroundServicesMetrics.Core.Implementations;

class Repo : IRepo
{
    public async ValueTask InsertRedirect(Redirect redirect)
    {
        await Task.Delay(100);
    }
}