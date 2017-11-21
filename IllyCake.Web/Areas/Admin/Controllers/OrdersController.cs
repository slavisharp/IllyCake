namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : AdminController
    {
        public OrdersController(AppSettings appSettings) : base(appSettings)
        {
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
