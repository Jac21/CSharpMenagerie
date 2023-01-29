using LmaxDisruptorExtensions.Events.Interfaces;

namespace LmaxDisruptorExtensions.Events.Implementations;

public class SampleEvent : IInitializableEvent
{
    public int Id { get; private set; }

    public double Value { get; private set; }

    public DateTime TimestampUtc { get; private set; }

    public void Initialize(int id, double value, DateTime timestampUtc)
    {
        Id = id;
        Value = value;
        TimestampUtc = timestampUtc;
    }
}