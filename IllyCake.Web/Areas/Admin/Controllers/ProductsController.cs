namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ProductsController : AdminController
    {
        private IProductManager manager;

        public ProductsController(AppSettings appSettings, IProductManager manager) : base(appSettings)
        {
            this.manager = manager;
        }

        public IActionResult Index()
        {
            var vm = this.manager.GetAll().Select(ProductListViewModel.FromProduct);
            return View(vm);
        }
    }
}