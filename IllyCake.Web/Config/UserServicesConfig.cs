namespace IllyCake.Web
{
    using IllyCake.Common.Services;
    using IllyCake.Web.Services;
    using Microsoft.Extensions.DependencyInjection;

    internal class UserServicesConfig
    {
        internal static void ConfigureAppServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
        }
    }
}