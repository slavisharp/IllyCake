namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
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

        public Task<ICartResult> AddProductAsync(string cartId, IAddProductToCart model)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICartResult> ClearShoppingCart(string cartId)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> CreateCartAsync()
        {
            throw new System.NotImplementedException();
        }

        public ICartResult GetCart(string cartId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICartResult> RemoveProductAsync(string cartId, int orderItemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICartResult> UpdateProductAsync(string cartId, IUpdateProductToCart model)
        {
            throw new System.NotImplementedException();
        }
    }
}
