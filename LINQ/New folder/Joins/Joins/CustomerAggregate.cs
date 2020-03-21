namespace Joins
{
    internal class CustomerAggregate
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public CustomerPreferences Preference { get; set; }
    }
}