namespace IllyCake.Web.Areas.Admin.ViewModels.ProductCategoryViewModels
{
    using IllyCake.Common.Managers;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ProductCategoryCreateViewModel : ICreatePorductCategoryModel
    {
        [DisplayName("Име на категория")]
        [Required(ErrorMessage = "Името на категорията е задължително!")]
        [MinLength(2, ErrorMessage = "Името на категорията трябва да бъде дълго поне 2 символа!")]
        [MaxLength(100, ErrorMessage = "Името на категорията не трябва да бъде дълго повече от 100 символа!")]
        public string Name { get; set; }

        [DisplayName("URL псевдоним")]
        [Required(ErrorMessage = "Псевдонима на категорията е задължително!")]
        [MinLength(2, ErrorMessage = "Псевдонима на категорията трябва да бъде дълго поне 2 символа!")]
        [MaxLength(100, ErrorMessage = "Псевдонима на категорията не трябва да бъде дълго повече от 100 символа!")]
        public string Alias { get; set; }

        [Required]
        [DisplayName("Покажи на Home Page")]
        public bool ShowOnHomePage { get; set; }
    }
}
