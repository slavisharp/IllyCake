namespace IllyCake.Common.Managers
{
    public interface IUpdateProductToCart
    {
        int OrderItemId { get; set; }

        int Quantity { get; set; }
    }
}
