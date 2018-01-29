namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.Models;
    using IllyCake.Web.ViewModels.BlogPostViewModels;
    using IllyCake.Web.ViewModels.HomePageViewModels;
    using IllyCake.Web.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : BaseController
    {
        private IHomePageManager manager;

        public HomeController(AppSettings appSettings, UserManager<ApplicationUser> userManager, IHomePageManager homePageManager) : base(appSettings, userManager)
        {
            this.manager = homePageManager;
        }

        public IActionResult Index()
        {
            var homeVm = new HomePageViewModel()
            {
                BlogPosts = this.manager.HomePageBlogsQuery().OrderByDescending(p => p.Created).Select(BlogPostListViewModel.ExpressionFromBlogPost).Take(3).ToList(),
                Products = this.manager.HomePageProductsQuery().OrderByDescending(p => p.Created).Select(ProductListViewModel.ExpressionFromProduct).Take(6).ToList()
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
