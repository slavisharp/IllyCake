namespace IllyCake.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    
    using IllyCake.Web.Models;
    using IllyCake.Common.Settings;
    using IllyCake.Common.Managers;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using IllyCake.Web.ViewModels.HomePageViewModels;
    using System.Linq;

    public class HomeController : BaseController
    {
        private IHomePageManager manager;

        public HomeController(AppSettings appSettings, IHomePageManager homePageManager, UserManager<ApplicationUser> userManager) : base(appSettings, userManager)
        {
            this.manager = homePageManager;
        }

        public IActionResult Index()
        {
            var homeVm = new HomePageViewModel()
            {
                BlogPosts = this.manager.HomePageBlogsQuery().OrderByDescending(p => p.Created).Select().Take(3),
                Products = this.manager.HomePageProductsQuery().OrderBy(p => p.Category.Name).Select()
            };

            return View(homeVm);
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
