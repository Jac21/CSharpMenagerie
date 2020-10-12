using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNetDeepDive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, Benchmarks!");

            BenchmarkRunner.Run<Md5VersusSha256Benchmark>();
        }
    }

    public class Md5VersusSha256Benchmark
    {
        private const int N = 10000;
        private readonly byte[] _data;

        private readonly SHA256 _sha256 = SHA256.Create();
        private readonly MD5 _md5 = MD5.Create();

        public Md5VersusSha256Benchmark()
        {
            _data = new byte[N];
            new Random(42).NextBytes(_data);
        }

        [Benchmark]
        public byte[] Sha256Benchmark() => _sha256.ComputeHash(_data);

        [Benchmark]
        public byte[] Md5Benchmark() => _md5.ComputeHash(_data);
    }
}