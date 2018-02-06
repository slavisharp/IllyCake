namespace IllyCake.Web.ViewModels.ShoppingCartViewModels
{
    using IllyCake.Common.Managers;
    using System.ComponentModel.DataAnnotations;

    public class AddProductViewModel : IAddProductToCart
    {
        [Required]
        public int ProductId { get; set; }
        
        public int? ProductVersionId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
