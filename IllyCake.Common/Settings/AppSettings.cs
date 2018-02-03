using System.Collections.Generic;

namespace IllyCake.Common.Settings
{
    public class AppSettings
    {
        public string AdminRole { get; set; }

        public string[] UserRoles { get; set; }

        public URLSettings URLS { get; set; }

        public EmailSettings EmailSettings { get; set; }
    }

    public class URLSettings
    {
        public string WebAddressDomain { get; set; }

        public string BlogImagesRelativePath { get; set; }

        public string BlogImagesFileRelativePath { get; set; }

        public string ProductImagesRelativePath { get; set; }

        public string ProductImagesFileRelativePath { get; set; }

        public string HomePaeImagesRelativePath { get; set; }

        public string HomePaeImagesFileRelativePath { get; set; }

        public string QuoteImagesRelativePath { get; set; }

        public string QuoteImagesFileRelativePath { get; set; }
    }

    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        public string UsernameEmail { get; set; }

        public string From { get; set; }

        public IEnumerable<string> CCList { get; set; }
    }

    public static class StaticStringValues
    {
        public const string REQUIRED_FIELD = "Полето е задължително";
    }
}
