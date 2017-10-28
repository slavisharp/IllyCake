namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;

    public class ImagesController : BaseController
    {
        private IImageManager imageManager;

        public ImagesController(AppSettings settings, IImageManager imageManager) : base(settings)
        {
            this.imageManager = imageManager;
        }

        [HttpPost]
        public JsonResult UploadQuoteImage(IFormFile image)
        {
            byte[] imageBytes = null;
            using (BinaryReader reader = new BinaryReader(image.OpenReadStream()))
            {
                imageBytes = reader.ReadBytes((int)image.Length);
            }

            var imageResult = this.imageManager.AddImage(appSettings.URLS.QuoteImagesRelativePath, image.FileName, image.ContentType, image.Length, imageBytes);
            return Json(new ImageFileViewModel() { Id = imageResult.Id, Name = imageResult.Name, RelativePath = imageResult.Path });
        }
    }
}
