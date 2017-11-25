namespace IllyCake.Web.Config
{
    using Microsoft.Extensions.DependencyInjection;
    using IllyCake.Common.Managers;

    public static class ApplicationServicesConfig
    {
        internal static void ConfigureAppServices(IServiceCollection services)
        {
            services.AddTransient<IHomePageManager, HomePageManager>();
            services.AddTransient<IBlogPostManager, BlogPostManager>();
            services.AddTransient<IQuoteManager, QuoteManager>();
            services.AddTransient<IImageManager, ImageManager>();
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<ICartManager, CartManager>();
            services.AddTransient<IProductManager, ProductManager>();
        }
    }
}
