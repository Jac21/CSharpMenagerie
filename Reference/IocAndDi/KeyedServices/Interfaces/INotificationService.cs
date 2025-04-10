namespace KeyedServices.Interfaces;

public interface INotificationService
{
    Task SendAsync(string message);
}