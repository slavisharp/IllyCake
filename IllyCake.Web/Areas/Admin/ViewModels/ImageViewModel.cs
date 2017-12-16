namespace IllyCake.Web.Areas.Admin.ViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class ImageViewModel
    {
        [Required]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Path { get; set; }
        

        public static Expression<Func<ImageFile, ImageViewModel>> ExpressionFromImage
        {
            get
            {
                return x => new ImageViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Path = x.Path
                };
            }
        }

        public static Func<ProductImage, ImageViewModel> FuncFromProductImage
        {
            get
            {
                return x => new ImageViewModel()
                {
                    Id = x.ImageId,
                    Name = x.Image.Name,
                    Path = x.Image.Path
                };
            }
        }
    }
}
