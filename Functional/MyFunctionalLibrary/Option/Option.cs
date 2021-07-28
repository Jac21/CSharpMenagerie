using System;

namespace MyFunctionalLibrary.Option
{
    public struct Option<T>
    {
        /// <summary>
        /// Captures the state of the Option: true if the Option is Some
        /// </summary>
        private readonly bool _isSome;

        /// <summary>
        /// The inner value of the Option
        /// </summary>
        private readonly T _value;

        private Option(T value)
        {
            _isSome = true;
            _value = value;
        }

        /// <summary>
        /// Converts None into an Option
        /// </summary>
        /// <param name="_"></param>
        public static implicit operator Option<T>(None _) => new Option<T>();

        /// <summary>
        /// Converts Some into an Option
        /// </summary>
        /// <param name="some"></param>
        public static implicit operator Option<T>(Some<T> some) => new Option<T>(some.Value);

        /// <summary>
        /// "Lifts" a regular value into an Option
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Option<T>(T value) =>
            value == null ? (Option<T>) None.Default : new Some<T>(value);

        /// <summary>
        /// Takes two functions and evaluates one or the other depending on the state of the Option
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="none"></param>
        /// <param name="some"></param>
        /// <returns></returns>
        public TR Match<TR>(Func<TR> none, Func<T, TR> some) => _isSome ? some(_value) : none();

        public static Option<R> Map<T, R>(None _, Func<T, R> f) => None.Default;

        public static Option<R> Map<T, R>(Some<T> some, Func<T, R> f) => new Some<R>(f(some.Value));
    }
}