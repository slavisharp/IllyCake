namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminController
    {
        public HomeController(AppSettings appSettings) : base(appSettings)
        { 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}