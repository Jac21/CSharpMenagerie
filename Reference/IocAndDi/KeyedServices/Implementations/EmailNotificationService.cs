using KeyedServices.Interfaces;

namespace KeyedServices.Implementations;

public class EmailNotificationService : INotificationService
{
    public async Task SendAsync(string message)
    {
        Console.WriteLine($"Emailing... {message}");

        await Task.Delay(100);
    }
}