namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductType Type { get; set; }

        public string Category { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int OrderedCount { get; set; }

        public static Expression<Func<Product, ProductListViewModel>> FromProduct
        {
            get
            {
                return x => new ProductListViewModel()
                {
                    Category = x.Category.Name,
                    Created = x.Created,
                    Modified = x.Modified,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ShowOnHomePage = x.ShowOnHomePage,
                    Type = x.Type,
                    OrderedCount = x.OrderItems.Where(i => i.OrderId != null).Sum(i => i.Quantity)
                };
            }
        }
    }
}
