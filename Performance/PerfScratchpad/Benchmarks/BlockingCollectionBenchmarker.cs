using System.Collections.Concurrent;
using BenchmarkDotNet.Attributes;
using static PerfScratchpad.Demonstrations.BlockingCollectionDemonstrations;
using PerfScratchpad.Configuration;

#pragma warning disable CS8618

namespace PerfScratchpad.Benchmarks;

/// <summary>
/// Benchmarking class for BlockingCollection<T />
/// </summary>
[Config(typeof(Config))]
public class BlockingCollectionBenchmarker
{
    private BlockingCollection<int> _bc;

    [GlobalSetup]
    public void Setup()
    {
        _bc = new BlockingCollection<int>();
    }

    [Benchmark]
    public async Task AddTakeBenchmark() => await BC_AddTakeCompleteAdding();

    [Benchmark]
    public void TryTakeBenchmark() => BC_TryTake(_bc);

    [Benchmark]
    public void FromToAnyBenchmark() => BC_FromToAny();

    [Benchmark]
    public async Task GetConsumingEnumerableBenchmark() => await BC_GetConsumingEnumerable();
}