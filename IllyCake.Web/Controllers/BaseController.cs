namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Threading.Tasks;

    public class BaseController : Controller
    {
        private ApplicationUser currentUser;
        private UserManager<ApplicationUser> userManager;
        private AppSettings appSettings;
        private bool isAdmin;

        public BaseController(AppSettings appSettings, UserManager<ApplicationUser> userManager)
        {
            this.appSettings = appSettings;
            this.userManager = userManager;
        }

        protected bool IsAdmin { get { return this.isAdmin; } }

        protected AppSettings AppSettings { get { return this.appSettings; } }

        protected async Task<ApplicationUser> GetCurrentUserAsync()
        {
            if (currentUser == null)
            {
                currentUser = await this.userManager.GetUserAsync(this.User);
            }

            return currentUser;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            this.isAdmin = base.User != null && base.User.IsInRole(this.AppSettings.AdminRole);
            ViewBag.IsAdmin = this.IsAdmin;
        }
    }
}