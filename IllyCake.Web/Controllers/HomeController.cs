namespace IllyCake.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    
    using IllyCake.Web.Models;
    using IllyCake.Common.Settings;
    using IllyCake.Common.Managers;

    public class HomeController : BaseController
    {
        private IHomePageManager manager;

        public HomeController(AppSettings appSettings, IHomePageManager homePageManager) : base(appSettings)
        {
            this.manager = homePageManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
