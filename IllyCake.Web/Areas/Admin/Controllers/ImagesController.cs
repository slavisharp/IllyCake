namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class ImagesController : AdminController
    {
        private IImageManager imageManager;

        public ImagesController(AppSettings settings, IImageManager imageManager) : base(settings)
        {
            this.imageManager = imageManager;
        }

        [HttpPost]
        public async Task<IActionResult> UploadProductImage()
        {
            var images = this.Request.Form.Files;
            if (images == null || images.Count == 0)
            {
                return BadRequest("Няма избрани файлове!");
            }

            byte[] imageBytes = null;
            IList<ImageFileViewModel> imagesResult = new List<ImageFileViewModel>(images.Count);
            foreach (var image in images)
            {
                using (BinaryReader reader = new BinaryReader(image.OpenReadStream()))
                {
                    imageBytes = reader.ReadBytes((int)image.Length);
                }

                var imageResult = await this.imageManager.AddProductImageAsync(image.FileName, image.ContentType, image.Length, imageBytes);
                imagesResult.Add(new ImageFileViewModel() { Id = imageResult.Id, Name = imageResult.Name, RelativePath = imageResult.Path });
            }

            return Json(imagesResult);
        }

        [HttpPost]
        [Route("/uploader/upload.php")]
        public async Task<IActionResult> UploadArticleImage(IFormFile upload)
        {
            if (upload == null)
            {
                return BadRequest("Няма избран файл!");
            }

            byte[] imageBytes = null;
            using (BinaryReader reader = new BinaryReader(upload.OpenReadStream()))
            {
                imageBytes = reader.ReadBytes((int)upload.Length);
            }

            var imageResult = await this.imageManager.AddArticleImageAsync(upload.FileName, upload.ContentType, upload.Length, imageBytes);
            return Json(new { id = imageResult.Id, fileName = imageResult.Name, url = imageResult.Path, uploaded = 1 });
        }
    }
}
