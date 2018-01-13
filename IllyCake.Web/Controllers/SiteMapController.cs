namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Settings;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;

    public class SiteMapController : Controller
    {
        private AppSettings appSettings;
        private string webSiteDomain;
        public SiteMapController(AppSettings appSettings)
        {
            this.appSettings = appSettings;
            this.webSiteDomain = appSettings.URLS.WebAddressDomain;
        }

        [HttpGet]
        public ActionResult SiteMapXml()
        {
            var sitemapNodes = this.GetSitemapNodes(base.Url);
            string xml = this.GetSitemapDocument(sitemapNodes);
            return Content(xml, "text/xml", Encoding.UTF8);
        }

        [HttpGet]
        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }

        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(IUrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();
            AddStaticPagesNodes(urlHelper, nodes);

            return nodes;
        }

        private void AddStaticPagesNodes(IUrlHelper urlHelper, List<SitemapNode> nodes)
        {
            nodes.Add(new SitemapNode()
            {
                Url = string.Format("{0}", this.webSiteDomain),
                Priority = 1
            });
            nodes.Add(new SitemapNode()
            {
                Url = string.Format("{0}{1}", this.webSiteDomain, urlHelper.Action("Register", "Account")),
                Priority = 0.8
            });
            nodes.Add(new SitemapNode()
            {
                Url = string.Format("{0}{1}", this.webSiteDomain, urlHelper.Action("About", "Home")),
                Priority = 0.9
            });
            nodes.Add(new SitemapNode()
            {
                Url = string.Format("{0}{1}", this.webSiteDomain, urlHelper.Action("Contact", "Home")),
                Priority = 0.9
            });
        }

        private string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    new XElement(xmlns + "lastmod", DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    new XElement(xmlns + "changefreq", SitemapFrequency.Daily.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }
    }

    public class SitemapNode
    {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }
    }

    public enum SitemapFrequency
    {
        Never,
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        Always
    }
}