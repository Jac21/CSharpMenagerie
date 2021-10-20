using System;

namespace PatternMatching.Core
{
    public class Matcher<T>
    {
        private readonly T _value;

        public Matcher(T value)
        {
            _value = value;
        }

        public Matcher<T> Case(Func<bool> predicate, Action action)
        {
            return Case(ignore => predicate(), ignore => action());
        }

        public Matcher<T> Case(Func<bool> predicate, Action<T> action)
        {
            return Case(ignore => predicate(), action);
        }

        public Matcher<T> Case(T value, Action action)
        {
            return Case(() => Equals(_value, value), action);
        }

        public Matcher<T> Case<TCase>(Action action)
        {
            return Case(() => _value is TCase, action);
        }

        public Matcher<T> Case<TCase>(Action<T> action)
        {
            return Case(() => _value is TCase, action);
        }

        public virtual Matcher<T> Case(Func<T, bool> predicate, Action<T> action)
        {
            if (predicate(_value))
            {
                // allow null matches
                action?.Invoke(_value);

                return new NullMatcher<T>(_value);
            }

            return this;
        }

        public virtual Matcher<T> Case<TCase, TArg>(Action<TArg> action)
        {
            if (_value is IMatchable<TArg> matchable && _value is TCase)
            {
                action(matchable.GetArg());

                // return on first match
                return new NullMatcher<T>(_value);
            }

            // allow match chaining
            return this;
        }
    }
}