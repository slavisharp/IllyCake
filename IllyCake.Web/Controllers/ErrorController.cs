namespace IllyCake.Web.Controllers
{
    using IllyCake.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Index(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound", new ErrorViewModel() { Message = "Грешен адрес!" });
            }
            
            return View();
        }
    }
}