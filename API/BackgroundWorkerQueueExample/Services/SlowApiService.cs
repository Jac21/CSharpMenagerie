using System;
using System.Threading.Tasks;
using BackgroundWorkerQueueExample.Queues;
using Microsoft.Extensions.Logging;

namespace BackgroundWorkerQueueExample.Services
{
    public class SlowApiService : ISlowApiService
    {
        private readonly ILogger<SlowApiService> _logger;
        private readonly BackgroundWorkerQueue _backgroundWorkerQueue;

        public SlowApiService(ILogger<SlowApiService> logger, BackgroundWorkerQueue backgroundWorkerQueue)
        {
            _logger = logger;
            _backgroundWorkerQueue = backgroundWorkerQueue;
        }

        public async Task CallSlowApi(int millisecondsDelay)
        {
            _logger.LogInformation($"Starting at {DateTime.UtcNow.TimeOfDay}");

            _backgroundWorkerQueue.QueueBackgroundWorkItem(async token =>
            {
                await Task.Delay(millisecondsDelay, token);

                _logger.LogInformation($"Done at {DateTime.UtcNow.TimeOfDay}");
            });
        }
    }
}