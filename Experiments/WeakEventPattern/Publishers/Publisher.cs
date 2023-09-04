using WeakEventPattern.Events;

namespace WeakEventPattern.Publishers;

public class Publisher
{
    private readonly WeakEvent<EventArgs> _event = new();

    public event EventHandler<EventArgs> Event
    {
        add => _event.AddListener(value);

        remove => _event.RemoveListener(value);
    }

    public void RaiseEvent()
    {
        _event.Raise(this, EventArgs.Empty);
    }
}