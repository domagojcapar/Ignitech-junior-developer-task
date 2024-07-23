using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SchoolApi.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log request logic here
            System.Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            // Call the next delegate/middleware in the pipeline
            await _next(context);

            // Log response logic here
            System.Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}