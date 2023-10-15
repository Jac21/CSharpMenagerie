using System.Collections.Concurrent;

namespace StructuredConcurrency;

/// <summary>
/// Construct to create scope for grouping of related
/// concurrent tasks, allows for failures to propogate
///
/// See https://github.dev/StephenCleary/StructuredConcurrency for
/// a more sophisticated example of this pattern
/// </summary>
public class TaskScope
{
    private readonly CancellationTokenSource _cts = new();
    private readonly ConcurrentBag<Task> _tasks = new();

    private TaskScope()
    {
    }

    public static async Task Create(Func<TaskScope, Task> action)
    {
        await using var scope = new TaskScope();
        await action(scope);
        await scope.WaitForAll();
    }

    public static async Task Create(Action<TaskScope> action)
    {
        await using var scope = new TaskScope();
        action(scope);
        await scope.WaitForAll();
    }

    private async ValueTask DisposeAsync()
    {
        _cts.Cancel();

        await WaitForAll();
    }

    public Task Run(Func<CancellationToken, Task> action)
    {
        var task = Task.Run(async () =>
        {
            try
            {
                await action(_cts.Token);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _cts.Cancel();

                throw;
            }
        });

        _tasks.Add(task);

        return task;
    }

    private async Task WaitForAll()
    {
        try
        {
            await Task.WhenAll(_tasks.ToArray());
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            throw;
        }
    }
}