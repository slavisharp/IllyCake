namespace IllyCake.Common.Managers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using Microsoft.AspNetCore.Hosting;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class ImageManager : IImageManager
    {
        private AppSettings settings;
        private IHostingEnvironment env;
        private IRepository<ImageFile> repository;

        public ImageManager(AppSettings settings, IHostingEnvironment env, IRepository<ImageFile> repo)
        {
            this.settings = settings;
            this.env = env;
            this.repository = repo;
        }

        public async Task<ImageFile> AddQuoteImageAsync(string fileName, string contentType, long length, byte[] imageBytes)
        {
            return await AddImageSync(
                this.settings.URLS.QuoteImagesRelativePath, this.settings.URLS.QuoteImagesFileRelativePath, fileName, contentType, length, imageBytes);
        }

        private async Task<ImageFile> AddImageSync(string relativeWebPath, string relativeFilePath, string fileName, string contentType, long length, byte[] imageBytes)
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
    }
}
