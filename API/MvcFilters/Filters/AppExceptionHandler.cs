using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MvcFilters.Filters
{
    public class AppExceptionHandler : IExceptionFilter
    {
        private readonly IModelMetadataProvider
            _modelMetadataProvider;

        public AppExceptionHandler(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var errorViewModel = new ErrorViewModel
            {
                ErrorMessage = context.Exception.Message, Source = context.Exception.StackTrace
            };

            var errorViewResult = new ViewResult
            {
                ViewName = "error",
                ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState)
                {
                    Model = errorViewModel
                }
            };

            context.ExceptionHandled = true;
            context.Result = errorViewResult;
        }
    }

    public class ErrorViewModel
    {
        public string Source { get; set; }

        public string ErrorMessage { get; set; }
    }
}