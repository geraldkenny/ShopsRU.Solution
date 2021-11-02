using Microsoft.AspNetCore.Builder;
using ShopsRU.API.Extensions.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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