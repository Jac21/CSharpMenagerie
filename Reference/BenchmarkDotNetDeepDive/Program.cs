using BenchmarkDotNet.Running;

namespace BenchmarkDotNetDeepDive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // general runner
            BenchmarkRunner.Run<Md5VersusSha256Benchmark>();
        }
    }
}