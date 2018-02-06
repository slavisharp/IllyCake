namespace IllyCake.Web.ViewModels.ShoppingCartViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using IllyCake.Common.Managers;

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(ICartResult cartResult)
        {
            this.LineItems = cartResult.LineItems.Select(ShoppingCartLineItem.ExpressionFromOrderItem).ToList();
            this.Total = this.LineItems.Sum(i => i.FinalPrice);
        }

        public decimal Total { get; set; }

        public IList<ShoppingCartLineItem> LineItems { get; set; }
    }
}
