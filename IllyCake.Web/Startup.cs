namespace IllyCake.Web
{
    using IllyCake.Common.Settings;
    using IllyCake.Web.Config;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigOptions<AppSettings>(Configuration, "Configuration");
            services.AddMemoryCache();
            DataServicesConfig.ConfigureDataServices(services, Configuration);
            WebServicesConfig.ConfigureWebServices(services);
            UserServicesConfig.ConfigureUserServices(services);
            ApplicationServicesConfig.ConfigureAppServices(services);
        }
                
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, AppSettings settings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
            }

            app.UseStatusCodePagesWithReExecute("/Error/Index", "?statusCode={0}");

            app.UseResponseCompression();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            RolesInitializer.InitializeRoles(serviceProvider, settings.UserRoles);
        }
    }
}
