namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;

    public class ProductsController : AdminController
    {
        private IProductManager manager;

        public ProductsController(AppSettings appSettings, IProductManager manager) : base(appSettings)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = this.manager.GetAll().Select(ProductListViewModel.FromProduct);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = this.manager.GetAllProductCategories().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            return View(new ProductCreateViewModel() { Type = ProductType.Muffin, Price = 0 });
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel input)
        {
            ViewBag.Categories = this.manager.GetAllProductCategories().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            return View();
        }
    }
}