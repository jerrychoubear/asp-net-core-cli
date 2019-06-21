using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;

namespace asp_net_core_cli
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var rewriteOptions = new RewriteOptions()
                .AddRewrite("about.aspx", "home/about", skipRemainingRules: true)
                .AddRedirect("first", "home/index");
            app.UseRewriter(rewriteOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "about",
                    template: "about",
                    defaults: new { controller = "Home", action = "About" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                // 等同:
                // routes.MapRoute(
                //     name: "default",
                //     template: "{controller}/{action}/{id?}",
                //     defaults: new { controller = "Home", action = "Index" }
                // );
            });
        }
    }
}
