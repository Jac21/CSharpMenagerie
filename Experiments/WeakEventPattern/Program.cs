// See https://aka.ms/new-console-template for more information

using WeakEventPattern.Publishers;

Console.WriteLine("Hello, Weak Events!");

var publisher = new Publisher();

publisher.Event += (_, _) => { Console.WriteLine($"Event raised at {DateTime.UtcNow}"); };

publisher.RaiseEvent();

Console.ReadLine();