namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Exeptions;
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Web.Areas.Admin.ViewModels.ProductCategoryViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Linq;
    using System.Net;
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
            var vm = this.manager.GetAllProductCategories().Select(ProductCategoryDetailViewModel.ExpressionFromProductCategory).ToList();
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
                var errors = ModelState.GetErrorsList();
                TempData["errors"] = errors;
            }

            return RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductCategoryEditViewModel input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrorsList();
                return StatusCode((int)HttpStatusCode.BadRequest, new { error = "Невалидни данни!", errorList = errors });
            }

            try
            {
                var entity = await this.manager.EditProductCategory(input);
                return Json(new { success ="Промените са запазени!", entity = entity });
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePosition(int categoryId, int positionDelta)
        {
            try
            {
                var entity = await this.manager.MoveProductCategory(categoryId, positionDelta);
                return Json(new { success = "Промените са запазени!", entity = entity });
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
