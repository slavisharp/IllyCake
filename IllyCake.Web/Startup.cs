namespace IllyCake.Web
{
    using IllyCake.Common.Services;
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Data.Models;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.IO.Compression;
    using System.Linq;

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
            ConfigureDataServices(services);
            ConfigureWebServices(services);
            ConfigureUserServices(services);
        }

        private static void ConfigureUserServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
        }

        private static void ConfigureWebServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
        }

        private void ConfigureDataServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

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
        }
    }
}
