namespace IllyCake.Web.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductViewModel : ProductListViewModel
    {
        public IList<ImageFileViewModel> GalleryImages { get; set; }

        public IList<ProductVersion> ProductVersions { get; set; }

        public string Description { get; set; }

        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }

        public static Expression<Func<Product, ProductViewModel>> ExpressionFromProductDetail
        {
            get
            {
                return x => new ProductViewModel()
                {
                    Id = x.Id,
                    Alias = x.Alias,
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                    CategoryAlias = x.Category.Alias,
                    Price = x.Price,
                    SKUCode = x.SKUCode,
                    Type = x.Type,
                    Image = x.ThumbImage != null ? new ImageFileViewModel()
                    {
                        Id = x.ThumbImage.Id,
                        Name = x.ThumbImage.Name,
                        RelativePath = x.ThumbImage.Path
                    } : null,
                    Description = x.Description,
                    ProductVersions = x.ProductVersions.ToList(),
                    GalleryImages  = x.Images.Select(i => new ImageFileViewModel()
                    {
                        Id = x.ThumbImage.Id,
                        Name = x.ThumbImage.Name,
                        RelativePath = x.ThumbImage.Path
                    }).ToList(),
                    MetaDescription = x.MetaDescription,
                    MetaKeywords = x.MetaKeyWords
                };
            }
        }
    }
}
