using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FluentGenerics.Endpoints
{
    public static class Endpoint
    {
        public static class WithRequest<TReq>
        {
            public abstract class WithResponse<TRes>
            {
                public abstract Task<ActionResult<TRes>> ExecuteAsync(
                    TReq request,
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithoutResponse
            {
                public abstract Task<ActionResult> ExecuteAsync(
                    TReq request,
                    CancellationToken cancellationToken = default
                );
            }
        }

        public static class WithoutRequest
        {
            public abstract class WithResponse<TRes>
            {
                public abstract Task<ActionResult<TRes>> ExecuteAsync(
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithoutResponse
            {
                public abstract Task<ActionResult> ExecuteAsync(
                    CancellationToken cancellationToken = default
                );
            }
        }
    }
}