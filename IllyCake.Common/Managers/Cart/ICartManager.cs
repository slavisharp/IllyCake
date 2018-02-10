namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICartManager
    {
        IQueryable<OrderItem> GetCart(string cartSessionId);
        Task<string> CreateCartAsync();
        Task<IQueryable<OrderItem>> AddProductAsync(string cartSessionId, IAddProductToCart model);
        Task<IQueryable<OrderItem>> UpdateProductAsync(string cartSessionId, IUpdateProductToCart model);
        Task<IQueryable<OrderItem>> RemoveProductAsync(string cartSessionId, int orderItemId);
        Task ClearShoppingCartAsync(string cartSessionId);
    }
}
