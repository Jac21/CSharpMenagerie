using KeyedServices.Interfaces;

namespace KeyedServices.Implementations;

public class SmsNotificationService : INotificationService
{
    public async Task SendAsync(string message)
    {
        Console.WriteLine($"SMSing... {message}");

        await Task.Delay(100);
    }
}