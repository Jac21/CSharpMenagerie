// See https://aka.ms/new-console-template for more information

using KeyedServices.Enums;
using KeyedServices.Implementations;
using KeyedServices.Interfaces;
using KeyedServices.Processors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, Keyed Services!");

var builder = Host.CreateApplicationBuilder();

builder.Services.AddKeyedScoped<INotificationService, EmailNotificationService>(NotificationChannel.Email);
builder.Services.AddKeyedScoped<INotificationService, SmsNotificationService>(NotificationChannel.Sms);

builder.Build();

var notificationProcessor = new NotificationProcessor(new EmailNotificationService(), new SmsNotificationService());
notificationProcessor
    .ProcessAsync()
    .GetAwaiter()
    .GetResult();

Console.ReadLine();