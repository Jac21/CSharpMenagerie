using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcFilters.Filters
{
    public class AuthorizeIpAddress : IAuthorizationFilter
    {
        private readonly string _allowedIpAddress;

        public AuthorizeIpAddress(string allowedIpAddress)
        {
            _allowedIpAddress = allowedIpAddress;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var requestIp = context.HttpContext.Connection.RemoteIpAddress;

            var ipAddresses = _allowedIpAddress.Split(';');
            var unauthorizedIp = true;

            if (requestIp.IsIPv4MappedToIPv6)
            {
                requestIp = requestIp.MapToIPv4();
            }

            foreach (var ipAddress in ipAddresses)
            {
                if (IPAddress.TryParse(ipAddress, out var testIp) && testIp.Equals(requestIp))
                {
                    unauthorizedIp = false;
                    break;
                }
            }

            if (unauthorizedIp)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}