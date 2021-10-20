namespace PatternMatching.Core
{
    public class Pattern
    {
        public static Matcher<T> Match<T>(T value)
        {
            return new Matcher<T>(value);
        }
    }
}