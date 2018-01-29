namespace IllyCake.Web.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Linq.Expressions;

    public class ProductListViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryAlias { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public string Alias { get; set; }

        public string SKUCode { get; set; }

        public decimal Price { get; set; }

        public ImageFileViewModel Image { get; set; }

        public static Expression<Func<Product, ProductListViewModel>> ExpressionFromProduct
        {
            get
            {
                return x => new ProductListViewModel()
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
                    } : null
                };
            }
        }
    }
}
