using Disruptor;
using LmaxDisruptorExtensions.Events.Interfaces;

namespace LmaxDisruptorExtensions.Handlers;

public class SampleEventHandler : IEventHandler<IInitializableEvent>
{
    public void OnEvent(IInitializableEvent data, long sequence, bool endOfBatch)
    {
        Console.WriteLine(
            $"{nameof(SampleEventHandler)}: Consumed Event: {data.Id} => {data.Value} with sequence {sequence} at {data.TimestampUtc.ToUniversalTime()}");
    }
}