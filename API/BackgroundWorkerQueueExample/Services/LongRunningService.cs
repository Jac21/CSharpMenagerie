using System.Threading;
using System.Threading.Tasks;
using BackgroundWorkerQueueExample.Queues;
using Microsoft.Extensions.Hosting;

namespace BackgroundWorkerQueueExample.Services
{
    public class LongRunningService : BackgroundService
    {
        private readonly BackgroundWorkerQueue _queue;

        public LongRunningService(BackgroundWorkerQueue queue)
        {
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await _queue.DequeueTask(stoppingToken);

                await workItem(stoppingToken);
            }
        }
    }
}