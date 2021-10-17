using System.Threading.Tasks;

namespace BackgroundWorkerQueueExample.Services
{
    public interface ISlowApiService
    {
        Task CallSlowApi(int millisecondsDelay);
    }
}