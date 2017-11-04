namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Web.Areas.Admin.ViewModels.ProductCategoryViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductCategoriesController : AdminController
    {
        private IProductManager manager;

        public ProductCategoriesController(AppSettings appSettings, IProductManager productManager) : base(appSettings)
        {
            this.manager = productManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = this.manager.GetAllProductCategories().Select(ProductCategoryDetailViewModel.FromProductCategory).ToList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategoryCreateViewModel input)
        {
            if (ModelState.IsValid)
            {
                var category = await this.manager.CreateProductCategory(input);
                TempData["success"] = "Категорията е създанена!";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                TempData["errors"] = errors;
            }

            return RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductCategoryCreateViewModel input)
        {

            return RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePosition(int positionDelta, int categoryId)
        {

            return RedirectToAction(nameof(this.Index));
        }
    }
}
