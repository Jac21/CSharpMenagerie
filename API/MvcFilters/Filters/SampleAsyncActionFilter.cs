using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcFilters.Filters
{
    /// <summary>
    /// Utilize if there is a need for data access, I/O, and long-running operations.
    /// </summary>
    public class SampleAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // Do something before the action executes.

            // Execute any subsequent filters or action method.

            var executedContext = await next();

            // Do something after the action executes.
        }
    }
}