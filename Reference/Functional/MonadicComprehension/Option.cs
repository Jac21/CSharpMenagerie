using System;

namespace MonadicComprehension
{
    public struct Option<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        private Option(T value, bool hasValue)
        {
            _value = value;
            _hasValue = hasValue;
        }

        public Option(T value) : this(value, true)
        {
        }

        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none) => _hasValue ? some(_value) : none();

        public void Match(Action<T> some, Action none)
        {
            if (_hasValue)
            {
                some(_value);
            }
            else
            {
                none();
            }
        }

        public static Option<T> Some(T value) => new Option<T>(value);

        public static Option<T> None() => default;
    }
}