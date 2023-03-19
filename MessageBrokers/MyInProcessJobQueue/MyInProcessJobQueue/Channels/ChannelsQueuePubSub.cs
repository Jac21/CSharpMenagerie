using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MyInProcessJobQueue.Channels
{
    public interface IChannelsJob
    {
    }

    public class ChannelsQueuePubSub
    {
        private ChannelWriter<IChannelsJob> _writer;

        private Dictionary<Type, Action<IChannelsJob>> _handlers =
            new Dictionary<Type, Action<IChannelsJob>>();

        public ChannelsQueuePubSub()
        {
            var channel = Channel.CreateUnbounded<IChannelsJob>();
            var reader = channel.Reader;
            _writer = channel.Writer;

            Task.Factory.StartNew(async () =>
            {
                // wait while channel is not empty and still not completed
                while (await reader.WaitToReadAsync())
                {
                    var job = await reader.ReadAsync();

                    bool handlerExists =
                    _handlers.TryGetValue(job.GetType(), out Action<IChannelsJob> value);

                    if (handlerExists)
                    {
                        value.Invoke(job);
                    }
                }
            }, TaskCreationOptions.LongRunning);

        }

        public void RegisterHandler<T>(Action<T> handleAction) where T : IChannelsJob
        {
            Action<IChannelsJob> actionWrapper = (job) => handleAction((T)job);
            _handlers.Add(typeof(T), actionWrapper);
        }

        public async Task Enqueue(IChannelsJob job)
        {
            await _writer.WriteAsync(job);
        }

        public void Stop()
        {
            _writer.Complete();
        }
    }
}
