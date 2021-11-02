using Microsoft.AspNetCore.Builder;
using ShopsRU.API.Extensions.Middlewares;

namespace ShopsRU.API.Middlewares
{
    public static class ResponseWrapperExtension
    {
        public static IApplicationBuilder UseResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseWrapperMiddleware>();
        }
    }
}