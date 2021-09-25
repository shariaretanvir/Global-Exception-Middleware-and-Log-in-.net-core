using CustomLogService.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExceptionLog.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerManager logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                logger.LogError("Error found : "+e);
                await ExceptionHandleAsync(context, e);
            }
        }

        private async Task ExceptionHandleAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = e.Message
            });
            await context.Response.WriteAsync(result);
       }
    }
}
