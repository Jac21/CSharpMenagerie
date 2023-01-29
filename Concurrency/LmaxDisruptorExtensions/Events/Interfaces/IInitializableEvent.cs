namespace LmaxDisruptorExtensions.Events.Interfaces;

public interface IInitializableEvent
{
    int Id { get; }
    
    double Value { get; }
    
    DateTime TimestampUtc { get; }
    
    void Initialize(int id, double value, DateTime timestampUtc);
}