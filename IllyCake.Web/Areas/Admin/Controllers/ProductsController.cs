namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
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
            var vm = this.manager.GetAll().Select(ProductListViewModel.ExpressionFromProduct);
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
                SetProductCategoriesList();
                return View(input);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = this.manager.GetQueryById(id).Select(ProductDetailsViewModel.ExpressionFromProduct).FirstOrDefault();
            SetProductCategoriesList();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDetailsViewModel input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await this.manager.EditProduct(input);
                    base.SetActionSuccessMessageInTempData("Информацията за продукта е обновена.");
                    return RedirectToAction("Edit", new { id = input.Id });
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Edit", new { id = input.Id });
                }
            }
            else
            {
                SetProductCategoriesList();
                return View(input);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductVersion(ProductVersionViewModel input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await this.manager.CreateProductVersion(input);
                    return Json(entity);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrorsList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductVersion(ProductVersionViewModel input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await this.manager.CreateProductVersion(input);
                    return Json(entity);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrorsList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductVersion(int id)
        {
            try
            {
                var entity = await this.manager.DeleteProductVersion(id);
                return Json(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void SetProductCategoriesList()
        {
            ViewBag.Categories = this.manager.GetAllProductCategories().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
        }
    }
}