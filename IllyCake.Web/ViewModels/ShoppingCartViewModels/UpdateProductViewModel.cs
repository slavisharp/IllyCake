namespace IllyCake.Web.ViewModels.ShoppingCartViewModels
{
    using IllyCake.Common.Managers;
    using System.ComponentModel.DataAnnotations;

    public class UpdateProductViewModel : IUpdateProductToCart
    {
        [Required]
        public int OrderItemId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
