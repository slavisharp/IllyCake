namespace IllyCake.Common.Managers
{
    public interface IAddProductToCart
    {
        int ProductId { get; set; }

        int? ProductVersionId { get; set; }

        int Quantity { get; set; }
    }
}
