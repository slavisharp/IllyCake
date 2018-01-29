namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : BaseController
    {
        private IBlogPostManager blogManager;

        public BlogController(AppSettings settings, UserManager<ApplicationUser> userManager, IBlogPostManager blogManager) : base(settings, userManager)
        {
            this.blogManager = blogManager;
        }

        [HttpGet]
        [Route("blog")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("blog/{alias}")]
        public IActionResult Details(string alias)
        {
            return View();
        }
    }
}