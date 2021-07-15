namespace MicroUserService.Queues
{
    public interface IQueueService
    {
        /// <summary>
        /// C:\dev>docker run -d  -p 15672:15672 -p 5672:5672 --hostname my-rabbit --name some-rabbit rabbitmq:3-management
        /// </summary>
        /// <param name="integrationEvent"></param>
        /// <param name="eventData"></param>
        void PublishToMessageQueue(string integrationEvent, string eventData);
    }
}