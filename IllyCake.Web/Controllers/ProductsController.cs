namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

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
            var vm = this.productManager
                .GetAllCategories()
                .Select(ProductCategoryViewModel.ExpressionFromProductCategory)
                .ToList();

            return View(vm);
        }

        [HttpGet]
        [Route("produkti/{category}/{alias}")]
        public IActionResult Details(string category, string alias)
        {
            var vm = this.productManager
                .GetQueryByAlias(alias, category)
                .Select(ProductViewModel.ExpressionFromProductDetail)
                .FirstOrDefault();

            if (vm == null)
            {
                return NotFound("Продукта не е намерен!");
            }

            return View(vm);
        }
    }
}