namespace TaskExtensions;

public static class TaskExtensions
{
    /// <summary>
    /// SendEmailAsync().FireAndForget(errorHandler => Console.WriteLine(errorHandler.Message));
    /// </summary>
    /// <param name="task"></param>
    /// <param name="errorHandler"></param>
    public static void FireAndForget(this Task task, Action<Exception>? errorHandler = null)
    {
        _ = task.ContinueWith(t =>
        {
            if (t.IsFaulted && errorHandler != null)
            {
                errorHandler(t.Exception);
            }
        }, TaskContinuationOptions.OnlyOnFaulted);
    }

    /// <summary>
    /// var result = await (() => GetResultAsync()).Retry(3, TimeSpan.FromSeconds(1));
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="taskFactory"></param>
    /// <param name="maxRetries"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    public static async Task<TResult?> Retry<TResult>(this Func<Task<TResult>> taskFactory, int maxRetries, TimeSpan delay)
    {
        for(var i = 0; i <= maxRetries; i++)
        {
            try
            {
                return await taskFactory();
            }
            catch
            {
                if(i == maxRetries)
                {
                    throw;
                }

                await Task.Delay(delay);
            }
        }

        return default;
    }

    /// <summary>
    /// await GetResultAsync().OnFailure(ex => Console.WriteLine(ex.Message));
    /// </summary>
    /// <param name="task"></param>
    /// <param name="onFailure"></param>
    /// <returns></returns>
    public static async Task OnFailure(this Task task, Action<Exception> onFailure)
    {
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            onFailure(ex);
        }
    }

    /// <summary>
    /// await GetResultAsync().WithTimeout(TimeSpan.FromSeconds(1));
    /// </summary>
    /// <param name="task"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    /// <exception cref="TimeoutException"></exception>
    public static async Task WithTimeout(this Task task, TimeSpan timeout)
    {
        var delayTask = Task.Delay(timeout);
        var completedTask = await Task.WhenAny(task, delayTask);

        if (completedTask == delayTask)
        {
            throw new TimeoutException();
        }

        await task;
    }

    /// <summary>
    /// var result = await GetResultAsync().Fallback("fallback");
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="task"></param>
    /// <param name="fallbackValue"></param>
    /// <returns></returns>
    public static async Task<TResult> Fallback<TResult>(this Task<TResult> task, TResult fallbackValue)
    {
        try
        {
            return await task;
        }
        catch
        {
            return fallbackValue;
        }
    }
}