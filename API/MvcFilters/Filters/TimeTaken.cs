using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcFilters.Filters
{
    public class TimeTaken : IActionFilter
    {
        private Stopwatch _timer;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _timer = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _timer.Stop();

            var result = " Elapsed time: " + $"{_timer.Elapsed.TotalMilliseconds} ms";

            Debug.WriteLine(result, "Action Filter Log");
        }
    }
}