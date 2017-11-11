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
        

        public static Expression<Func<ImageFile, ImageViewModel>> FromImage
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
    }
}
