namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        protected ApplicationDbContext dbContext;
        protected AppSettings appSettings;
        protected bool IsAdmin;

        public BaseController(ApplicationDbContext context, AppSettings appSettings, UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            this.dbContext = context;
            this.appSettings = appSettings;
            //this.IsAdmin = userManager.IsInRoleAsync(Us)
            //ViewBag.IsAdmin = this.IsAdmin;
        }
    }
}