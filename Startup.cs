using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using asp_net_core_cli.Extensions;
using asp_net_core_cli.Interfaces;
using asp_net_core_cli.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace asp_net_core_cli
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISampleTransient, Sample>();
            services.AddScoped<ISampleScoped, Sample>();
            services.AddSingleton<ISampleSingleton, Sample>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, @"public1")),
                RequestPath = new PathString("/myfolder"),
            });
            app.UseMyMiddleware();
            app.UseMvcWithDefaultRoute();

            // terminal middleware
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!\r\n");
            });
        }
    }
}
