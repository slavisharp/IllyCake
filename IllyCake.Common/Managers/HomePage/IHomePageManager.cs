namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;

    public interface IHomePageManager
    {
        IQueryable<Product> HomePageProductsQuery();

        IQueryable<BlogPost> HomePageBlogsQuery();
    }
}
