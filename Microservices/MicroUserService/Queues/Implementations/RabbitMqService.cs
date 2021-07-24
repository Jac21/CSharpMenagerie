using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using MicroUserService.Queues.Interfaces;
using RabbitMQ.Client;

namespace MicroUserService.Queues.Implementations
{
    public class RabbitMqService : IQueueService
    {
        /// <summary>
        /// C:\dev>docker run -d  -p 15672:15672 -p 5672:5672 --hostname my-rabbit --name some-rabbit rabbitmq:3-management
        /// username: guest
        /// password: guest
        /// </summary>
        /// <param name="integrationEvent"></param>
        /// <param name="eventData"></param>
        public void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory
            {
                UserName = "test",
                Password = "test"
            };

            var endpoints = new List<AmqpTcpEndpoint>
            {
                new AmqpTcpEndpoint("host.docker.internal"),
                new AmqpTcpEndpoint("localhost")
            };

            var connection = factory.CreateConnection(endpoints);

            using var channel = connection.CreateModel();

            var body = Encoding.UTF8.GetBytes(eventData);

            channel.BasicPublish("user", integrationEvent, null, body);

            Debug.WriteLine($"[x] sent {eventData}");
        }
    }
}