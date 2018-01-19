namespace IllyCake.Common.Managers
{
    using IllyCake.Common.Exeptions;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using Microsoft.AspNetCore.Hosting;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ImageManager : IImageManager
    {
        private AppSettings settings;
        private IHostingEnvironment env;
        private IRepository<ImageFile> repository;
        private IRepository<BlogPost> blogPostRepository;
        private IRepository<ProductImage> productImageRepository;
        private IRepository<Product> productRepository;
        private IRepository<Paragraph> paragraphRepository;

        public ImageManager(AppSettings settings, 
                            IHostingEnvironment env, 
                            IRepository<ImageFile> repo, 
                            IRepository<Product> productRepository,
                            IRepository<BlogPost> blogPostRepo,
                            IRepository<ProductImage> productImageRepository,
                            IRepository<Paragraph> paragraphRepo)
        {
            this.settings = settings;
            this.env = env;
            this.repository = repo;
            this.blogPostRepository = blogPostRepo;
            this.productImageRepository = productImageRepository;
            this.productRepository = productRepository;
            this.paragraphRepository = paragraphRepo;
        }
        
        public async Task<ImageFile> AddArticleImageAsync(string fileName, string contentType, long length, byte[] imageBytes)
        {
            return await AddImageAsync(
                this.settings.URLS.BlogImagesRelativePath, this.settings.URLS.BlogImagesFileRelativePath, fileName, contentType, length, imageBytes);
        }
        
        public async Task<ImageFile> AddProductMainImageAsync(string fileName, string contentType, long length, byte[] imageBytes, int? productId)
        {
            var image = await AddProductImageAsync(fileName, contentType, length, imageBytes);
            if (productId != null)
            {
                var product = await this.productRepository.GetByIdAsync(productId);
                if (product != null)
                {
                    product.ThumbImageId = image.Id;
                    await this.productRepository.SaveAsync();
                }
            }

            return image;
        }

        public async Task<ImageFile> AddProductGalleryImageAsync(string fileName, string contentType, long length, byte[] imageBytes, int? productId)
        {
            var image = await AddProductImageAsync(fileName, contentType, length, imageBytes);
            if (productId != null)
            {
                var product = await this.productRepository.GetByIdAsync(productId);
                if (product != null)
                {
                    var productImage = new ProductImage()
                    {
                        ImageId = image.Id,
                        ProductId = product.Id
                    };

                    this.productImageRepository.Add(productImage);
                    await this.productImageRepository.SaveAsync();
                }
            }

            return image;
        }

        public async Task<ImageFile> AddBlogPostMainImageAsync(string fileName, string contentType, long length, byte[] imageBytes, string blogPostId)
        {
            var image = await AddImageAsync(this.settings.URLS.BlogImagesRelativePath, this.settings.URLS.BlogImagesFileRelativePath, fileName, contentType, length, imageBytes);
            if (blogPostId != null)
            {
                var blogPost = await this.blogPostRepository.GetByIdAsync(blogPostId);
                if (blogPost != null)
                {
                    blogPost.ThumbImageId = image.Id;
                    await this.productRepository.SaveAsync();
                }
            }

            return image;
        }

        public async Task<ImageFile> AddParagraphImageAsync(string fileName, string contentType, long length, byte[] imageBytes, int? paragraphId)
        {
            var image = await AddImageAsync(this.settings.URLS.BlogImagesRelativePath, this.settings.URLS.BlogImagesFileRelativePath, fileName, contentType, length, imageBytes);
            if (paragraphId != null)
            {
                Paragraph paragraph = await this.paragraphRepository.GetByIdAsync(paragraphId);
                if (paragraph != null)
                {
                    paragraph.Image = image;
                    await this.productRepository.SaveAsync();
                }
            }

            return image;
        }
        
        public async Task<ImageFile> AddQuoteImageAsync(string fileName, string contentType, long length, byte[] imageBytes)
        {
            return await AddImageAsync(
                this.settings.URLS.QuoteImagesRelativePath, this.settings.URLS.QuoteImagesFileRelativePath, fileName, contentType, length, imageBytes);
        }
        
        private async Task<ImageFile> AddProductImageAsync(string fileName, string contentType, long length, byte[] imageBytes)
        {
            return await AddImageAsync(
                this.settings.URLS.ProductImagesRelativePath, this.settings.URLS.ProductImagesFileRelativePath, fileName, contentType, length, imageBytes);
        }
        
        private async Task<ImageFile> AddImageAsync(string relativeWebPath, string relativeFilePath, string fileName, string contentType, long length, byte[] imageBytes)
        {
            string extension = this.GetFileNameExtension(fileName);
            string guidName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), extension);
            string imageRelativeFilePath = string.Format("{0}\\{1}", relativeFilePath, guidName);
            string imageRelativeWebPath = string.Format("{0}/{1}", relativeWebPath, guidName);
            string fullPath = string.Format("{0}{1}", env.WebRootPath, imageRelativeFilePath);
            await this.ByteArrayToFile(fullPath, imageBytes);
            var imageEntity = new ImageFile()
            {
                GuidName = guidName,
                Extension = extension,
                Name = fileName,
                MimeType = contentType,
                UploadedDate = DateTime.Now,
                Path = imageRelativeWebPath
            };
            this.repository.Add(imageEntity);
            await this.repository.SaveAsync();
            return imageEntity;
        }

        private string GetFileNameExtension(string fileName)
        {
            int index = fileName.LastIndexOf('.') + 1;
            int length = fileName.Length - index;
            string extension = fileName.Substring(index, length);
            return extension;
        }

        private async Task ByteArrayToFile(string fileName, byte[] byteArray)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(byteArray, 0, byteArray.Length);
            }
        }

        public async Task<ProductImage> DeleteProductImageAsync(int productId, int imageId)
        {
            var productImage = this.productImageRepository.All().Where(i => i.ImageId == imageId && i.ProductId == productId).FirstOrDefault();
            if (productImage == null)
            {
                throw new EntityNotFoundException("Снимката не е намерена!");
            }

            this.productImageRepository.Delete(productImage);
            await this.productImageRepository.SaveAsync();
            return productImage;
        }
    }
}
