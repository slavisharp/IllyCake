namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Threading.Tasks;

    public interface IImageManager
    {
        Task<ImageFile> AddQuoteImageAsync(string fileName, string contentType, long length, byte[] imageBytes);
    }
}
