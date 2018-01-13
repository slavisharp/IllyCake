namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class QuotesController : AdminController
    {
        public QuotesController(AppSettings appSettings, UserManager<ApplicationUser> userManager) : base(appSettings, userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}