namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : AdminController
    {
        public OrdersController(AppSettings appSettings, IOrderManager manager) : base(appSettings)
        {
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
