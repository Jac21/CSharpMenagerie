// See https://aka.ms/new-console-template for more information

using AsynchronousTimeouts;

Console.WriteLine("Hello, World!");

var client = new Client(TimeSpan.FromSeconds(1));

var cancellationToken = new CancellationToken();

await client.SendAsync(cancellationToken);