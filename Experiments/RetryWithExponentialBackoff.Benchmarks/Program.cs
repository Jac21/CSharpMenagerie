using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace RetryWithExponentialBackoff.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }

    public class RetryWithExponentialBackoffBenchmarks
    {
        private readonly RetryWithExponentialBackoff _retryWithExponentialBackoff = new RetryWithExponentialBackoff();

        [Benchmark]
        public async Task RetryDelayBenchmark()
        {
            await _retryWithExponentialBackoff.RunAsync(async () => { await Task.Delay(1); });
        }
    }
}