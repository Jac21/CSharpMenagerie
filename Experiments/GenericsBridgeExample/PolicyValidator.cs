using System.Collections.Generic;
using GenericsBridgeExample.Implementations;
using GenericsBridgeExample.Interfaces;

namespace GenericsBridgeExample
{
    public class PolicyValidator
    {
        public void Validate(List<IPolicy> applicationPolicies)
        {
            var isValid = false;

            foreach (var policy in applicationPolicies)
            {
                // perform manual closing of types
                var policyType = policy.GetType();
                var validatorType = typeof(PolicyValidator<>).MakeGenericType(policyType);

                // ask container for the closed bridge class type
                var policyValidator = (IPolicyValidator) /* container.GetService(validatorType); */ validatorType;

                isValid = isValid && policyValidator.Validate(policy);
            }
        }
    }
}