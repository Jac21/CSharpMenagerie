using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MicroUserService.Data;
using RabbitMQ.Client;

namespace MicroUserService.Services
{
    public class IntegrationEventSenderService : BackgroundService
    {
        private readonly ILogger<IntegrationEventSenderService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private CancellationTokenSource _wakeupCancellationTokenSource = new CancellationTokenSource();

        private readonly IModel _channel;
        private readonly IBasicProperties _props;

        public IntegrationEventSenderService(IServiceScopeFactory scopeFactory,
            ILogger<IntegrationEventSenderService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;

            using var scope = _scopeFactory.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<UserServiceContext>();

            dbContext.Database.EnsureCreated();

            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ConfirmSelect(); // enable publisher confirms
            _props = _channel.CreateBasicProperties();
            _props.DeliveryMode = 2; // persist message
        }

        public void StartPublishingOutstandingIntegrationEvents()
        {
            _wakeupCancellationTokenSource.Cancel();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(IntegrationEventSenderService)} is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"{nameof(IntegrationEventSenderService)} task doing background work.");

                await PublishOutstandingIntegrationEvents(stoppingToken);
            }

            _logger.LogInformation($"{nameof(IntegrationEventSenderService)} background task is stopping.");
        }

        private async Task PublishOutstandingIntegrationEvents(CancellationToken stoppingToken)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();

                await using var dbContext = scope.ServiceProvider.GetRequiredService<UserServiceContext>();

                var events = await dbContext.IntegrationEventOutbox.OrderBy(o => o.Id).ToListAsync(stoppingToken);

                foreach (var integrationEvent in events)
                {
                    var body = Encoding.UTF8.GetBytes(integrationEvent.Data);

                    _channel.BasicPublish("user", integrationEvent.Event, _props, body);

                    _channel.WaitForConfirmsOrDie(new TimeSpan(0, 0, 5));

                    _logger.LogInformation($"Published {integrationEvent.Event} {integrationEvent.Data}");

                    dbContext.Remove(integrationEvent);
                    await dbContext.SaveChangesAsync(stoppingToken);
                }

                using var linkedCts =
                    CancellationTokenSource.CreateLinkedTokenSource(_wakeupCancellationTokenSource.Token,
                        stoppingToken);

                try
                {
                    await Task.Delay(Timeout.Infinite, linkedCts.Token);
                }
                catch (OperationCanceledException)
                {
                    if (_wakeupCancellationTokenSource.Token.IsCancellationRequested)
                    {
                        _logger.LogInformation("Publish requested");

                        var tmp = _wakeupCancellationTokenSource;

                        _wakeupCancellationTokenSource = new CancellationTokenSource();

                        tmp.Dispose();
                    }
                    else if (stoppingToken.IsCancellationRequested)
                    {
                        _logger.LogInformation("Shutting down.");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }
        }
    }
}