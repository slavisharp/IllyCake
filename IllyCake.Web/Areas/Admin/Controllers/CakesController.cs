namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using Microsoft.AspNetCore.Mvc;

    public class CakesController : AdminController
    {
        public CakesController(AppSettings appSettings) : base(appSettings)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}