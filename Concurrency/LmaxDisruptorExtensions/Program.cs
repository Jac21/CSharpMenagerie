// See https://aka.ms/new-console-template for more information
// https://github.com/disruptor-net/Disruptor-net

using System.Diagnostics;
using Disruptor;
using Disruptor.Dsl;
using LmaxDisruptorExtensions.Events.Implementations;
using LmaxDisruptorExtensions.Events.Interfaces;
using LmaxDisruptorExtensions.Handlers;
using LmaxDisruptorExtensions.Wrappers;

Console.WriteLine("Hello, Disruptor!");

const int ringBufferSize = 1_024;
var taskScheduler = TaskScheduler.Default;
const ProducerType producerType = ProducerType.Single;
var blockingWaitStrategy = new BlockingWaitStrategy();

var disruptor = new Disruptor<IInitializableEvent>(() => new SampleEvent(), ringBufferSize, taskScheduler,
    producerType, blockingWaitStrategy);

var wrapper = new InitializableEventDisruptorWrapper<IInitializableEvent>(disruptor);

wrapper.StartConsumerChain(new SampleEventHandler(), new SampleEventHandlerDuplicate());

TimeAndSizeAndLog(() =>
{
    var random = new Random();

    for (var i = 0; i < 100_000_000; i++)
    {
        wrapper.Produce(i, random.NextDouble());
    }

    disruptor.Shutdown();
});

Console.WriteLine("fin");
Console.ReadLine();

void TimeAndSizeAndLog(Action action)
{
    var startMemory = GC.GetTotalMemory(true);
    var stopwatch = Stopwatch.StartNew();

    action();

    stopwatch.Stop();
    Console.WriteLine($"{nameof(TimeAndSizeAndLog)}: Elapsed time in total seconds - {stopwatch.Elapsed.TotalSeconds}");

    var totalMemory = GC.GetTotalMemory(false) - startMemory;
    var usedMemoryMedian = totalMemory / 1_000_000D;

    Console.WriteLine($"Allocated memory in MB: {usedMemoryMedian}");
}