// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using PerfScratchpad.Benchmarks;

Console.WriteLine("Hello, Benchmarks!");

BenchmarkRunner.Run<BlockingCollectionBenchmarker>();
BenchmarkRunner.Run<ArrayPooledBlockingCollectionBenchmarker>();
BenchmarkRunner.Run<ChannelBenchmarker>();