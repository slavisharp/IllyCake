namespace IllyCake.Common.Managers
{
    using System.Threading.Tasks;

    public class CartManager : ICartManager
    {
        public CartManager()
        {

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
