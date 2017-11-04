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

        public async Task<Product> GetById(int id)
        {
            return await this.repository.GetByIdAsync(id);
        }

        public IQueryable<Product> GetQueryById(int id)
        {
            return this.repository.All().Where(p => p.Id == id);
        }

        public IQueryable<Product> GetAll()
        {
            return this.repository.All().Where(p => !p.IsDeleted);
        }

        public IQueryable<ProductCategory> GetAllProductCategories()
        {
            return this.categoryRepository.All().Where(c => !c.IsDeleted);
        }

        public async Task<ProductCategory> CreateProductCategory(ICreatePorductCategoryModel input)
        {
            int position = this.categoryRepository.All().Count() + 1;
            var category = new ProductCategory()
            {
                Name = input.Name,
                ShowOnHomePage = input.ShowOnHomePage,
                Position = position
            };

            this.categoryRepository.Add(category);
            await this.categoryRepository.SaveAsync();
            return category;
        }

        public async Task<Product> CreateProduct(ICreatePorductModel input)
        {
            var product = new Product()
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Price = input.Price,
                ShowOnHomePage = true,
                ThumbImageId = input.MainImage,
                Type = input.Type
            };

            this.repository.Add(product);
            await this.repository.SaveAsync();
            return product;
        }
    }
}
