using BenchmarkDotNet.Attributes;
using PerfScratchpad.Configuration;
using PerfScratchpad.Demonstrations;
using PerfScratchpad.Refs;
using PerfScratchpad.Refs.ArrayPooledBlockingCollection;

#pragma warning disable CS8618

namespace PerfScratchpad.Benchmarks;

/// <summary>
/// Benchmarking class for BlockingCollection<T />
/// </summary>
[Config(typeof(Config))]
public class ArrayPooledBlockingCollectionBenchmarker
{
    private ArrayPooledBlockingCollection<IntEvent> _bc;

    [GlobalSetup]
    public void Setup()
    {
        const int bufferSize = 1024;

        _bc = new ArrayPooledBlockingCollection<IntEvent>(new IntEventFactory(), bufferSize);
    }

    [Benchmark]
    public void MyTryTakeBenchmark() => ArrayPooledBlockingCollectionDemonstrations.BC_TryTake(_bc);
}