namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductManager
    {
        IQueryable<Product> GetAll();

        IQueryable<ProductCategory> GetAllProductCategories();

        Task<Product> GetById(int id);

        IQueryable<Product> GetQueryById(int id);

        Task<Product> CreateProduct(ICreatePorductModel input);

        Task<ProductCategory> CreateProductCategory(ICreatePorductCategoryModel input);
    }
}
