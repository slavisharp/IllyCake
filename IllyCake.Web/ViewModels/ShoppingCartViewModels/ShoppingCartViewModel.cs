namespace IllyCake.Web.ViewModels.ShoppingCartViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using IllyCake.Data.Models;

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            LineItems = new List<ShoppingCartLineItem>();
            Total = 0;
        }

        public ShoppingCartViewModel(IQueryable<OrderItem> cartResult)
        {
            this.LineItems = cartResult.Select(ShoppingCartLineItem.ExpressionFromOrderItem).ToList();
            this.Total = this.LineItems.Sum(i => i.FinalPrice);
        }

        public decimal Total { get; set; }

        public IList<ShoppingCartLineItem> LineItems { get; set; }
    }
}
