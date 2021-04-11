namespace GenericsBridgeExample.Interfaces
{
    /// <summary>
    /// Common, non-generic interface that our calling code uses
    /// </summary>
    public interface IPolicyValidator
    {
        bool Validate(IPolicy policy);
    }

    /// <summary>
    /// Injected generic class
    /// </summary>
    /// <typeparam name="TPolicy"></typeparam>
    public interface IPolicyValidator<TPolicy> where TPolicy : IPolicy
    {
        bool Validate(IPolicy policy);
    }
}