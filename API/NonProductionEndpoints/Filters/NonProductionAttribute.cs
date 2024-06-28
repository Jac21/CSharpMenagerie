using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NonProductionEndpoints.Filters;

public class NonProductionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        IHostEnvironment environment = context.HttpContext.RequestServices.GetRequiredService<IHostEnvironment>();
        if (environment.IsProduction())
        {
            context.Result = new NotFoundResult();
            return;
        }

        base.OnActionExecuting(context);
    }
}