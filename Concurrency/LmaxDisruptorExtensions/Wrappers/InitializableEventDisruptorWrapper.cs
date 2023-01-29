using Disruptor;
using Disruptor.Dsl;
using LmaxDisruptorExtensions.Events.Interfaces;

namespace LmaxDisruptorExtensions.Wrappers;

public class InitializableEventDisruptorWrapper<T> where T : class
{
    private readonly Disruptor<T> _disruptor;

    public InitializableEventDisruptorWrapper(Disruptor<T> disruptor)
    {
        _disruptor = disruptor ?? throw new ArgumentNullException(nameof(disruptor));
    }

    public void StartConsumerChain(IEventHandler<T> consumerOne, IEventHandler<T> consumerTwo)
    {
        if (consumerOne == null) throw new ArgumentNullException(nameof(consumerOne));

        if (consumerTwo == null) throw new ArgumentNullException(nameof(consumerTwo));

        Console.WriteLine($"{nameof(StartConsumerChain)}: Starting event handlers...");

        _disruptor
            .HandleEventsWith(consumerOne)
            .Then(consumerTwo);

        _disruptor.Start();
    }

    public void Produce(int id, double value)
    {
        var sequence = _disruptor.RingBuffer.Next();

        try
        {
            var data = _disruptor.RingBuffer[sequence] as IInitializableEvent;

            data?.Initialize(id, value, DateTime.UtcNow);
        }
        finally
        {
            _disruptor.RingBuffer.Publish(sequence);
        }
    }
}