using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroPostService.QueueServices.Interfaces
{
    public interface IQueueService
    {
        /// <summary>
        /// C:\dev>docker run -d  -p 15672:15672 -p 5672:5672 --hostname my-rabbit --name some-rabbit rabbitmq:3-management
        /// username: guest
        /// password: guest
        /// </summary>
        (IModel channel, EventingBasicConsumer consumer) ListenToMessageQueue();
    }
}