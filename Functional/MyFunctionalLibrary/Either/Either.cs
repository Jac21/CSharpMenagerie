using System;
using Unit = System.ValueTuple;

namespace MyFunctionalLibrary.Either
{
    public struct Either<TL, TR>
    {
        private TL Left { get; }
        private TR Right { get; }

        private bool IsRight { get; }
        private bool IsLeft => !IsRight;

        internal Either(TL left)
            => (IsRight, Left, Right)
                = (false, left ?? throw new ArgumentNullException(nameof(left)), default);

        internal Either(TR right)
            => (IsRight, Left, Right)
                = (true, default, right ?? throw new ArgumentNullException(nameof(right)));

        public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);
        public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);

        public static implicit operator Either<TL, TR>(Either.Left<TL> left) => new Either<TL, TR>(left.Value);
        public static implicit operator Either<TL, TR>(Either.Right<TR> right) => new Either<TL, TR>(right.Value);

        public TTr Match<TTr>(Func<TL, TTr> left, Func<TR, TTr> right) =>
            IsLeft ? left(this.Left!) : right(this.Right!);

        public Unit Match(Action<TL> left, Action<TR> right) => Match(left.ToFunc(), right.ToFunc());
    }

    public static class Either
    {
        public struct Left<TL>
        {
            internal Left(TL value) => Value = value;

            internal TL Value { get; }

            public override string ToString() => $"Left({Value})";
        }

        public struct Right<TR>
        {
            internal Right(TR value) => Value = value;

            internal TR Value { get; }
            public override string ToString() => $"Right({Value})";
        }
    }
}