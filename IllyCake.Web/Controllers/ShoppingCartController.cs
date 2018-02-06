namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.ViewModels.ShoppingCartViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ShoppingCartController : BaseController
    {
        private ICartManager cartManager;

        public ShoppingCartController(AppSettings settings, UserManager<ApplicationUser> userManager, ICartManager cartManager) : base(settings, userManager)
        {
            this.cartManager = cartManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string cartId = this.HttpContext.Session.Get<string>(base.appSettings.ShoppingCartSessionKey);
            ShoppingCartViewModel cartModel = new ShoppingCartViewModel(cartManager.GetCart(cartId));
            return View(cartModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductViewModel input)
        {
            string cartId = this.HttpContext.Session.Get<string>(base.appSettings.ShoppingCartSessionKey);
            if (cartId == null)
            {
                cartId = await this.cartManager.CreateCartAsync();
                this.HttpContext.Session.Set(base.appSettings.ShoppingCartSessionKey, cartId);
            }

            ShoppingCartViewModel cartModel = new ShoppingCartViewModel(await this.cartManager.AddProductAsync(cartId, input));
            return Json(cartModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel input)
        {
            string cartId = this.HttpContext.Session.Get<string>(base.appSettings.ShoppingCartSessionKey);
            ShoppingCartViewModel cartModel = null;
            if (cartId == null)
            {
                if (cartId == null)
                {
                    return BadRequest("Shopping cart is not initialized!");
                }
            }
            else
            {
                cartModel = new ShoppingCartViewModel(await this.cartManager.UpdateProductAsync(cartId, input));
            }

            return Json(cartModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveProduct(int orderItemId)
        {
            string cartId = this.HttpContext.Session.Get<string>(base.appSettings.ShoppingCartSessionKey);
            if (cartId == null)
            {
                return BadRequest("Shopping cart is not initialized!");
            }

            ShoppingCartViewModel cartModel = new ShoppingCartViewModel(await this.cartManager.RemoveProductAsync(cartId, orderItemId));
            return Json(cartModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            string cartId = this.HttpContext.Session.Get<string>(base.appSettings.ShoppingCartSessionKey);
            if (cartId == null)
            {
                return BadRequest("Shopping cart is not initialized!");
            }

            ShoppingCartViewModel cartModel = new ShoppingCartViewModel(await this.cartManager.ClearShoppingCart(cartId));
            return Json(cartModel);
        }
    }
}