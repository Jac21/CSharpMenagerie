using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RetryWithExponentialBackoff
{
    public sealed class RetryWithExponentialBackoff
    {
        private readonly int _maxRetries;
        private readonly int _delayInMilliseconds;
        private readonly int _maxDelayInMilliseconds;

        public RetryWithExponentialBackoff(int maxRetries = 50, int delayInMilliseconds = 200,
            int maxDelayInMilliseconds = 2000)
        {
            _maxRetries = maxRetries;
            _delayInMilliseconds = delayInMilliseconds;
            _maxDelayInMilliseconds = maxDelayInMilliseconds;
        }

        public async Task RunAsync(Func<Task> func)
        {
            var backoff = new ExponentialBackoff(_maxRetries,
                _delayInMilliseconds,
                _maxDelayInMilliseconds);

            retry:
            try
            {
                await func();
            }
            catch (Exception ex) when (ex is TimeoutException ||
                                       ex is System.Net.Http.HttpRequestException)
            {
                Debug.WriteLine("Exception raised is: " +
                                ex.GetType() +
                                " –Message: " + ex.Message +
                                " -- Inner Message: " +
                                ex.InnerException?.Message);

                await backoff.Delay();

                goto retry;
            }
        }
    }
}