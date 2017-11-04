namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

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
        public async Task<IActionResult> Create(ProductCreateViewModel input)
        {
            if (ModelState.IsValid)
            {
                var product = await this.manager.CreateProduct(input);
                return RedirectToAction(nameof(this.Edit), new { id = product.Id });
            }
            else
            {
                ViewBag.Categories = this.manager.GetAllProductCategories().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
                return View(input);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = this.manager.GetQueryById(id).Select(ProductEditViewModel.FromProduct).FirstOrDefault();
            return View(vm);
        }
    }
}