using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MyInProcessJobQueue.RxQueues
{
    /// <summary>
    /// You need a simple Job Queue with a single thread-pool handler.
    /// You need a simple Job Queue with different handlers for different 
    /// job types(publisher/subscriber). If your requirements require customizations 
    /// beyond the basic use case, you might run into limitations.
    /// </summary>
    public class RxQueuePubSub
    {
        Subject<IJob> _jobs = new Subject<IJob>();
        private IConnectableObservable<IJob> _connectableObservable;

        public RxQueuePubSub()
        {
            _connectableObservable = _jobs.ObserveOn(Scheduler.Default).Publish();
            _connectableObservable.Connect();
        }

        public void Enqueue(IJob job)
        {
            _jobs.OnNext(job);
        }

        public void RegisterHandler<T>(Action<T> handleAction) where T : IJob
        {
            _connectableObservable.OfType<T>().Subscribe(handleAction);
        }
    }
}