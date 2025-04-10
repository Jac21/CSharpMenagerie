using KeyedServices.Enums;
using KeyedServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedServices.Processors;

public class NotificationProcessor
{
    private readonly INotificationService _emailNotificationService;
    private readonly INotificationService _smsNotificationService;

    public NotificationProcessor(
        [FromKeyedServices(NotificationChannel.Email)] INotificationService emailNotificationService,
        [FromKeyedServices(NotificationChannel.Sms)]
        INotificationService smsNotificationService)
    {
        _emailNotificationService = emailNotificationService ??
                                    throw new ArgumentNullException(nameof(emailNotificationService));
        
        _smsNotificationService =
            smsNotificationService ?? throw new ArgumentNullException(nameof(smsNotificationService));
    }

    public async Task ProcessAsync()
    {
        await _emailNotificationService.SendAsync("Email!");
        await _smsNotificationService.SendAsync("Message!");
    }
}