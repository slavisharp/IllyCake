namespace IllyCake.Web
{
    using IllyCake.Common.Services;
    using Microsoft.Extensions.DependencyInjection;

    internal class UserServicesConfig
    {
        internal static void ConfigureUserServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
        }

    }
}