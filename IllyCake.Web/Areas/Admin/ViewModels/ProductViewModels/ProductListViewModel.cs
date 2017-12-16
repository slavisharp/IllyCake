namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductListViewModel : ProductBaseViewModel
    {
        public static Expression<Func<Product, ProductListViewModel>> ExpressionFromProduct
        {
            get
            {
                return x => new ProductListViewModel()
                {
                    CategoryName = x.Category.Name,
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
