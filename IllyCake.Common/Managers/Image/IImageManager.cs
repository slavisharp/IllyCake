﻿namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Threading.Tasks;

    public interface IImageManager
    {
        Task<ImageFile> AddQuoteImageAsync(string fileName, string contentType, long length, byte[] imageBytes);
        Task<ImageFile> AddProductMainImageAsync(string fileName, string contentType, long length, byte[] imageBytes, int? productId);
        Task<ImageFile> AddProductGalleryImageAsync(string fileName, string contentType, long length, byte[] imageBytes, int? productId);
        Task<ImageFile> AddArticleImageAsync(string fileName, string contentType, long length, byte[] imageBytes);
        Task<ProductImage> DeleteProductImageAsync(int productId, int imageId);
        Task<ImageFile> AddBlogPostMainImageAsync(string fileName, string contentType, long length, byte[] imageBytes, string blogPostId);
        Task<ImageFile> AddParagraphImageAsync(string fileName, string contentType, long length, byte[] imageBytes, int? paragraphId);
    }
}
