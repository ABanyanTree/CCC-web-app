using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API.Middleware
{
    public static class MiddlewareExtensions
    {
        public static void ConfigreFileHandleMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<FileHandlerMiddleWare>();
        }
    }
}
