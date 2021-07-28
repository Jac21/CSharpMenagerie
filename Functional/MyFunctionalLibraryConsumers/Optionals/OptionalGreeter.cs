using MyFunctionalLibrary.Option;

namespace MyFunctionalLibraryConsumers.Optionals
{
    public class OptionalGreeter
    {
        public string Greet(Option<string> greetee) =>
            greetee.Match(() => "Sorry, who?", name => $"Hello, {name}");

        public string GreetingFor(Subscriber subscriber) =>
            subscriber.Name.Match(() => "Dear Subsriber,", name => $"Dear {name.ToUpperInvariant()}");
    }
}