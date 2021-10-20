using System;

namespace PatternMatching.Core
{
    public class NullMatcher<T> : Matcher<T>
    {
        public NullMatcher(T value) : base(value)
        {
        }

        public override Matcher<T> Case<TCase, TArg>(Action<TArg> action)
        {
            return this;
        }
    }
}