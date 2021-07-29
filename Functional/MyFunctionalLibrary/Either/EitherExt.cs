using System;

namespace MyFunctionalLibrary.Either
{
    public static class EitherExt
    {
        public static Either<TL, TRr> Map<TL, TR, TRr>(this Either<TL, TR> either, Func<TR, TRr> f) =>
            either.Match<Either<TL, TRr>>(l => new Either.Left<TL>(l), r => new Either.Right<TRr>(f(r)));

        public static Either<TL, ValueTuple> ForEach<TL, TR>(this Either<TL, TR> either, Action<TR> act) =>
            Map(either, act.ToFunc());
    }
}