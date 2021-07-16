using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicroUserService.Data;
using RabbitMQ.Client;

namespace MicroUserService.Services
{
    public class IntegrationEventSenderService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public IntegrationEventSenderService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;

            using var scope = _scopeFactory.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<UserServiceContext>();

            dbContext.Database.EnsureCreated();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await PublishOutstandingIntegrationEvents(stoppingToken);
            }
        }

        private async Task PublishOutstandingIntegrationEvents(CancellationToken stoppingToken)
        {
            try
            {
                var factory = new ConnectionFactory();
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                while (!stoppingToken.IsCancellationRequested)
                {
                    using var scope = _scopeFactory.CreateScope();

                    await using var dbContext = scope.ServiceProvider.GetRequiredService<UserServiceContext>();

                    var events = await dbContext.IntegrationEventOutbox.OrderBy(o => o.Id).ToListAsync(stoppingToken);

                    foreach (var integrationEvent in events)
                    {
                        var body = Encoding.UTF8.GetBytes(integrationEvent.Data);

                        channel.BasicPublish("user", integrationEvent.Event, null, body);

                        Console.WriteLine($"Published {integrationEvent.Event} {integrationEvent.Data}");

                        dbContext.Remove(integrationEvent);
                        await dbContext.SaveChangesAsync(stoppingToken);
                    }
                }

                await Task.Delay(1000, stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}