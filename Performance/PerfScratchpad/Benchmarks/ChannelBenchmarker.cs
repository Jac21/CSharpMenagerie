using BenchmarkDotNet.Attributes;
using PerfScratchpad.Configuration;
using static PerfScratchpad.Demonstrations.ChannelDemonstrations;

namespace PerfScratchpad.Benchmarks;

/// <summary>
/// Benchmarking class for Channels
/// </summary>
[Config(typeof(Config))]
public class ChannelBenchmarker
{
    [Benchmark]
    public async Task UnboundedProducerConsumerChannelBenchmark() => await UnboundedProducerConsumerChannelDemo();
}