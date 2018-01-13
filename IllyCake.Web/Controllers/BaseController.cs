namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Threading.Tasks;

    public class BaseController : Controller
    {
        private ApplicationUser currentUser;
        protected AppSettings appSettings;
        private UserManager<ApplicationUser> userManager;

        public BaseController(AppSettings appSettings, UserManager<ApplicationUser> userManager)
        {
            this.appSettings = appSettings;
            this.userManager = userManager;
        }

        protected bool IsAdmin { get; set; }

        protected async Task<ApplicationUser> GetCurrentUser()
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
            this.IsAdmin = base.User != null && base.User.IsInRole(this.appSettings.AdminRole);
            ViewBag.IsAdmin = this.IsAdmin;
        }
    }
}