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
            System.Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

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