namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Data.Models;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class ProductVersionViewModel : ICreateProductVersionModel, IUpdateProductVersionModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Име")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        
        public int ProductId { get; set; }

        public static Expression<Func<ProductVersion, ProductVersionViewModel>> ExpressionFromProductVersion
        {
            get
            {
                return x => new ProductVersionViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                };
            }
        }

        public static Func<ProductVersion, ProductVersionViewModel> FuncFromProductVersion
        {
            get
            {
                return x => new ProductVersionViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                };
            }
        }
    }
}
