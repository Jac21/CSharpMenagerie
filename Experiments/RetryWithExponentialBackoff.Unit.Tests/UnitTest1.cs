using System.Threading.Tasks;
using NUnit.Framework;

namespace RetryWithExponentialBackoff.Unit.Tests
{
    public class RetryWithExponentialBackoffTests
    {
        private RetryWithExponentialBackoff _retryWithExponentialBackoff;

        [SetUp]
        public void Setup()
        {
            _retryWithExponentialBackoff = new RetryWithExponentialBackoff();
        }

        [Test]
        public async Task RetryWithExponentialBackoff_Success_Test()
        {
            await _retryWithExponentialBackoff.RunAsync(async () => { await Task.Delay(500); });

            Assert.Pass();
        }
    }
}