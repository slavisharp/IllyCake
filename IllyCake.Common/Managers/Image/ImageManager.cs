namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using Microsoft.AspNetCore.Hosting;
    using System;

    public class ImageManager : IImageManager
    {
        private IHostingEnvironment env;
        private IRepository<ImageFile> repository;

        public ImageManager(IHostingEnvironment env, IRepository<ImageFile> repo)
        {
            this.env = env;
            this.repository = repo;
        }

        public ImageFile AddImage(string relativePath, string fileName, string contentType, long length, byte[] imageBytes)
        {

            throw new NotImplementedException();
        }
    }
}
