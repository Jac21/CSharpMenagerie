namespace PatternMatching.Core
{
    public interface IMatchable<TArg>
    {
        TArg GetArg();
    }
}