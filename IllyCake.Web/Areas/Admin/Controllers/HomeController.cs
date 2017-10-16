namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminController
    {
        public HomeController(ApplicationDbContext dbContext, AppSettings appSettings)
            :base(dbContext, appSettings)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}