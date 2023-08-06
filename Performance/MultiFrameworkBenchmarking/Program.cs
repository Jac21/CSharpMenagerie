// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using MultiFrameworkBenchmarking;

Console.WriteLine("Hello, Benchmarks!");

BenchmarkRunner.Run<DateTimeCreationBenchmarks>();