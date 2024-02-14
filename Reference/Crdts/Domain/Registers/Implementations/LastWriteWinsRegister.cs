using Crdts.Domain.Interfaces;

namespace Crdts.Domain.Registers.Implementations;

public class LastWriteWinsRegister<T, TS> : ICrdt<T, TS>
{
    private readonly string _id;

    private (string peer, int timestamp, T value) _state;

    public LastWriteWinsRegister(string id, (string peer, int timestamp, T value) state)
    {
        _id = id;
        _state = state;
    }

    public T Get()
    {
        return _state.value;
    }

    public void Set(T value)
    {
        _state = (_id, _state.timestamp + 1, value);
    }

    public void Merge((string peer, int timestamp, T value) mergeState)
    {
        if (_state.timestamp > mergeState.timestamp) return;

        if (_state.timestamp == mergeState.timestamp &&
            Convert.ToInt32(_state.peer) > Convert.ToInt32(mergeState.peer))
            return;

        _state = mergeState;
    }

    // TODO - Implement
    public T Value { get; set; }
    public TS State { get; set; }

    public void Merge(TS state)
    {
        throw new NotImplementedException();
    }
}