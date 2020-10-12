using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
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

    [SimpleJob(RunStrategy.Throughput)] // set run strategy
    public class Md5VersusSha256Benchmark
    {
        private SHA256 _sha256;
        private MD5 _md5;

        [GlobalSetup]
        public void Setup()
        {
            _sha256 = SHA256.Create();
            _md5 = MD5.Create();
        }

        [Benchmark(Baseline = true)] // creates an additional ratio metric
        [Arguments(10000)] // allows for multiple runs with varying values
        public byte[] Sha256Benchmark(int n)
        {
            var data = new byte[n];
            new Random(42).NextBytes(data);

            return _sha256.ComputeHash(data);
        }

        [Benchmark]
        [Arguments(10000)]
        public byte[] Md5Benchmark(int n)
        {
            var data = new byte[n];
            new Random(42).NextBytes(data);

            return _md5.ComputeHash(data);
        }

        [Benchmark]
        [Arguments(10000)]
        public int Sha256SpanBenchmark(int n)
        {
            Span<byte> data = stackalloc byte[n];
            new Random(42).NextBytes(data);

            Span<byte> destination = stackalloc byte[_md5.HashSize / 8];
            var slice = data.Slice(0, n);

            _sha256.TryComputeHash(slice, destination, out var bytesWritten);

            return bytesWritten;
        }

        [Benchmark]
        [Arguments(10000)]
        public int Md5SpanBenchmark(int n)
        {
            Span<byte> data = stackalloc byte[n];
            new Random(42).NextBytes(data);

            Span<byte> destination = stackalloc byte[_md5.HashSize / 8];
            var slice = data.Slice(0, n);

            _md5.TryComputeHash(slice, destination, out var bytesWritten);

            return bytesWritten;
        }
    }
}