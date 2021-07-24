using System.Collections.Generic;
using MicroPostService.QueueServices.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroPostService.QueueServices.Implementations
{
    public class RabbitMqService : IQueueService
    {
        /// <summary>
        /// C:\dev>docker run -d  -p 15672:15672 -p 5672:5672 --hostname my-rabbit --name some-rabbit rabbitmq:3-management
        /// username: guest
        /// password: guest
        /// </summary>
        public (IModel channel, EventingBasicConsumer consumer) ListenToMessageQueue()
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
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            var arguments = new Dictionary<string, object>
            {
                {"x-single-active-consumer", true}
            };

            channel.QueueDeclare("user.postservicesingleactiveconsumer", false, false, false, arguments);

            channel.ExchangeDeclare("userloadtest", "fanout");
            channel.QueueBind("user.postservicesingleactiveconsumer", "userloadtest", "");

            return (channel, consumer);
        }
    }
}