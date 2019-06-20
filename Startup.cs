using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace asp_net_core_cli
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 1 in.\r\n");
                await context.Response.WriteAsync("Middleware 1 step 1.\r\n");
                await context.Response.WriteAsync("Middleware 1 step 2.\r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Middleware 1 step 3.\r\n");
                await context.Response.WriteAsync("Middleware 1 step 4.\r\n");
                await context.Response.WriteAsync("Middleware 1 out.\r\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 2 in.\r\n");
                await context.Response.WriteAsync("Middleware 2 step 1.\r\n");
                await context.Response.WriteAsync("Middleware 2 step 2.\r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Middleware 2 step 3.\r\n");
                await context.Response.WriteAsync("Middleware 2 step 4.\r\n");
                await context.Response.WriteAsync("Middleware 2 out.\r\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 3 in.\r\n");
                await context.Response.WriteAsync("Middleware 3 step 1.\r\n");
                await context.Response.WriteAsync("Middleware 3 step 2.\r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Middleware 3 step 3.\r\n");
                await context.Response.WriteAsync("Middleware 3 step 4.\r\n");
                await context.Response.WriteAsync("Middleware 3 out.\r\n");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!\r\n");
            });
        }
    }
}
