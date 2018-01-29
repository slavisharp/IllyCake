namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private IProductManager productManager;

        public ProductsController(AppSettings settings, UserManager<ApplicationUser> userManager, IProductManager productManager) :base(settings, userManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        [Route("produkti")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("produkti/{category}/{alias}")]
        public IActionResult Details(string category, string alias)
        {
            return View();
        }
    }
}