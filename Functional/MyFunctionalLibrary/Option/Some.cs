using System;

namespace MyFunctionalLibrary.Option
{
    public struct Some<T>
    {
        /// <summary>
        /// Simply wrap a value
        /// </summary>
        internal T Value { get; }

        internal Some(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Value = value;
        }
    }
}