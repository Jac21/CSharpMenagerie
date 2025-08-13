using BenchmarkDotNet.Attributes;
using PerfScratchpad.Configuration;
using static PerfScratchpad.Demonstrations.DataflowDemonstrations;

namespace PerfScratchpad.Benchmarks;

/// <summary>
/// Benchmarking class for Dataflow
/// </summary>
[Config(typeof(Config))]
public class DataflowBenchmarker
{
    [Benchmark]
    public async Task BufferBlockDemonstrations() => await BufferBlockDemo();
}