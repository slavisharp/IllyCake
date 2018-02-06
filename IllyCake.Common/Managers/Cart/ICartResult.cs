namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;

    public interface ICartResult
    {
        IQueryable<OrderItem> LineItems { get; set; }
    }
}
