namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductEditViewModel : ProductBaseViewModel
    {
        public static Expression<Func<Product, ProductEditViewModel>> FromProduct
        {
            get
            {
                return x => new ProductEditViewModel()
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
