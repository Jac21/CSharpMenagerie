// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using StructuredConcurrency;

Console.WriteLine("Hello, Structured Concurrency!");

var stopwatch = Stopwatch.StartNew();

var tasks = TaskScope.Create(group =>
{
    group.Run(async token => await Task.Delay(100, token));
    group.Run(async token => await Task.Delay(200, token));
});

// will run for at least 200ms
await tasks;
Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");

stopwatch.Restart();

var failedTasks = TaskScope.Create(group =>
{
    group.Run(async token =>
    {
        await Task.Delay(100, token);
        throw new Exception("Example task-related exception");
    });

    group.Run(async token => await Task.Delay(1000, token));
});

// runs 100ms as the first task fails and cancels the rest, exception is bubbled
try
{
    await failedTasks;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// this runs at least 100 ms
Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} ms");

// will print true
Console.WriteLine($"Is Task {failedTasks.Id} faulted - {failedTasks.IsFaulted}");

Console.ReadLine();