using System;
using System.Threading.Tasks;
using MyInProcessJobQueue.Channels;
using MyInProcessJobQueue.Queues;
using MyInProcessJobQueue.RxQueues;

namespace MyInProcessJobQueue
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, Queues!\n");

            // quick test
            BlockingCollectionQueue blockingCollectionQueue = new BlockingCollectionQueue();

            blockingCollectionQueue.Enqueue("job one");
            blockingCollectionQueue.Enqueue("job two");
            blockingCollectionQueue.Enqueue("job three");

            //////////////////////////////////////////////////////////////////////////

            Console.WriteLine("Hello, RxQueues!\n");

            var q = new RxQueuePubSub();

            q.RegisterHandler<JobA>(j => Console.WriteLine(Global.Counter));
            q.RegisterHandler<JobB>(j => Global.Counter += 1);

            q.Enqueue(new JobA());//print
            q.Enqueue(new JobB());//add
            q.Enqueue(new JobA());//print
            q.Enqueue(new JobB());//add
            q.Enqueue(new JobB());//add
            q.Enqueue(new JobA());//print

            //////////////////////////////////////////////////////////////////////////

            var channelsQ = new ChannelsQueuePubSub();

            channelsQ.RegisterHandler<ChannelsJobA>(j => Console.WriteLine(Global.Counter));
            channelsQ.RegisterHandler<ChannelsJobB>(j => Global.Counter += 1);

            await channelsQ.Enqueue(new ChannelsJobA());//print
            await channelsQ.Enqueue(new ChannelsJobB());//add
            await channelsQ.Enqueue(new ChannelsJobA());//print
            await channelsQ.Enqueue(new ChannelsJobB());//add
            await channelsQ.Enqueue(new ChannelsJobB());//add
            await channelsQ.Enqueue(new ChannelsJobA());//print

            Console.ReadLine();
        }
    }

    public class JobA : IJob { }

    public class JobB : IJob { }

    public static class Global
    {
        public static int Counter = 0;
    }

    public class ChannelsJobA : IChannelsJob { }

    public class ChannelsJobB : IChannelsJob { }

    public static class ChannelsGlobal
    {
        public static int Counter = 0;
    }
}