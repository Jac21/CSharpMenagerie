using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicroPostService.Data.Interfaces;
using MicroPostService.Entities;
using MicroPostService.QueueServices.Interfaces;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroPostService.BackgroundServices
{
    public class IntegrationEventListenerService : BackgroundService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IQueueService _queueService;

        public IntegrationEventListenerService(IDataAccess dataAccess,
            IQueueService queueService)
        {
            _dataAccess = dataAccess;
            _queueService = queueService;
        }

        private async Task ListenForIntegrationEvents(CancellationToken stoppingToken)
        {
            try
            {
                var (channel, consumer) = _queueService.ListenToMessageQueue();

                consumer.Received += async (model, ea) => { await HandleReceivedEventsPerContext(channel, ea); };

                channel.BasicConsume(queue: "user.postservicesingleactiveconsumer",
                    false,
                    consumer);

                try
                {
                    await Task.Delay(Timeout.Infinite, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Shutting down.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task HandleReceivedEventsPerContext(IModel channel, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"IntegrationEvent {message}");

            var data = JObject.Parse(message);
            var type = ea.RoutingKey;

            var user = new User
            {
                Id = data["id"].Value<int>(),
                Name = data["name"].Value<string>(),
                Version = data["version"].Value<int>()
            };

            switch (type)
            {
                case "user.add":
                    await _dataAccess.AddUser(user);

                    break;
                case "user.update":
                    await _dataAccess.UpdateUser(user);

                    break;
                case "user.delete":
                    await _dataAccess.DeleteUser(user);

                    break;
                default:
                    Console.WriteLine($"Unknown message: {type}");
                    break;
            }

            channel.BasicAck(ea.DeliveryTag, false);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ListenForIntegrationEvents(stoppingToken);
            }
        }
    }
}