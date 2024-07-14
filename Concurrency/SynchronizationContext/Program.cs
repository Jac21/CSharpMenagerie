using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace SynchronizationContext
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WriteLine("Current Synchronization Context: " +
                      $"{System.Threading.SynchronizationContext.Current}");

            System.Threading.SynchronizationContext
                .SetSynchronizationContext(new MySynchronizationContext());

            WriteLine("Current Synchronization Context: " +
                      $"{System.Threading.SynchronizationContext.Current}");

            await Task.Delay(100);

            WriteLine("Completed!");

            ReadLine();
        }

        /// <summary>
        /// A default Synchronization Context implmentation
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        public virtual void Post(SendOrPostCallback d, object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(d), state);
        }

        /// <summary>
        /// Example event handler, method will pause on await, attach
        /// a continuation to the task awaiter. UI apps guarantee
        /// that async continuations run on the UI thread by
        /// implementing their own context/Post method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn1_Click(object sender, EventArgs e)
        {
            await Task.Delay(1000);

            // myControl.text = “After Await”;
        }
    }
}