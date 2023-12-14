using Microsoft.AspNetCore.Builder;

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
