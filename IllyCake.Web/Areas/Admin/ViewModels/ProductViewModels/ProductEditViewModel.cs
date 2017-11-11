namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductEditViewModel : ProductBaseViewModel, IEditPorductModel
    {
        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        public int ThumbImageId { get; set; }

        public ImageViewModel ThumbImage { get; set; }

        public IList<int> GalleryImagesIds { get; set; }

        public IEnumerable<ImageViewModel> GalleryImages { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        public string Descripton { get; set; }

        [MaxLength(160)]
        public string MetaDescripton { get; set; }

        [MaxLength(200)]
        public string MetaKeyWords { get; set; }

        public static Expression<Func<Product, ProductEditViewModel>> FromProduct
        {
            get
            {
                return x => new ProductEditViewModel()
                {
                    CategoryName = x.Category.Name,
                    CategoryId = x.CategoryId,
                    Created = x.Created,
                    Modified = x.Modified,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ShowOnHomePage = x.ShowOnHomePage,
                    Type = x.Type,
                    Descripton = x.Description,
                    MetaDescripton = x.MetaDescription,
                    MetaKeyWords = x.MetaKeyWords,
                    OrderedCount = x.OrderItems.Where(i => i.OrderId != null).Sum(i => i.Quantity),
                    ThumbImage = new ImageViewModel() { Id = x.ThumbImageId, Name = x.ThumbImage.Name, Path = x.ThumbImage.Path },
                    ThumbImageId = x.ThumbImageId,
                    GalleryImages = x.Images.AsQueryable().Select(i => i.Image).Select(ImageViewModel.FromImage),
                    GalleryImagesIds = x.Images.Select(i => i.ImageId).ToList()
                };
            }
        }
    }
}
