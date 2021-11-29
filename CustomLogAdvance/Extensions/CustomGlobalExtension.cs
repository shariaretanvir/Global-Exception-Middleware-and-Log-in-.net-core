using CustomLogAdvance.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CustomLogAdvance.Extensions
{
    public static class CustomGlobalExtension
    {
        public static IApplicationBuilder CustomGlobalException(this IApplicationBuilder app)
            => app.UseMiddleware<CustomGlobalExceptionMiddleware>();
    }
}
