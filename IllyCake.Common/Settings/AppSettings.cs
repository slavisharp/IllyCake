namespace IllyCake.Common.Settings
{
    public class AppSettings
    {
        public string AdminRole { get; set; }

        public string[] UserRoles { get; set; }

        public URLSettings URLS { get; set; }
    }

    public class URLSettings
    {
        public string WebAddressDomain { get; set; }

        public string BlogImagesRelativePath { get; set; }

        public string CakeImagesRelativePath { get; set; }

        public string HomePaeImagesRelativePath { get; set; }

        public string QuoteImagesRelativePath { get; set; }
    }
}
