namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Data.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateViewModel : ICreatePorductModel
    {
        [DisplayName("Име")]
        [Required(ErrorMessage = "Полето е задължително")]
        [MaxLength(100, ErrorMessage = "Името на продукта не трябва да бъде дълго повече от 100 символа!")]
        public string Name { get; set; }

        [DisplayName("Единична Цена")]
        [Required(ErrorMessage = "Полето е задължително")]
        public decimal Price { get; set; }

        [DisplayName("Вид Продукт")]
        [Required(ErrorMessage = "Полето е задължително")]
        public ProductType Type { get; set; }

        [DisplayName("Категория")]
        [Required(ErrorMessage = "Полето е задължително")]
        public int CategoryId { get; set; }

        [DisplayName("Основно изображение")]
        [Required(ErrorMessage = "Полето е задължително")]
        public int MainImage { get; set; }

        public string ImageUrl { get; set; }
    }
}
