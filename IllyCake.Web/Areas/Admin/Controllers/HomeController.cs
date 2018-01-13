namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminController
    {
        public HomeController(AppSettings appSettings, UserManager<ApplicationUser> userManager) : base(appSettings, userManager)
        { 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}