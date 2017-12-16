namespace IllyCake.Common.Managers
{
    using System.Linq;
    using System.Threading.Tasks;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using System;
    using IllyCake.Common.Exeptions;
    using System.Collections.Generic;

    public class ProductManager : IProductManager
    {
        private IRepository<Product> repository;
        private IRepository<ProductCategory> categoryRepository;
        private IRepository<ProductVersion> productVersionRepository;

        public ProductManager(IRepository<Product> repo, IRepository<ProductCategory> categoryRepo, IRepository<ProductVersion> productVersionRepo)
        {
            this.repository = repo;
            this.categoryRepository = categoryRepo;
            this.productVersionRepository = productVersionRepo;
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
            return this.categoryRepository.All().Where(c => !c.IsDeleted).OrderBy(c => c.Position);
        }

        public async Task<Product> CreateProduct(ICreatePorductModel input)
        {
            var product = new Product()
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Price = input.Price,
                ShowOnHomePage = true,
                ThumbImageId = input.ThumbImageId,
                Type = input.Type
            };

            this.repository.Add(product);
            await this.repository.SaveAsync();
            return product;
        }

        public async Task<Product> EditProduct(IEditPorductModel input)
        {
            var product = await this.GetById(input.Id);
            if (product == null)
            {
                throw new EntityNotFoundException("Продукта не е намерен!");
            }

            if (product.CategoryId != input.CategoryId)
            {
                var category = this.categoryRepository.GetByIdAsync(input.CategoryId);
                if (category == null)
                {
                    throw new EntityNotFoundException("Категорията не е намерена!");
                }

                product.CategoryId = input.CategoryId;
            }
           
            product.Description = input.Description;
            product.MetaDescription = input.MetaDescripton;
            product.MetaKeyWords = input.MetaKeyWords;
            product.Name = input.Name;
            product.Price = input.Price;
            product.ShowOnHomePage = input.ShowOnHomePage;
            product.Type = input.Type;
            await this.repository.SaveAsync();
            return product;
        }

        public async Task<ProductVersion> CreateProductVersion(ICreateProductVersionModel input)
        {
            var product = await this.GetById(input.ProductId);
            if (product == null)
            {
                throw new EntityNotFoundException("Продукта не е намерен!");
            }

            var productVersionEntity = new ProductVersion()
            {
                Name = input.Name,
                ProductId = product.Id,
                Price = input.Price
            };

            this.productVersionRepository.Add(productVersionEntity);
            await this.productVersionRepository.SaveAsync();
            return productVersionEntity;
        }
        
        public async Task<ProductVersion> UpdateProductVersion(IUpdateProductVersionModel input)
        {
            var productVersionEntity = await this.productVersionRepository.GetByIdAsync(input.Id);
            if (productVersionEntity == null)
            {
                throw new EntityNotFoundException("Продукта не е намерен!");
            }

            productVersionEntity.Name = input.Name;
            productVersionEntity.Price = input.Price;

            await this.productVersionRepository.SaveAsync();
            return productVersionEntity;
        }

        public async Task<ProductVersion> DeleteProductVersion(int id)
        {
            var productVersionEntity = await this.productVersionRepository.GetByIdAsync(id);
            if (productVersionEntity == null)
            {
                throw new EntityNotFoundException("Продукта не е намерен!");
            }

            productVersionEntity.IsDeleted = true;
            productVersionEntity.DeletedOn = DateTime.Now;

            await this.productVersionRepository.SaveAsync();
            return productVersionEntity;
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

        public async Task<ProductCategory> EditProductCategory(IEditPorductCategoryModel input)
        {
            var category = this.categoryRepository.GetById(input.Id);
            if (category == null)
            {
                throw new EntityNotFoundException("Категорията не е намерена!");
            }

            if (category.Name != input.Name) category.Name = input.Name;
            if (category.ShowOnHomePage != input.ShowOnHomePage) category.ShowOnHomePage = input.ShowOnHomePage;
            await this.repository.SaveAsync();
            return category;
        }

        public async Task<ProductCategory> MoveProductCategory(int categoryId, int positionDelta)
        {
            var category = this.categoryRepository.GetById(categoryId);
            if (category == null)
            {
                throw new EntityNotFoundException("Категорията не е намерена!");
            }
            
            int newPosition = category.Position + positionDelta;
            IQueryable<ProductCategory> siblingsQuery = this.GetAllProductCategories().Where(c => c.Id != category.Id).OrderBy(c => c.Id);
            if (positionDelta > 0)
            {
                var siblings = siblingsQuery.Where(s => s.Position <= newPosition && s.Position > category.Position).ToList();
                foreach (var sibling in siblings)
                {
                    sibling.Position--;
                }
            }
            else if (positionDelta < 0)
            {
                var siblings = siblingsQuery.Where(s => s.Position >= newPosition && s.Position < category.Position).ToList();
                foreach (var sibling in siblings)
                {
                    sibling.Position++;
                }
            }

            category.Position = newPosition;
            await this.categoryRepository.SaveAsync();
            return category;
        }
    }
}
