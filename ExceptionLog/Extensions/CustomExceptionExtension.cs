using ExceptionLog.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLog.Extensions
{
    public static class CustomExceptionExtension
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder) => builder.UseMiddleware<CustomExceptionMiddleware>();
    }
}
