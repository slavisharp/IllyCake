namespace IllyCake.Common.Managers
{
    using IllyCake.Common.Exeptions;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CartManager : ICartManager
    {
        private IRepository<OrderItem> orderItemRepository;
        private IRepository<Product> productRepository;
        private IRepository<ShoppingCart> cartRepository;

        public CartManager(IRepository<ShoppingCart> cartRepo, IRepository<OrderItem> orderItemRepo, IRepository<Product> productRepo)
        {
            this.orderItemRepository = orderItemRepo;
            this.productRepository = productRepo;
            this.cartRepository = cartRepo;
        }

        public async Task<IQueryable<OrderItem>> AddProductAsync(string cartSessionId, IAddProductToCart model)
        {
            var cart = this.GetCartBySessionId(cartSessionId);
            if (cart == null)
            {
                throw new EntityNotFoundException("Количката не е намерена!");
            }

            var product = this.productRepository.GetById(model.ProductId);
            if (product == null)
            {
                throw new EntityNotFoundException("Продукта не е намерен!");
            }

            bool isProductVersion = model.ProductVersionId != null;
            ProductVersion version = null;
            if (isProductVersion)
            {
                version = product.ProductVersions.AsQueryable().Where(v => v.Id == model.ProductVersionId).FirstOrDefault();
                if (version == null)
                {
                    throw new EntityNotFoundException("Варианта на продукта не е намерен!");
                }
            }

            var cartItem = new OrderItem()
            {
                DiscountAmmunt = 0,
                Price = isProductVersion ? version.Price : product.Price,
                Product = product,
                Quantity = model.Quantity,
                ShoppingCart = cart,
                ProductName = isProductVersion ? version.Name : product.Name
            };

            cartItem.Subtotal = cartItem.Price * cartItem.Quantity;
            cartItem.FinalPrice = cartItem.Subtotal - cartItem.DiscountAmmunt;
            cart.CartItems.Add(cartItem);
            cart.TotalAmount += cartItem.FinalPrice;
            await this.cartRepository.SaveAsync();

            return cart.CartItems.AsQueryable();
        }

        public async Task ClearShoppingCartAsync(string cartSessionId)
        {
            var cart = this.GetCartBySessionId(cartSessionId);
            if (cart == null)
            {
                throw new EntityNotFoundException("Количката не е намерена!");
            }

            var items = cart.CartItems.ToList();
            for (int i = 0; i < items.Count; i++)
            {
                this.orderItemRepository.Delete(items[i]);
            }

            cart.TotalAmount = 0;
            await this.orderItemRepository.SaveAsync();
        }

        public async Task<string> CreateCartAsync()
        {
            var cart = new ShoppingCart()
            {
                SessionKey = Guid.NewGuid().ToString(),
                TotalAmount = 0
            };

            await this.cartRepository.AddAsync(cart);
            await this.cartRepository.SaveAsync();
            return cart.SessionKey;
        }

        public IQueryable<OrderItem> GetCart(string cartSessionId)
        {
            var cartItems = this.cartRepository.All()
                .Where(c => c.SessionKey == cartSessionId)
                .Select(c => c.CartItems.AsQueryable())
                .FirstOrDefault();

            return cartItems;
        }

        public async Task<IQueryable<OrderItem>> RemoveProductAsync(string cartSessionId, int orderItemId)
        {
            var item = this.orderItemRepository.GetById(orderItemId);
            if (item == null)
            {
                throw new EntityNotFoundException("Продукта не е намерен!");
            }

            var cart = item.ShoppingCart;
            if (cart == null || cart.SessionKey != cartSessionId)
            {
                throw new ArgumentException("Продукта не принадлежи на тази количка!");
            }

            this.orderItemRepository.Delete(item);
            cart.TotalAmount -= item.FinalPrice;
            await this.orderItemRepository.SaveAsync();
            return cart.CartItems.AsQueryable();
        }

        public async Task<IQueryable<OrderItem>> UpdateProductAsync(string cartSessionId, IUpdateProductToCart model)
        {
            var item = this.orderItemRepository.GetById(model.OrderItemId);
            if (item == null)
            {
                throw new EntityNotFoundException("Продукта не е намерен!");
            }

            var cart = item.ShoppingCart;
            if (cart == null || cart.SessionKey != cartSessionId)
            {
                throw new ArgumentException("Продукта не принадлежи на тази количка!");
            }

            decimal oldPrice = item.FinalPrice;
            item.Quantity = model.Quantity;
            item.Subtotal = item.Price * item.Quantity;
            item.FinalPrice = item.Subtotal - item.DiscountAmmunt;
            cart.TotalAmount += (item.FinalPrice - oldPrice);
            await this.orderItemRepository.SaveAsync();
            return cart.CartItems.AsQueryable();
        }

        private ShoppingCart GetCartBySessionId(string sessionId)
        {
            return this.cartRepository.All().Where(c => c.SessionKey == sessionId).FirstOrDefault();
        }
    }
}
