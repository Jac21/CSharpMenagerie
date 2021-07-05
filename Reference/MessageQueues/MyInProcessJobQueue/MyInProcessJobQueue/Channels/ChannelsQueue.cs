using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MyInProcessJobQueue.Channels
{
    /// <summary>
    /// Has a fully asynchronous API. It has blocking functionality with 
    /// WaitToReadAsync, where it will wait on an empty channel until a job 
    /// is added to the channel or until writer.Complete() is called.
    /// 
    /// It also has Bound capabilities, where the channel has a limit.
    /// When the limit is reached, the WriteAsync task waits until the 
    /// channel can add the given job. That’s why Write is a Task.
    /// </summary>
    public class ChannelsQueue
    {
        private ChannelWriter<string> _writer;

        public ChannelsQueue()
        {
            var channel = Channel.CreateUnbounded<string>();
            var reader = channel.Reader;
            _writer = channel.Writer;

            Task.Factory.StartNew(async () =>
            {
                // wait while channel is not empty and still not completed
                while (await reader.WaitToReadAsync())
                {
                    var job = await reader.ReadAsync();
                    Process(job);
                }
            }, TaskCreationOptions.LongRunning);
        }

        private static void Process(string job)
        {
            Console.WriteLine(job);
        }

        public async Task Enqueue(string job)
        {
            await _writer.WriteAsync(job);
        }

        public void Stop()
        {
            _writer.Complete();
        }
    }
}