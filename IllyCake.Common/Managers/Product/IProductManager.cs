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

        Task<ProductVersion> CreateProductVersion(ICreateProductVersionModel input);

        Task<ProductVersion> UpdateProductVersion(IUpdateProductVersionModel input);

        Task<ProductVersion> DeleteProductVersion(int id);

        Task<ProductCategory> CreateProductCategory(ICreatePorductCategoryModel input);

        Task<ProductCategory> MoveProductCategory(int categoryId, int positionDelta);

        Task<ProductCategory> EditProductCategory(IEditPorductCategoryModel input);

        Task<Product> EditProduct(IEditPorductModel input);
    }
}
