using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MyInProcessJobQueue.Channels
{
    /// <summary>
    /// Handle on multiple threads
    /// </summary>
    public class ChannelsQueueMultiThreads
    {
        private ChannelWriter<string> _writer;

        /// <summary>
        /// Can define how many dedicate threads will handle the jobs. 
        /// They are dedicated threads, so when the job queue is empty 
        /// they are just hanging there.
        /// </summary>
        /// <param name="threads"></param>
        public ChannelsQueueMultiThreads(int threads)
        {
            var channel = Channel.CreateUnbounded<string>();
            var reader = channel.Reader;
            _writer = channel.Writer;

            for (int i = 0; i < threads; i++)
            {
                var threadId = i;

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
        }

        private static void Process(string job)
        {
            Console.WriteLine(job);
        }

        public void Enqueue(string job)
        {
            _writer.WriteAsync(job).GetAwaiter().GetResult();
        }

        public void Stop()
        {
            _writer.Complete();
        }
    }
}
