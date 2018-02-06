namespace IllyCake.Web.ViewModels.ShoppingCartViewModels
{
    using IllyCake.Common.Managers;

    public class ShoppingCartLineItem : ICartLineItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string OrderItemId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }
    }
}
