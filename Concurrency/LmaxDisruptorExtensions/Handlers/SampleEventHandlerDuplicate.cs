using Disruptor;
using LmaxDisruptorExtensions.Events.Interfaces;

namespace LmaxDisruptorExtensions.Handlers;

public class SampleEventHandlerDuplicate : IEventHandler<IInitializableEvent>
{
    public void OnEvent(IInitializableEvent data, long sequence, bool endOfBatch)
    {
        Console.WriteLine(
            $"{nameof(SampleEventHandlerDuplicate)}: Consumed Event: {data.Id} => {data.Value} with sequence {sequence} at {data.TimestampUtc.ToUniversalTime()}");
    }
}