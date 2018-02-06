namespace IllyCake.Common.Managers
{
    using System.Threading.Tasks;

    public interface ICartManager
    {
        ICartResult GetCart(string cartId);
        Task<string> CreateCartAsync();
        Task<ICartResult> AddProductAsync(string cartId, IAddProductToCart model);
        Task<ICartResult> UpdateProductAsync(string cartId, IUpdateProductToCart model);
        Task<ICartResult> RemoveProductAsync(string cartId, int orderItemId);
        Task<ICartResult> ClearShoppingCart(string cartId);
    }
}
