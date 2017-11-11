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
        private IRepository<ImageFile> imageRepository;

        public ProductManager(IRepository<Product> repo, IRepository<ProductCategory> categoryRepo, IRepository<ImageFile> imageRepo)
        {
            this.repository = repo;
            this.categoryRepository = categoryRepo;
            this.imageRepository = imageRepo;
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

            if (product.ThumbImageId != input.ThumbImageId)
            {
                var image = await this.imageRepository.GetByIdAsync(input.ThumbImageId);
                if (image == null)
                {
                    throw new EntityNotFoundException("Главното изображение не е намерено!");
                }

                product.ThumbImageId = input.ThumbImageId;
            }

            IList<int> imageIds = product.Images.Select(i => i.ImageId).ToList();
            var deletedImages = imageIds.Except(input.GalleryImagesIds).ToList();
            if (deletedImages.Any() || imageIds.Count < input.GalleryImagesIds.Count)
            {
                var newImages = input.GalleryImagesIds.Except(imageIds);
                for (int i = 0; i < deletedImages.Count; i++)
                {
                    var imageToRemove = product.Images.Where(e => e.ImageId == deletedImages[i]).FirstOrDefault();
                    product.Images.Remove(imageToRemove);
                }

                foreach (var newImageId in newImages)
                {
                    product.Images.Add(new ProductImage() { ProductId = product.Id, ImageId = newImageId });
                }
            }

            product.Description = input.Descripton;
            product.MetaDescription = input.MetaDescripton;
            product.MetaKeyWords = input.MetaKeyWords;
            product.Name = input.Name;
            product.Price = input.Price;
            product.ShowOnHomePage = input.ShowOnHomePage;
            product.Type = input.Type;
            await this.repository.SaveAsync();
            return product;
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
