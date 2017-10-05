namespace IllyCake.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BlogPostsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}