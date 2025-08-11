namespace PerfScratchpad.Refs.ArrayPooledBlockingCollection;

public interface IEventFactory<out T>
{
    // Implementations should instantiate an event object, with all memory already allocated where possible.
    // return T newly constructed event instance.
    T NewInstance();
}

public class IntEventFactory : IEventFactory<IntEvent>
{
    public IntEvent NewInstance()
    {
        return new IntEvent();
    }
}

public class IntEvent
{
    private int _value;

    public void Set(int value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return $"IntEvent{{value={_value}}}";
    }
}

public interface IEventHandler<in T>
{
    void OnEvent(T @event, long sequence, bool endOfBatch);
}

public class IntEventHandler : IEventHandler<IntEvent>
{
    public void OnEvent(IntEvent @event, long sequence, bool endOfBatch)
    {
        Console.WriteLine($"Event: {@event}");
    }
}