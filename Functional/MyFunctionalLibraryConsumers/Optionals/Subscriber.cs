using MyFunctionalLibrary.Option;

namespace MyFunctionalLibraryConsumers.Optionals
{
    public class Subscriber
    {
        /// <summary>
        /// Explicitly marked as optional
        /// </summary>
        public Option<string> Name { get; set; }

        public string Email { get; set; }
    }
}