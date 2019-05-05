using System;
using MyInProcessJobQueue.Queues;
using MyInProcessJobQueue.RxQueues;

namespace MyInProcessJobQueue
{
    public class Program
    {
        static void Main()
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

            Console.ReadLine();
        }
    }

    public class JobA : IJob { }

    public class JobB : IJob { }

    public static class Global
    {
        public static int Counter = 0;
    }
}