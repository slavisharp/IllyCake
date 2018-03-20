namespace IllyCake.Web.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductCategoryViewModel
    {
        public string Name { get; set; }

        public string Alias { get; set; }

        public IList<ProductListViewModel> Products { get; set; }

        public static Expression<Func<ProductCategory, ProductCategoryViewModel>> ExpressionFromProductCategory
        {
            get
            {
                return c => new ProductCategoryViewModel()
                {
                    Alias = c.Alias,
                    Name = c.Name,
                    Products = c.Products.OrderBy(p => p.Name).Select(x => new ProductListViewModel()
                    {
                        Id = x.Id,
                        Alias = x.Alias,
                        Name = x.Name,
                        Price = x.Price,
                        SKUCode = x.SKUCode,
                        Type = x.Type,
                        Image = x.ThumbImage != null ? new ImageFileViewModel()
                        {
                            Id = x.ThumbImage.Id,
                            Name = x.ThumbImage.Name,
                            RelativePath = x.ThumbImage.Path
                        } : null
                    }).ToList()
                };
            }
        }
    }
}
