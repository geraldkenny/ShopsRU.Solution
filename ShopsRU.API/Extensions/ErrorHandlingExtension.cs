using Microsoft.AspNetCore.Builder;
using ShopsRU.API.Extensions.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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