namespace IllyCake.Common.Managers
{
    public interface ICartLineItem
    {
        int ProductId { get; set; }

        string OrderItemId { get; set; }

        string ProductName { get; set; }

        decimal Price { get; set; }

        int Quantity { get; set; }

        decimal Total { get; set; }
    }
}
