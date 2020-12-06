using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FluentGenerics.Endpoints.Implementations
{
    public class SignInEndpoint : Endpoint.WithRequest<SignInRequest>.WithResponse<SignInResponse>
    {
        [HttpPost("auth/signin")]
        public override Task<ActionResult<SignInResponse>> ExecuteAsync(SignInRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SignInRequest
    {
    }

    public class SignInResponse
    {
    }
}