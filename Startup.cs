using asp_net_core_cli.Interfaces;
using asp_net_core_cli.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace asp_net_core_cli
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var defaultRouteHandler = new RouteHandler(requestDelegate: context =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync($"Route values: {string.Join(", ", routeValues)}");
            });

            var routeBuilder = new RouteBuilder(applicationBuilder: app, defaultHandler: defaultRouteHandler);

            routeBuilder.MapRoute(name: "default", template: "{first:regex(^(default|home)$)}/{second?}");

            routeBuilder.MapGet(template: "user/{name}", handler: context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Get user, name: {name}");
            });

            routeBuilder.MapPost(template: "user/{name}", handler: context =>
            {
                var name = context.GetRouteValue("name");
                return context.Response.WriteAsync($"Create user, name: {name}");
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}
