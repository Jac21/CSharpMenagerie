using System;
using System.Threading.Tasks;

namespace MonadicComprehension
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Lazily compose tasks
            var task =
                from sum in Task.Run(() => 1 + 1) // Task<int>
                from div in Task.Run(() => sum / 1.5) // Task<double>
                select sum + (int) div; // Task<int>

            // Observe the actual result
            var result = await task;

            // Prints "3"
            Console.WriteLine(result);

            // option composition
            var maxInstances =
                from envVar in OptionExtensions.GetEnvironmentVariable("MYAPP_MAXALLOWEDINSTANCES") // Option<string>
                from value in OptionExtensions.ParseInt(envVar) // Option<int>
                select value >= 1 ? value : 1; // Option<int>

            maxInstances.Match(
                Console.WriteLine,
                () => Console.WriteLine("Value not set or invalid")
            );

            //// task-option composition
            //var paymentProcessor = new PaymentProcessor();

            //// Note the `await` in the beginning of the expression
            //var paymentId = await
            //    from leviIban in paymentProcessor.GetIbanAsync("levi@gmail.com")
            //    from olenaIban in paymentProcessor.GetIbanAsync("olena@hotmail.com")
            //    from paymentId in paymentProcessor.SendPaymentAsync(leviIban, olenaIban, 100)
            //    select paymentId;

            //// Prints "d56a5b86-f55b-4707-be4f-138a19272f47"
            //paymentId.Match(
            //    value => Console.WriteLine(value),
            //    () => Console.WriteLine("Failed to send payment")
            //);
        }
    }
}