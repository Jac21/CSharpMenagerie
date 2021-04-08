using System;
using System.Threading.Tasks;

namespace RetryWithExponentialBackoff
{
    public struct ExponentialBackoff
    {
        private readonly int _maxRetries;
        private readonly int _delayInMilliseconds;
        private readonly int _maxDelayInMilliseconds;

        private int _retries, _pow;

        public ExponentialBackoff(int maxRetries, int delayInMilliseconds, int maxDelayInMilliseconds)
        {
            _maxRetries = maxRetries;
            _delayInMilliseconds = delayInMilliseconds;
            _maxDelayInMilliseconds = maxDelayInMilliseconds;

            _retries = 0;
            _pow = 1;
        }

        public Task Delay()
        {
            if (_retries == _maxRetries)
            {
                throw new TimeoutException("Max retry attempts exceeded");
            }

            _retries += 1;

            if (_retries < 31)
            {
                _pow <<= 1; // _pow = Pow(2, _retries - 1)
            }

            var delay = Math.Min(_delayInMilliseconds * (_pow - 1) / 2, _maxDelayInMilliseconds);

            return Task.Delay(delay);
        }
    }
}