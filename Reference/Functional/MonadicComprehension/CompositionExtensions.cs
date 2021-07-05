using System;
using System.Threading.Tasks;

namespace MonadicComprehension
{
    public static class CompositionExtensions
    {
        public static Task<TResult> SelectMany<TFirst, TSecond, TResult>(
            this Task<TFirst> first,
            Func<TFirst, Task<TSecond>> getSecond,
            Func<TFirst, TSecond, TResult> getResult)
        {
            // Not using async/await deliberately to illustrate a point
            return first.ContinueWith(_ =>
            {
                // At this point the result has already been evaluated
                var firstResult = first.Result;

                // Chain second task
                var second = getSecond(firstResult);
                return second.ContinueWith(task =>
                {
                    // Unwrap the second task and assemble the result
                    var secondResult = second.Result;
                    return getResult(firstResult, secondResult);
                });
            }).Unwrap();
        }

        public static Option<TResult> SelectMany<TFirst, TSecond, TResult>(
            this Option<TFirst> first,
            Func<TFirst, Option<TSecond>> getSecond,
            Func<TFirst, TSecond, TResult> getResult)
        {
            return first.Match(
                // First operand has value -> continue to the second operand
                firstValue => getSecond(firstValue).Match(
                    // Second operand has value -> compose the result from the first and second operands
                    secondValue => Option<TResult>.Some(getResult(firstValue, secondValue)),

                    // Second operand is empty -> return
                    Option<TResult>.None
                ),

                // First operand is empty -> return
                Option<TResult>.None
            );
        }

        public static async Task<Option<TResult>> SelectMany<TFirst, TSecond, TResult>(
            this Task<Option<TFirst>> first,
            Func<TFirst, Task<Option<TSecond>>> getSecond,
            Func<TFirst, TSecond, TResult> getResult)
        {
            var firstOption = await first;

            return await firstOption.Match(
                async firstValue =>
                {
                    var secondOption = await getSecond(firstValue);

                    return secondOption.Match(
                        secondValue => Option<TResult>.Some(getResult(firstValue, secondValue)),
                        Option<TResult>.None
                    );
                },
                () => Task.FromResult(Option<TResult>.None())
            );
        }
    }
}