// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Disruptor;
using Disruptor.Dsl;
using LmaxDisruptorExtensions.Events.Implementations;
using LmaxDisruptorExtensions.Events.Interfaces;
using LmaxDisruptorExtensions.Handlers;
using LmaxDisruptorExtensions.Wrappers;

Console.WriteLine("Hello, Disruptor!");

const int ringBufferSize = 1024;
var taskScheduler = TaskScheduler.Default;
const ProducerType producerType = ProducerType.Single;
var blockingWaitStrategy = new BlockingWaitStrategy();

var disruptor = new Disruptor<IInitializableEvent>(() => new SampleEvent(), ringBufferSize, taskScheduler,
    producerType, blockingWaitStrategy);

var wrapper = new InitializableEventDisruptorWrapper<IInitializableEvent>(disruptor);

wrapper.StartConsumerChain(new SampleEventHandler(), new SampleEventHandlerDuplicate());

var random = new Random();

TimeAndLog(() =>
{
    for (var i = 0; i < 100_000; i++)
    {
        wrapper.Produce(i, random.NextDouble());
    }
    
    disruptor.Shutdown();
});

Console.WriteLine("fin");
Console.ReadLine();

void TimeAndLog(Action action)
{
    var stopwatch = Stopwatch.StartNew();

    action();

    stopwatch.Stop();
    Console.WriteLine($"{nameof(TimeAndLog)}: Elapsed time in milliseconds - {stopwatch.Elapsed.TotalMilliseconds}");
}