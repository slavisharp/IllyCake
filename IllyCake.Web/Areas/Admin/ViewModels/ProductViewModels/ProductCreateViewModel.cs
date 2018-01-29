namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateViewModel : ICreatePorductModel
    {
        [DisplayName("Име")]
        [Required(ErrorMessage = "Полето е задължително")]
        [MaxLength(100, ErrorMessage = "Името на продукта не трябва да бъде дълго повече от 100 символа!")]
        public string Name { get; set; }

        [DisplayName("URL псевдоним")]
        [Required(ErrorMessage = "Полето е задължително")]
        [MaxLength(100, ErrorMessage = "Псевдонимa на продукта не трябва да бъде дълго повече от 100 символа!")]
        public string Alias { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MinLength(2, ErrorMessage = "Кода трябва да е дълъг поне 2 символа!")]
        [MaxLength(10, ErrorMessage = "Кода не трябва да е по-дълъг от 10 символа!")]
        [DisplayName("Каталожен №")]
        public string SKUCode { get; set; }

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
        public int ThumbImageId { get; set; }

        public string ImageUrl { get; set; }
    }
}
