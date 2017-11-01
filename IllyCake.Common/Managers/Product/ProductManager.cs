namespace IllyCake.Common.Managers
{
    using System.Linq;
    using System.Threading.Tasks;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;

    public class ProductManager : IProductManager
    {
        private IRepository<Product> repository;
        private IRepository<ProductCategory> categoryRepository;

        public ProductManager(IRepository<Product> repo, IRepository<ProductCategory> categoryRepo)
        {
            this.repository = repo;
            this.categoryRepository = categoryRepo;
        }

        public IQueryable<Product> GetAll()
        {
            return this.repository.All().Where(p => !p.IsDeleted);
        }

        public IQueryable<ProductCategory> GetAllProductCategories()
        {
            return this.categoryRepository.All().Where(c => !c.IsDeleted);
        }
    }
}
