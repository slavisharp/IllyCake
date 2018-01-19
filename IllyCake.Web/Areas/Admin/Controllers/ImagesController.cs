namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Exeptions;
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using IllyCake.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class ImagesController : AdminController
    {
        private IImageManager imageManager;

        public ImagesController(AppSettings settings, IImageManager imageManager, UserManager<ApplicationUser> userManager) : base(settings, userManager)
        {
            this.imageManager = imageManager;
        }

        [HttpPost]
        public async Task<IActionResult> UploadProductMainImage(int? productId = null)
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

                var imageEntity = await this.imageManager.AddProductMainImageAsync(image.FileName, image.ContentType, image.Length, imageBytes, productId);
                imagesResult.Add(new ImageFileViewModel() { Id = imageEntity.Id, Name = imageEntity.Name, RelativePath = imageEntity.Path });
            }

            return Json(imagesResult);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProductGaleryImages(int? productId = null)
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

                var imageEntity = await this.imageManager.AddProductGalleryImageAsync(image.FileName, image.ContentType, image.Length, imageBytes, productId);
                imagesResult.Add(new ImageFileViewModel() { Id = imageEntity.Id, Name = imageEntity.Name, RelativePath = imageEntity.Path });
            }

            return Json(imagesResult);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductImage(int productId, int imageId)
        {
            try
            {
                var image = await this.imageManager.DeleteProductImageAsync(productId, imageId);
                return Json(new { success = "Снимката е изтрита!" });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadBlogPostMainImage(string blogPostId = null)
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

                var imageEntity = await this.imageManager.AddBlogPostMainImageAsync(image.FileName, image.ContentType, image.Length, imageBytes, blogPostId);
                imagesResult.Add(new ImageFileViewModel() { Id = imageEntity.Id, Name = imageEntity.Name, RelativePath = imageEntity.Path });
            }

            return Json(imagesResult);
        }

        [HttpPost]
        public async Task<IActionResult> UploadParagraphImage(int? paragraphId = null)
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

                var imageEntity = await this.imageManager.AddParagraphImageAsync(image.FileName, image.ContentType, image.Length, imageBytes, paragraphId);
                imagesResult.Add(new ImageFileViewModel() { Id = imageEntity.Id, Name = imageEntity.Name, RelativePath = imageEntity.Path });
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
