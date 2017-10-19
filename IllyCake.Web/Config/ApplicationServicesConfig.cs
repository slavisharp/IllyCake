namespace IllyCake.Web.Config
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using IllyCake.Common.Managers;

    public static class ApplicationServicesConfig
    {
        internal static void ConfigureAppServices(IServiceCollection services)
        {
            services.AddTransient<IHomePageManager, HomePageManager>();
        }
    }
}
