using System;
using System.Security;
using System.Threading;

namespace SynchronizationContext
{
    public class MySynchronizationContext : System.Threading.SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Console.WriteLine($"Continuation dispatched to {nameof(MySynchronizationContext)}");

            d.Invoke(state);
        }

        // Capturing the synchronization context

        //[SecurityCritical]
        //internal void SetContinuationForAwait(Action continuationAction, bool continueOnCapturedContext,
        //    bool flowExecutionContext, ref StackCrawlMark stackMark)
        //{
        //    TaskContinuation tc = null;

        //    if (continueOnCapturedContext)
        //    {
        //        var syncCtx = System.Threading.SynchronizationContext.Current;

        //        if (syncCtx != null &&
        //            syncCtx.GetType() != typeof(System.Threading.SynchronizationContext))
        //        {
        //            tc = new SynchronizationContextAwaitTaskContinuation(syncCtx, continuationAction,
        //                flowExecutionContext, ref stackMark);
        //        }
        //    }
        //}
    }
}