namespace IllyCake.Common.Managers
{
    using System.Linq;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;

    public class ProductManager : IProductManager
    {
        private IRepository<Product> repository;

        public ProductManager(IRepository<Product> repo)
        {
            this.repository = repo;
        }

        public IQueryable<Product> GetAll()
        {
            return this.repository.All().Where(p => p.IsDeleted == false);
        }
    }
}
