namespace IllyCake.Web.Areas.Admin.ViewModels.ProductCategoryViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Linq.Expressions;

    public class ProductCategoryDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int Position { get; set; }

        public static Expression<Func<ProductCategory, ProductCategoryDetailViewModel>> ExpressionFromProductCategory
        {
            get
            {
                return x => new ProductCategoryDetailViewModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                    Position = x.Position,
                    ShowOnHomePage = x.ShowOnHomePage
                };
            }
        }
    }
}
