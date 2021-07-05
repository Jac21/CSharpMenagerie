using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MyInProcessJobQueue.RxQueues
{
    public class RxQueueWithScheduler
    {
        Subject<string> _jobs = new Subject<string>();

        public RxQueueWithScheduler()
        {
            _jobs.ObserveOn(Scheduler.Default).Subscribe(job =>
            {
                Console.WriteLine(job);
            });
        }

        public void Enqueue(string job)
        {
            _jobs.OnNext(job);
        }
    }
}