namespace IllyCake.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CakesController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}