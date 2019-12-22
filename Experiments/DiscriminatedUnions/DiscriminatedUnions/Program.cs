using System;

namespace DiscriminatedUnions
{
    public class Program
    {
        private static Either<Success1, Error> DoWork1()
        {
            return new Either<Success1, Error>(new Error());
        }

        private static Success2 Transform(Success1 successValue1)
        {
            return new Success2();
        }

        private static Either<Success2, Error> DoWork2(Success2 successValue1)
        {
            return new Either<Success2, Error>(new SuccessFinal(), new Error());
        }

        private static void Main()
        {
            Console.WriteLine("Hello, Discriminated Unions!");

            DoWork1().Map(Transform).FlapMap(DoWork2);

            Console.ReadLine();
        }
    }

    public class SuccessFinal
    {
    }

    internal class Success2
    {
    }

    public class Error
    {
    }

    internal class Success1
    {
    }

    public abstract class Union<T1, T2> : IEquatable<Union<T1, T2>>
    {
        public abstract TResult Match<TResult>(Func<T1, TResult> f1, Func<T2, TResult> f2);

        public abstract void Match(Action<T1> a1, Action<T2> a2);

        private Union()
        {
        }

        public static implicit operator Union<T1, T2>(T1 item)
        {
            return new Case1(item);
        }

        public static implicit operator Union<T1, T2>(T2 item)
        {
            return new Case2(item);
        }

        public sealed class Case1 : Union<T1, T2>
        {
            public T1 Item { get; }

            public Case1(T1 item)
            {
                Item = item;
            }

            public override TResult Match<TResult>(Func<T1, TResult> f1, Func<T2, TResult> f2)
            {
                return f1(Item);
            }

            public override void Match(Action<T1> a1, Action<T2> a2)
            {
                a1(Item);
            }
        }

        public sealed class Case2 : Union<T1, T2>
        {
            public T2 Item { get; }

            public Case2(T2 item)
            {
                Item = item;
            }

            public override TResult Match<TResult>(Func<T1, TResult> f1, Func<T2, TResult> f2)
            {
                return f2(Item);
            }

            public override void Match(Action<T1> a1, Action<T2> a2)
            {
                a2(Item);
            }
        }

        public bool Equals(Union<T1, T2> other)
        {
            return true;
        }
    }

    public class Either<TDefault, TOther> : IEquatable<Either<TDefault, TOther>>
    {
        private readonly Union<TDefault, TOther> _union;

        public Either(TDefault value)
        {
            _union = value;
        }

        public Either(TOther value)
        {
            _union = value;
        }

        private Either(Either<object, TOther> value)
        {
            throw new NotImplementedException();
        }

        public Either(SuccessFinal value, Error error)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Either<TDefault, TOther>(TDefault value)
        {
            return new Either<TDefault, TOther>(value);
        }

        public static implicit operator Either<TDefault, TOther>(TOther value)
        {
            return new Either<TDefault, TOther>(value);
        }

        public Either<TResult, TOther> Map<TResult>(Func<TDefault, TResult> map)
        {
            return _union.Match(
                x => new Either<TResult, TOther>(map(x)), other => new Either<TResult, TOther>(other));
        }

        public Either<TResult, TOther> FlatMap<TResult>(Either<TDefault, TOther> input,
            Func<TDefault, Either<TResult, TOther>> map)
        {
            return _union.Match(
                x => new Either<TResult, TOther>(map(x)),
                other => new Either<TResult, TOther>(other)
            );
        }

        public void FlapMap(Func<TDefault, Either<TDefault, TOther>> doWork2)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Either<TDefault, TOther> other)
        {
            return true;
        }
    }
}