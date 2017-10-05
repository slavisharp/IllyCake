namespace IllyCake.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class QuotesController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}