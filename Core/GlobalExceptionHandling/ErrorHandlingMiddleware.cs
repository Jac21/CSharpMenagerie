using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace GlobalExceptionHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IWebHostEnvironment _env;

        public ErrorHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;
            var stackTrace = string.Empty;

            var exceptionType = exception.GetType();
            if (exceptionType == typeof(BadHttpRequestException))
            {
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                status = HttpStatusCode.NotFound;
                message = exception.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;

                if (_env.IsDevelopment())
                {
                    stackTrace = exception.StackTrace;
                }
            }

            var result = JsonSerializer.Serialize(new {error = message, stackTrace});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) status;

            await context.Response.WriteAsync(result);
        }
    }
}