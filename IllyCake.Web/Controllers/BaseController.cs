namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class BaseController : Controller
    {
        protected ApplicationDbContext dbContext;
        protected AppSettings appSettings;

        public BaseController(ApplicationDbContext context, AppSettings appSettings)
        {
            this.dbContext = context;
            this.appSettings = appSettings;
        }

        protected bool IsAdmin { get; set; }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            this.IsAdmin = base.User != null && base.User.IsInRole(this.appSettings.AdminRole);
            ViewBag.IsAdmin = this.IsAdmin;
        }
    }
}