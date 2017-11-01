namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductManager
    {
        IQueryable<Product> GetAll();

        IQueryable<ProductCategory> GetAllProductCategories();
    }
}
