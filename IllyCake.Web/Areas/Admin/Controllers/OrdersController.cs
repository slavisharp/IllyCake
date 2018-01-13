namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : AdminController
    {
        public OrdersController(AppSettings appSettings, IOrderManager manager, UserManager<ApplicationUser> userManager) : base(appSettings, userManager)
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
