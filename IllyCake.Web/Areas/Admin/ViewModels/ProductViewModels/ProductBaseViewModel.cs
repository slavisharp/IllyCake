namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ProductBaseViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MinLength(2, ErrorMessage = "Името трябва да е дълго поне 2 символа!")]
        [MaxLength(100, ErrorMessage = "Името не трябва да е по-дълго от 100 символа!")]
        [DisplayName("Име на продукта")]
        public string Name { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MinLength(2, ErrorMessage = "Псевдонима трябва да е дълъг поне 2 символа!")]
        [MaxLength(100, ErrorMessage = "Псевдонима не трябва да е по-дълъг от 100 символа!")]
        [DisplayName("URL псевдоним")]
        public string Alias { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MinLength(2, ErrorMessage = "Кода трябва да е дълъг поне 2 символа!")]
        [MaxLength(10, ErrorMessage = "Кода не трябва да е по-дълъг от 10 символа!")]
        [DisplayName("Каталожен №")]
        public string SKUCode { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [DisplayName("Цена")]
        [Range(0, Double.PositiveInfinity)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [DisplayName("Вид продукт")]
        public ProductType Type { get; set; }

        public string CategoryName { get; set; }

        [DisplayName("Дата на създаване")]
        public DateTime Created { get; set; }

        [DisplayName("Последно модифициран")]
        public DateTime? Modified { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [DisplayName("На начален екран")]
        public bool ShowOnHomePage { get; set; }

        [DisplayName("Брой на поръчки")]
        public int OrderedCount { get; set; }
    }
}
