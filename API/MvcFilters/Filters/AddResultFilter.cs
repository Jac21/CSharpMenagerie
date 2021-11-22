using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcFilters.Filters
{
    public class AddResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("AppId", "App header was added by result header");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // no-op
        }
    }
}