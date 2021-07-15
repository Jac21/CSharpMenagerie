using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;

namespace MicroUserService.Queues
{
    public class RabbitMqService : IQueueService
    {
        /// <summary>
        /// C:\dev>docker run -d  -p 15672:15672 -p 5672:5672 --hostname my-rabbit --name some-rabbit rabbitmq:3-management
        /// </summary>
        /// <param name="integrationEvent"></param>
        /// <param name="eventData"></param>
        public void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            // TODO: re-use and close connections, channel, etc.
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            var body = Encoding.UTF8.GetBytes(eventData);

            channel.BasicPublish("user", integrationEvent, null, body);

            Debug.WriteLine($"[x] sent {eventData}");
        }
    }
}