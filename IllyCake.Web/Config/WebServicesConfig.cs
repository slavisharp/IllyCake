namespace IllyCake.Web.Config
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.ResponseCompression;
    using Microsoft.Extensions.DependencyInjection;
    using NonFactors.Mvc.Grid;
    using System.IO.Compression;
    using System.Linq;

    internal class WebServicesConfig
    {
        internal static void ConfigureWebServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvcGrid();
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
        }
    }
}