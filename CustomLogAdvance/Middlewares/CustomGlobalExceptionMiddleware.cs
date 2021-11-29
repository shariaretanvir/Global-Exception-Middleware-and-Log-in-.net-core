using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomLogAdvance.Middlewares
{
    public class CustomGlobalExceptionMiddleware
    {
        public RequestDelegate Next { get; }
        public ILogger<CustomGlobalExceptionMiddleware> Logger { get; }

        public CustomGlobalExceptionMiddleware(RequestDelegate next,ILogger<CustomGlobalExceptionMiddleware> logger)
        {
            Next = next;
            Logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (System.Exception e)
            {
                Logger.LogError(e.Message);
                await ReturnCustomGlobalError(context,e);

            }
        }

        private async Task ReturnCustomGlobalError(HttpContext context,Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = e.Message
            });
            Logger.LogError(result);
            await context.Response.WriteAsync(result);
        }
    }
}
