using asp_net_core_cli.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace asp_net_core_cli.Extensions
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Adds MyMiddleware to the web application pipeline
        /// </summary>
        /// <param name="app">The IApplicationBuilder passed to your Configure method</param>
        /// <returns>The original app parameter</returns>
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}