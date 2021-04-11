using GenericsBridgeExample.Interfaces;

namespace GenericsBridgeExample.Implementations
{
    /// <summary>
    /// Bridge class for composition
    /// </summary>
    /// <typeparam name="TPolicy"></typeparam>
    public class PolicyValidator<TPolicy> : IPolicyValidator
        where TPolicy : IPolicy
    {
        private readonly IPolicyValidator<TPolicy> _inner;

        public PolicyValidator(IPolicyValidator<TPolicy> inner)
            => _inner = inner;

        public bool Validate(IPolicy policy)
            => _inner.Validate((TPolicy) policy);
    }
}