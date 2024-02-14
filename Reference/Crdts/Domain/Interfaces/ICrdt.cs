namespace Crdts.Domain.Interfaces;

public interface ICrdt<T, TS>
{
    public T Value { get; set; }

    public TS State { get; set; }

    public void Merge(TS state);
}