namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Exeptions;
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
            string cartId = this.HttpContext.Session.Get<string>(base.AppSettings.ShoppingCartSessionKey);
            ShoppingCartViewModel cartModel = new ShoppingCartViewModel(cartManager.GetCart(cartId));
            return View(cartModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductViewModel input)
        {
            string carSessiontId = this.HttpContext.Session.Get<string>(base.AppSettings.ShoppingCartSessionKey);
            if (carSessiontId == null)
            {
                carSessiontId = await this.cartManager.CreateCartAsync();
                this.HttpContext.Session.Set(base.AppSettings.ShoppingCartSessionKey, carSessiontId);
            }

            try
            {
                ShoppingCartViewModel cartModel = new ShoppingCartViewModel(await this.cartManager.AddProductAsync(carSessiontId, input));
                return Json(cartModel);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel input)
        {
            string cartId = this.HttpContext.Session.Get<string>(base.AppSettings.ShoppingCartSessionKey);
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
                try
                {
                    cartModel = new ShoppingCartViewModel(await this.cartManager.UpdateProductAsync(cartId, input));
                }
                catch (EntityNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            return Json(cartModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveProduct(int orderItemId)
        {
            string cartId = this.HttpContext.Session.Get<string>(base.AppSettings.ShoppingCartSessionKey);
            if (cartId == null)
            {
                return BadRequest("Shopping cart is not initialized!");
            }

            try
            {
                ShoppingCartViewModel cartModel = new ShoppingCartViewModel(await this.cartManager.RemoveProductAsync(cartId, orderItemId));
                return Json(cartModel);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            string cartId = this.HttpContext.Session.Get<string>(base.AppSettings.ShoppingCartSessionKey);
            if (cartId == null)
            {
                return BadRequest("Shopping cart is not initialized!");
            }

            await this.cartManager.ClearShoppingCartAsync(cartId);
            ShoppingCartViewModel cartModel = new ShoppingCartViewModel();
            return Json(cartModel);
        }
    }
}