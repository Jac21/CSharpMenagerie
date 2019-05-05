using System;
using System.Reactive.Subjects;

namespace MyInProcessJobQueue.RxQueues
{
    public class RxQueueWithSubject
    {
        Subject<string> _jobs = new Subject<string>();

        public RxQueueWithSubject()
        {
            _jobs.Subscribe(job =>
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