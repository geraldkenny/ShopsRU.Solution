using Microsoft.AspNetCore.Builder;
using ShopsRU.API.Extensions.Middlewares;

namespace ShopsRU.API.Extensions
{
    public static class ErrorHandlingExtension
    {
        public static IApplicationBuilder UseErrorHandlingWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}