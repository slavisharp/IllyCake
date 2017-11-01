namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateViewModel
    {
        [Required]
        [DisplayName("Име")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Единична Цена")]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Вид Продукт")]
        public ProductType Type { get; set; }

        [Required]
        [DisplayName("Категория")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Основно изображение")]
        public int MainImage { get; set; }
    }
}
