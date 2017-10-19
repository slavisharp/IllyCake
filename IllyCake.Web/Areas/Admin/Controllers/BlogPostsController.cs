namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using Microsoft.AspNetCore.Mvc;

    public class BlogPostsController : AdminController
    {
        public BlogPostsController(AppSettings appSettings) : base(appSettings)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}