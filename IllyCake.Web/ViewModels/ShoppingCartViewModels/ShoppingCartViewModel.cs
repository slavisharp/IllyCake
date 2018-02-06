namespace IllyCake.Web.ViewModels.ShoppingCartViewModels
{
    using System.Collections.Generic;
    using IllyCake.Common.Managers;

    public class ShoppingCartViewModel
    {
        private ICartResult cartResult;

        public ShoppingCartViewModel(ICartResult cartResult)
        {
            this.cartResult = cartResult;
        }

        public decimal Total { get; set; }

        public IEnumerable<ShoppingCartLineItem> LineItems { get; set; }
    }
}
