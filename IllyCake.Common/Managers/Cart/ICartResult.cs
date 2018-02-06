namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;

    public interface ICartResult
    {
        decimal Total { get; set; }

        IQueryable<OrderItem> LineItems { get; set; }
    }
}
