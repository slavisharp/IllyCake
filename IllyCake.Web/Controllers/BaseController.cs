namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        protected ApplicationDbContext dbContext;
        protected AppSettings appSettings;

        public BaseController(ApplicationDbContext context, AppSettings appSettings)
        {
            this.dbContext = context;
            this.appSettings = appSettings;
        }
    }
}