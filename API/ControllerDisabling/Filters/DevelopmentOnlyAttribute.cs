using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControllerDisabling.Filters;

public class DevelopmentOnlyAttribute : ActionFilterAttribute, IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // Nothing in here, as this is run after our Controller (Endpoint) method finishes
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // Get an object (from DI), which contains information about our current WebHost Environment
        var env = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
        if (!env.IsDevelopment())
        {
            // If we're not running in development mode, then just return a 404, this short-circuits the request pipeline. (This could be changed to return whatever fail result you like)
            context.Result = new NotFoundResult();
        }
    }
}