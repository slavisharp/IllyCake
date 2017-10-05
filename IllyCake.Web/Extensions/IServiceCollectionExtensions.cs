namespace Microsoft.Extensions.DependencyInjection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigOptions<TOptions>(this IServiceCollection services, IConfiguration configuration, string section) where TOptions : class, new()
        {
            services.Configure<TOptions>(configuration.GetSection(section));
            services.AddSingleton(cfg => cfg.GetService<IOptions<TOptions>>().Value);
            return services;
        }
    }
}
